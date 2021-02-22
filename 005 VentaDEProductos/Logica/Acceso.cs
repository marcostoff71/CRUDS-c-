using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _005_VentaDEProductos.Modelos;
using System.Windows.Forms;

namespace _005_VentaDEProductos.Logica
{
    public class Acceso
    {
        
        public static List<Producto> ObtenerProducto()
        {
            
            List<Producto> pro = new List<Producto>();
            try
            {
                ConexionMaestra.Conectar();
                string comando = "select * from Productos";
                SqlCommand comandaObtener = new SqlCommand(comando, ConexionMaestra.Conexion);
                SqlDataReader lectura = comandaObtener.ExecuteReader();
                while (lectura.Read())
                {
                    Producto p1 = new Producto();
                    p1.Id =int.Parse( lectura[0].ToString());
                    p1.NombreProducto = lectura[1].ToString();
                    p1.Cantidad = int.Parse(lectura[2].ToString());
                    p1.Precio = double.Parse(lectura[3].ToString());
                    pro.Add(p1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eror al obentern datos");
            }
            finally
            {
                ConexionMaestra.Cerrar();
            }


            return pro;
        }
        public static void ModificarPruducto(Producto prod)
        {
            try
            {
                ConexionMaestra.Conectar();
                string comand1 = string.Format("UPDATE Productos SET Producto='{0}',Cantidad={1},Precio={2} where Id ={3}", prod.NombreProducto, prod.Cantidad, prod.Precio,prod.Id);
                SqlCommand mandoModi = new SqlCommand(comand1, ConexionMaestra.Conexion);
                mandoModi.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al modificar"+e.Message);
            }
            finally { ConexionMaestra.Cerrar(); }
        }
        public static void AgregarProducto(Producto pAgre)
        {
            try
            {
                ConexionMaestra.Conectar();
                string query = string.Format("Insert Into Productos(Producto,Cantidad,Precio) values('{0}',{1},{2})", pAgre.NombreProducto, pAgre.Cantidad, pAgre.Precio);
                SqlCommand coman1 = new SqlCommand(query, ConexionMaestra.Conexion);
                coman1.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al agregar producto"+e.Message);
            }
            finally { ConexionMaestra.Cerrar(); }
        }
        public static List<Producto> BuscarProducto(string bus)
        {
            List<Producto> pro = new List<Producto>();
            try
            {
                ConexionMaestra.Conectar();
                string query = string.Format("Select * from Productos where Producto like '%{0}%'", bus);
                SqlCommand comandoBusc = new SqlCommand(query, ConexionMaestra.Conexion);
                SqlDataReader lectura = comandoBusc.ExecuteReader();
                while (lectura.Read())
                {
                    pro.Add(new Producto { 
                    Id=int.Parse(lectura["Id"].ToString()),
                    NombreProducto=lectura["Producto"].ToString(),
                    Cantidad=int.Parse(lectura["Cantidad"].ToString()),
                    Precio=double.Parse(lectura["Precio"].ToString())
                    
                    });
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al buscar");
            }
            finally { ConexionMaestra.Cerrar(); }
            return pro;
        }
        public static void EliminarProducto(int id)
        {
            try
            {
                ConexionMaestra.Conectar();
                string queri = string.Format("Delete from Productos where Id={0}", id);
                SqlCommand elimi = new SqlCommand(queri, ConexionMaestra.Conexion);
                elimi.ExecuteNonQuery();
            }
            catch (Exception)
            {

                MessageBox.Show("Error al eliminar");
            }
            finally { ConexionMaestra.Cerrar(); }
        }
        public static Producto ObternerPorid(int id)
        {
            Producto p1 = new Producto();
            try
            {
                ConexionMaestra.Conectar();
                string query = string.Format("Select * from Productos where Id={0}", id);
                SqlCommand coman = new SqlCommand(query, ConexionMaestra.Conexion);
                SqlDataReader read = coman.ExecuteReader();
                if (read.Read())
                {
                    p1.Id = int.Parse(read["Id"].ToString());
                    p1.NombreProducto = read["Producto"].ToString();
                    p1.Cantidad = int.Parse(read["Cantidad"].ToString());
                    p1.Precio = double.Parse(read["Precio"].ToString());
                }
                
            }
            catch (Exception)
            {


            }
            finally { ConexionMaestra.Cerrar(); }
            return p1;
        }
    }
}
