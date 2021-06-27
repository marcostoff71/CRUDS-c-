using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _012_CrudTienda.Modelos;

namespace _012_CrudTienda.Logica
{
    class LTienda
    {
        public static string ObternCodigoc(List<Tienda> lst)
        {
            Random rdn = new Random();
            string abc = "abcdefghijklmnopqrstvwxzyzABCDEFGHIJKLMNOPQRSTVWXYZ";
            bool correcto = false;
            string gene = "";
            do
            {
                gene = "";
                int a = 0;
                for (int i = 0; i < 10; i++)
                {
                    a = rdn.Next(abc.Length - 1);
                    gene += abc[a];
                }
                correcto = true;

                //Tienda asa = lst.FirstOrDefault(I => I.Codigo == gene);
                //if (asa == null)
                //{

                //}
                //else
                //{
                //    correcto = false;
                //}

                correcto = !lst.Exists(i => i.Codigo == gene);
                foreach (Tienda item in lst)
                {
                    if (item.Codigo == gene)
                    {
                        correcto = false;
                        break;
                    }
                }
                
            } while (!correcto);

            return gene;
        }
        public static double ObtenerTotal(double precio,int cantidad)
        {
            double to=precio*cantidad;
            return to;
        }
        public static bool esNum(string men)
        {
            return int.TryParse(men, out int num);
        }
        public static bool esNumF(string men)
        {
            return float.TryParse(men, out float num);
        }
    }
}
