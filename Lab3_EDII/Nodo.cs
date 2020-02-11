using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lab3_EDII
{
    public class Nodo
    {
        public int id { get; set; }
        public int padre { get; set; }
        public int[] hijos { get; set; }
        public Bebida[] values { get; set; }
        public Nodo(int grado, bool posicion)
        {
            if (posicion)
            {

                values = new Bebida[(4 / 3) * grado - 1];
                hijos = new int[grado];
            }
            else
            {
                values = new Bebida[grado - 1];
                hijos = new int[grado];
            }
        }
        #region Escritura en texto
        public void Escritura(int dato)
        {
            string path = @"c:\temp\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {

                    //  sw.Write("[{0}],[{1}],[{2}],[{3}],[{4}]", values[dato].Nombre,values[dato].Precio,values[dato].Sabor,values[dato].);

                }
            }
        }
        #endregion
    }
}
