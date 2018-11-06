using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Compilla
{
    class Program
    {
        public listaEnlazada lista = new listaEnlazada();
        public AnalizadorLexic depurado = new AnalizadorLexic();
        public AnalizadorSintactic Analizando = new AnalizadorSintactic();

        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.depurado.ReemplazarContenido();
           // Console.WriteLine("Hola raza ");
            pr.Analizando.AnalizadorL(pr.depurado.lineas);
        }


    }
}
