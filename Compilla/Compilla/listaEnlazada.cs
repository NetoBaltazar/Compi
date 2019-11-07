using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilla
{
    class listaEnlazada
    {
        Nodo Primero;
       public String copiTipo = "",copilexema="",copiInput="";
        private int size;
  
                public listaEnlazada()
                {
                    this.Primero = null;   // al primer nodo empieza con null
                    this.size = 0;
                }

                public String Lexema(int index)
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

                public int Id(int index)
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

                public String Lectura(int index)
                {
                    int contador = 0;
                    Nodo temporal = Primero;
                    while (contador < index)
                    {
                        temporal = temporal.ObtenerSiguente();
                        contador++;
                    }
                    return temporal.ObtenerLectura();
                }

                public String Tipo(int index)
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

                public void aadNodo(int id, String lectura, String tipo, String lexema, Object valor)  /// agregando nuevos nodos
                {
                    if (Primero == null)
                    {
                        Primero = new Nodo(id, lectura, tipo, lexema, valor);
                    }
                    else
                    {
                        Nodo temp = Primero;
                        Nodo nuevo = new Nodo(id,lectura, tipo, lexema, valor);
                        nuevo.enlazarNext(temp);
                        Primero = nuevo;
                    }
                    size++;
                    //se crea una variable nuevo de tipo nodo donde se almacena el dato
                    /// crece el tamanio del nod   
                }

        public void modificar(String lexema,Object asignar)
        {
            Nodo pos = buscartipo(lexema);
            if (pos!=null || pos==null)
            {
                pos.valor = asignar;
            }

        }
        public void editarLectura(String lexema, String asignar)
        {
            Nodo pos = buscartipo(lexema);
            if (pos!=null || pos==null)
            {
                pos.lectura = asignar;
            }
        }
        public Nodo buscarTipoEntrante(String val) /////metodo para verificar si el valor es de tipo correcto
        {
            Nodo p = Primero;
            while (p.siguente!=null || p.siguente==null)
            {
                if (p.lexema.Equals(val))
                {
                    copiInput = p.tipo;
                    return p;
                }
                else
                {
                    if (p.siguente == null)
                    {
                        return null;
                    }
                }
                p = p.siguente;
            }
            return null;
        }
        public Nodo buscartipo(String val)///se busca la variable aver si esta declarada
        {
            Nodo p = Primero;
            while (p.siguente!=null || p.siguente==null)
            {
                if (p.lexema.Equals(val))
                {
                    //Console.WriteLine("entro a tipos: "+ p.tipo);
                    copiTipo = p.tipo;
                    copilexema = p.lexema;
                    return p;
                }
                else
                {
                    if (p.siguente == null)
                    {
                        return null;
                        
                    }
                }
                p = p.siguente;

            }

            return null;
        }

        public void imprimirLista()
        {
            Nodo actual = Primero;
            while (actual!=null)
            {
                Console.WriteLine("["+actual.id+"] ["+actual.lectura +"] [" + actual.tipo + "] [" + actual.lexema + "] [" + actual.valor + "]");
                actual = actual.siguente;
            }
        }
      
        public int Size()
         {
          return size;
        
         }
     
        public Nodo Buscar(String n)
        {
            Nodo p = Primero;
            if (p==null)
            {
                //Console.WriteLine("La lista no tiene datos");
             
            }
            else
            {
                while (p.siguente!=null || p.siguente==null)
                {
                    if (p.lexema.Equals(n))
                    {
                       
                        return p;
                    }
                    else
                    {
                        if (p.siguente==null)
                        {
                            return null;
                        }
                    }
                    p = p.siguente;
                }
            }
            return null;
        }

        
    }
}
