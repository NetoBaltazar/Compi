using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilla
{
    class Nodo
    {
        public String lectura, tipo, lexema;
        public int id;
        public Object valor;
        public Nodo siguente;

         public Nodo(int id, String lectura,String tipo, String lexema, Object valor)
         {
             this.valor = valor;
             this.id = id;
             this.lectura = lectura;
             this.tipo = tipo;
             this.lexema = lexema;
             this.siguente = null;

         }

         public void modi(Object valor)
         {
             this.valor = valor;
         }

         public int Obtenerid()
         {
             return id;
         }

         public String ObtenerLectura()
         {
             return lectura;
         }

         public String ObtenerTipo()
         {
             return tipo;
         }

         public String ObtenerLexema()
         {
             return lexema;
         }
         public Object ObtenerValor()
         {
             return valor;
         }

         public void enlazarNext(Nodo n)
         {
             siguente = n;
         }
         public Nodo ObtenerSiguente()
         {
             return siguente;
         }




    }
}
