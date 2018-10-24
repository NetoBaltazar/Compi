using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Compilla
{
    class AnalizadorLexic
    {
        public int blanco = 0, contL = 0, rescont=0, diagonal = 0,cp=0;
        public StreamReader leer_archivo;
        public void ReemplazarContenido()
        {
            leer_archivo = new StreamReader(@"C:\Users\jose_\source\repos\Compilador\Compilla\Leer.txt");
            StreamWriter Modificado = File.CreateText(@"C:\Users\jose_\source\repos\Compilador\Compilla\Leido.Neto");
            string linea;

           // string leer = leer_archivo.ReadLine();
            try
            {
                linea = leer_archivo.ReadLine();
                while (linea != null)
                {
                   
                    //Quita lineas en blanco
                    while (linea == string.Empty)
                    {
                        blanco++;
                        linea = leer_archivo.ReadLine();
                        if (linea == null)
                        {
                            break;
                        }

                    }
                    if (linea == null)
                    {
                        break;
                    }
                    //linea = linea.Replace("^\r|\n\r|\n$", "");

                    //Quitar los comentarios
                    for (int i = 0; i < linea.Length; i++)
                    {
                        if (linea[i] == '/' && linea[i + 1] == '/')
                        {
                            diagonal++;
                            if (i > 1)
                            {
                                string cadena = "";
                                for (int j = 0; j < i; j++)
                                {
                                    cadena += linea[j];
                                }
                                linea = cadena;
                                break;
                            }
                            else
                            {
                                linea = leer_archivo.ReadLine();
                                if (linea == null)
                                {
                                    break;
                                }
                            }
                            i = -1;
                        }
                    }
                    if (linea == null || linea.Equals(string.Empty))
                    {
                        break;
                    }
                    else
                    {
                        contL++;
                    }


                    // Quita los tabuladores
                    //linea = linea.Replace(@"\t\s", string.Empty);
                    //  linea = Regex.Replace(linea, @"\t+\s+", string.Empty);
                    //Quita espacios en blanco y solo deja una
                    //linea = Regex.Replace(linea, @"\s+", "");
                    //quita espacio en blanco al principio 

                    Console.WriteLine(linea);
                    Modificado.WriteLine(linea);
                    linea = leer_archivo.ReadLine();
                }
                rescont = contL - diagonal + blanco;
                Console.WriteLine("contador  linea " + contL + " Contador Blanco " + blanco + " diagonal " + diagonal + " Resultado " + rescont);
                leer_archivo.Close();
                Modificado.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }
           
        }
    }
}
