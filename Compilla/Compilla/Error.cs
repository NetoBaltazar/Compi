using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilla
{
    class Error
    {
        public void ListaError(int opc,String reservada, int linea) ///nota: el parametro [reservada] llegan varibales o palabras reservadas
        {
            switch (opc)
            {
               case 1: { Console.WriteLine("Valio No existe la palabra reservada [" + reservada + "]" + " linea " + linea); Console.Read();} break;
               case 2: { Console.WriteLine("Error de sintaxis en la palabra [" + reservada + "]"+" linea "+ linea); Console.Read(); } break;
               case 3: { Console.WriteLine("Error al declarar variable de tipo palabra reservada << " +reservada+" >>" + " linea " + linea); Console.Read(); } break;
               case 4: { Console.WriteLine("Error de sintaxis en la variable << " +reservada+ " >>" + " linea " + linea); Console.Read(); } break;
               case 5: { Console.WriteLine("Error no se pueden repetir la variable << " + reservada + " >>" + " linea " + linea);Console.Read(); } break;
               case 6: { Console.WriteLine("Valio, frase ["+reservada+"] no existe en nuestro lenguaje Animo!!!"+" Linea: "+ linea); Console.Read(); }break;
               case 7: { Console.WriteLine("Error de asignacion en la variable (" + reservada + ") No es compatible con el tipo de dato entero: Linea " + linea); Console.Read(); } break;
               case 8: { Console.WriteLine("Error de asignacion en la variable ("+reservada+") No es compatible con el tipo de dato cadena: Linea "+linea);Console.Read(); }break;
               case 9: { Console.WriteLine("Valio No existe la variable (" + reservada + ")" + " linea " + linea); Console.Read(); } break;
               case 10:{ Console.WriteLine("Error de asignacion en la variable (" + reservada + ") No es compatible con el tipo de dato boleano: Linea " + linea); Console.Read(); } break;
               case 11:{ Console.WriteLine("Error, no existe la palabra  (" + reservada + ") Linea " + linea); Console.Read(); } break;
               case 12:{ Console.WriteLine("Error de sintaxis en la frase "+reservada+" linea "+linea); Console.Read(); }break;
               case 13:{ Console.WriteLine("Error los tipos de datos son distintos " + reservada + " linea " + linea); Console.Read(); } break;

            }
        }
    }
}
