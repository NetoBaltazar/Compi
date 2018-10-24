using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Compilla
{
    class Depurador
    {
        List<string> obtener = new List<string>();
        public StreamReader leer_archivo;
        public StreamReader leer;
        public void ReemplazarContenido()
        {
            
            leer_archivo = new StreamReader(@"C:\Users\jose_\source\repos\Compilador\Compilla\Leer.txt");
            StreamWriter Modificado = File.CreateText(@"C:\Users\jose_\source\repos\Compilador\Compilla\Leido.Neto");
            string linea;
            string leer = leer_archivo.ReadLine();
            try
            {
                linea = leer_archivo.ReadLine();

                while (linea != null)
                {
                    
                    linea = linea.Replace("\t", string.Empty);
                    linea = linea.Replace("\t\t", string.Empty);
                    linea = linea.Replace("\n", string.Empty);
                    linea = linea.Replace("  ", " ");
                    while (linea.Equals(string.Empty))
                    {

                       linea = leer_archivo.ReadLine();
                        if (linea == null)
                        {
                            break;
                        }
                    }
                    linea = linea.Replace("  ", " ");
                    for (int i = 0; i < linea.Length; i++)
                    {
                        if ((linea[i] == '/' && linea[i + 1] == '/'))
                        {
                            if (i > 1)
                            {
                                string cadena = "";
                                for (int j = 0; j < i; j++)
                                {
                                    cadena += linea[j];
                                }
                                linea = cadena;
                                linea = linea.Replace("  ", " ");
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
                            i = 0;
                        }
                        if (linea == string.Empty)
                        {
                            
                            linea = leer_archivo.ReadLine();
                           
                        }
                        linea = linea.Replace("  ", " ");
                    }
                    linea = linea.Replace("  ", " ");
                    linea = linea.Trim();
                   Console.WriteLine(linea);
                    Modificado.WriteLine(linea);
                    linea = leer_archivo.ReadLine();
                    
                   
                }
               
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
