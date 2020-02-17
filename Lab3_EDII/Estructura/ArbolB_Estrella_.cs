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
        public static int grado = 7;
        public Nodo raiz = null;
        public Nodo hijos = null;
        static int valor = ((4 * (grado - 1)) / 3);
        Bebida[] auxiliar_R = new Bebida[(valor)+1];                                
        #region Extras
        public void Auxiliar_R(string N, string S, int V, double P, string C_P, Bebida[] nodos,int num)
        {          
            int entrada = 0;
            foreach (var item in nodos)
            {
                auxiliar_R[entrada] = item;
                entrada++;
            }
            auxiliar_R[entrada] = new Bebida()
            {
                Nombre = N,
                Sabor = S,
                Volumen = V,
                Precio = P,
                Casa_Productora = C_P
            };
            Ordenar(ref auxiliar_R);
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
        public Bebida Subir_Elemento(Bebida[] nodo, Bebida[] nodo2, int Identificador)
        {
            int mitad = nodo2.Length / 2;
            var nuevo_elemento = nodo2[mitad];
            Asignar_der_izq(nodo, Identificador, mitad);
            return nuevo_elemento;
        }
        public void Asignar_der_izq(Bebida[] nodo, int Identificador, int mitad)
        {
            hijos = new Nodo(grado, false);
            for (int llenado_izq = 0; llenado_izq < mitad; llenado_izq++)
            {
               hijos.values[llenado_izq] = nodo[llenado_izq];
            }
            hijos.id = Identificador + 1;
            raiz.hijos[Identificador - 1] = hijos.id;
            Array.Clear(nodo,0,mitad);
            //// Escribir en disco 
            ////Segunda mitad 
            hijos = new Nodo(grado, false);
            int contador = 0;
            for (int llenado_der = mitad + 1; llenado_der > mitad && llenado_der < nodo.Length; llenado_der++)
            {
                hijos.values[contador] = nodo[llenado_der];
                contador++;
            }
            hijos.id = Identificador + 2;
            raiz.hijos[Identificador] = hijos.id;
            // Escribir en disco
           // Array.Clear(nodo, mitad + 2, grado - 1);
        }
        #endregion
        public void Add(string N, string S, int V, double P, string C_P)
        {
            int identificacion = 1;
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
                raiz.id = identificacion;  // Identifica el primer nodo
            }
            else
            {
                int num = 0;
                foreach (var espacio in raiz.values)
                {
                    if (espacio == null && num < valor)
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
                    if (num == valor) /// full
                    {
                         Auxiliar_R(N, S,V,P,C_P, raiz.values,((4/3)*grado-1)+1);
                        var nuevo_dato =  Subir_Elemento(raiz.values, auxiliar_R,identificacion);

                       //asignar_der_izq
                    }
                }
            }
        }
    }
}
