using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilla
{
    class GuardarLista
    {
        Nodo Primero;
        private int size;
/*
        public listaEnlazada()
        {
            this.Primero = null;   // al primer nodo empieza con null
            this.size = 0;
        }

        public Object Lexema(int index)
        {
            int contador = 0;
            Nodo temporal = Primero;
            while (contador < index)
            {
                temporal = temporal.ObtenerSiguente();
                contador++;
            }
            return temporal.ObtenerLexema();
        }

        public Object Id(int index)
        {
            int contador = 0;
            Nodo temporal = Primero;
            while (contador < index)
            {
                temporal = temporal.ObtenerSiguente();
                contador++;
            }
            return temporal.Obtenerid();
        }

        public Object Token(int index)
        {
            int contador = 0;
            Nodo temporal = Primero;
            while (contador < index)
            {
                temporal = temporal.ObtenerSiguente();
                contador++;
            }
            return temporal.ObtenerToken();
        }

        public Object Tipo(int index)
        {
            int contador = 0;
            Nodo temporal = Primero;
            while (contador < index)
            {
                temporal = temporal.ObtenerSiguente();
                contador++;
            }
            return temporal.ObtenerTipo();
        }

        public Object Valor(int index)
        {
            int contador = 0;
            Nodo temporal = Primero;
            while (contador < index)
            {
                temporal = temporal.ObtenerSiguente();
                contador++;
            }
            return temporal.ObtenerValor();
        }

        public void listaVacia()  /// metodo para saber si tiene datos la lista
        {
            if (Primero == null)
            {
                Console.WriteLine("Lista vacia");
            }
            else
            {
                Console.WriteLine("Lista no esta vacia");
            }
        }

        public void aadNodo(Object id, Object token, Object tipo, Object lexema, Object valor)  /// agregando nuevos nodos
        {
            if (Primero == null)
            {
                Primero = new Nodo(id, token, tipo, lexema, valor);

            }
            else
            {
                Nodo temp = Primero;
                Nodo nuevo = new Nodo(id, token, tipo, lexema, valor);
                nuevo.enlazarNext(temp);
                Primero = nuevo;
            }
            size++;
            //se crea una variable nuevo de tipo nodo donde se almacena el dato
            /// crece el tamanio del nod   
        }

        public int Size()
        {
            return size;
        }
        */
    }
}
