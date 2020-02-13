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
        bool bandera = true;
        #region Extras
        public void Auxiliar(string N, string S, int V, double P, string C_P, Bebida[] nodos,int num)
        {          
            Bebida[] auxiliar = new Bebida[(4 / 3) * grado - 1];                        
            int entrada = 0;
            foreach (var item in nodos)
            {
                auxiliar[entrada] = item;
                entrada++;
            }
            auxiliar[entrada] = new Bebida()
            {
                Nombre = N,
                Sabor = S,
                Volumen = V,
                Precio = P,
                Casa_Productora = C_P
            };
            Ordenar(ref auxiliar);
        }
        public void Ordenar(ref Bebida[] valores)
        {
            var lista = new List<Bebida>();
            foreach (var iteraciones in valores)
            {
                if (iteraciones != null)
                {
                    lista.Add(iteraciones);
                }
            }
            lista = lista.OrderBy(x => x.Nombre).ToList();
            var contador = 0;
            foreach (var item in lista)
            {
                valores[contador] = item;
                contador++;
            }
        }
        public Bebida Subir_Elemento(ref Bebida[] nodo)
        {

            return null;
        }
        #endregion
        public void Add(string N, string S, int V, double P, string C_P)
        {
            if (raiz == null)
            {
                raiz = new Nodo(grado, bandera);
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
                    if (num == ((4/3)*(grado-1))) /// full
                    {
                         Auxiliar(N, S,V,P,C_P, raiz.values,((4/3)*grado-1)+1);
                       //separar(ref raiz.value, auxiliar, raiz, 0); ///Aqui manda a un metodo recursivo
                    }
                }
            }
        }
    }
}
