using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_EDII.Estructura
{
    public class ArbolB_Estrella_
    {
        private static ArbolB_Estrella_ _instance = null;
        public static ArbolB_Estrella_ Instance
        {
            get
            {
                if (_instance == null) _instance = new ArbolB_Estrella_();
                return _instance;
            }
        }
        public static int grado = 5;
        public Nodo raiz = null;
        public void Add(string N, string S, int V, double P, string C_P)
        {
            if (raiz == null)
            {
                raiz = new Nodo(grado, true);
                raiz.values[0] = new Bebida()
                {
                    Nombre = N,
                    Sabor = S,
                    Volumen = V,
                    Precio = P,
                    Casa_Productora = C_P
                };
            }
            else
            {
                int num = 0;
                foreach (var espacio in raiz.values)
                {
                    if (espacio == null && num < grado - 1)
                    {
                        raiz.values[num] = new Bebida()
                        {
                            Nombre = N,
                            Sabor = S,
                            Volumen = V,
                            Precio = P,
                            Casa_Productora = C_P

                        };
                        break;
                    }
                    num++;
                    if (num == grado - 1) /// full
                    {
                        // Aux(N, f, i, p, M, raiz.datos);
                        //separar(ref raiz.datos, auxiliar, raiz, 0);
                    }
                }
            }
        }
    }
}
