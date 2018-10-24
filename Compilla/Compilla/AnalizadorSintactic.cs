﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
//jose Ernesto Baltazar Torres
//Marco Antonio Aguilar Anguiano
namespace Compilla
{
    class AnalizadorSintactic
    {
        Error copiError = new Error();
        string[] Save = new string[8] { "cadena", "entero", "boleano", "caracter","imp","leer","ciclo","si"};
        public StreamReader leer;
        public int cont = 0,caso=1;
        public bool existe = false,acceso=false,existe2=false;
        public listaEnlazada ListaEn = new listaEnlazada();
        public int contador = 0, opc = 0, contVar = 0,contador2=0;
        public string reservada = "", variable = "",valor="",copiArchivo="";
        public AnalizadorLexic liz = new AnalizadorLexic();

        public void AnalizadorL()
        {
            leer = new StreamReader(@"C:\Users\jose_\source\repos\Compilador\Compilla\Leido.Neto");
           string archivo = leer.ReadLine();
            try
            {
                //int copiares = liz.rescont;
                while (archivo != null && archivo != "")
                {
                    contador++;               
                    char[] Cadena = archivo.ToCharArray();
                    reservada = "";
                    variable = "";
                    valor = "";
                    //contador = liz.cp;
                    if (caso==1)
                    {
                        Regex la_chida = new Regex(@"^[a-z A-Z]+[ ]+([a-z A-Z 0-9]+[;])$");
                        if (la_chida.IsMatch(archivo))
                        {
                            for (int i = 0; i < Cadena.Length-1; i++)
                            {
                                if (Cadena[i] == ' ')
                                {
                                       for (int j = i + 1; j < Cadena.Length-1; j++)
                                       {
                                           variable += Cadena[j];  //concatena las variables 
                                       }   
                                    Case1();
                                    //metodo para validar palabra reservada    
                                }
                                else
                                {
                                    reservada += Cadena[i];  // concatena las palabras reservadas                             
                                }
                            }
                        }
                        else
                        {
                            Regex lachida2 = new Regex(@"^[a-z A-Z]+[ ]+([=]{1})[ ]+[a-z A-Z 0-9]+[;]$");
                            if (lachida2.IsMatch(archivo))
                            {

                                for (int i = 0; i < Cadena.Length-1; i++)
                                {
                                    if (Cadena[i] == ' ')
                                    {
                                        if (Cadena[i + 1] == '=')
                                        {
                                            if (Cadena[i+2]==' ')
                                            {
                                                for (int j = i + 3; j < Cadena.Length-1; j++)
                                                {
                                                    valor += Cadena[j];
                                                    
                                                    //concatena las valores
                                                }
                                                Case2(reservada);
                                                //metodo para validar para verificar la varibale 
                                            }
                                        }
                                             
                                    }
                                    else
                                    {
                                        reservada += Cadena[i];  // concatena las palabras reservadas                             
                                    }
                                    
                                }

                            }
                            else
                            {
                                opc = 2;
                                copiError.ListaError(opc, archivo, contador);
                            }

                        }

                    }
                    else
                    {
                        if (caso==2)
                        {
                            Regex Variar = new Regex(@"^[a-z A-Z]+[ ]+([=]{1})[ ]+[a-z A-Z 0-9]+[;]$");
                            if (Variar.IsMatch(archivo))
                            {
                                for (int i = 0; i < Cadena.Length - 1; i++)
                                {
                                    if (Cadena[i] == ' ')
                                    {
                                        if (Cadena[i + 1] == '=')
                                        {
                                            for (int j = i + 3; j < Cadena.Length - 1; j++)
                                            {
                                                valor += Cadena[j];
                                                //concatena las valores
                                            }
                                            Case2(reservada);
                                            //metodo para validar para verificar la varibale  
                                        }
                                       
                                    }
                                    else
                                    {
                                        reservada += Cadena[i];  // concatena las palabras reservadas                             
                                    }
                                }
                            }
                            else
                            {
                                //validacion para el caso 3
                                Regex inputCaso3 = new Regex(@"^[a-z]+[ ]+[( # a-z  > < = A-Z |.*? ) ;]+$");
                                if (inputCaso3.IsMatch(archivo))
                                {
                                    for (int i = 0; i < Cadena.Length; i++)
                                    {
                                        if (Cadena[i] == ' ')
                                        {
                                            copiArchivo = archivo;         ///obtener el primer valor de la cadena
                                            caso3(reservada, copiArchivo);
                                            i = Cadena.Length;
                                        }
                                        else
                                        {
                                            reservada += Cadena[i];  // concatena las palabras reservadas                             
                                        }
                                    }
                                }
                                else
                                {
                                    opc = 2;
                                    copiError.ListaError(opc,archivo,contador);
                                }
                                

                            }
                           
                        }
                    }
                    archivo = leer.ReadLine();  ///salta de linea del archivo
                   // Console.WriteLine(caso);
                }
                  Prinft();

            }
            catch (Exception ex)
            {
                Console.WriteLine("hey " + ex.Message);
            }
            Console.ReadLine();
        }
       public void Case1() ///Declaracion
       {
       ValidarpalabraR(reservada, variable, contador); //////Cuerpo de las variables
       }
      public void Case2(String v) ////Asignacion
      {
            caso = 2;
            if (ListaEn.Buscar(reservada) != null)   ///condcion para las variables si existen declaradas
            {
                ListaEn.buscartipo(v); ///metodo en creado en listas enlazadas para buscar los tipos de datos
                if (ListaEn.copiTipo.Equals("entero"))
                {
                    Regex paraEntero = new Regex(@"^[0-9]+$");
                    ListaEn.buscarTipoEntrante(valor); ///metodo para ver que tipo de valor entra si es entero, cadena, bool etc
                    if (paraEntero.IsMatch(valor) || ListaEn.copiInput.Equals("entero"))
                    {
                        ListaEn.modificar(ListaEn.copilexema, valor); ///metodo para modificar los valores
                        //Console.WriteLine("el tipo es entero: " + valor);
                    }
                    else
                    {
                        opc = 7;
                        copiError.ListaError(opc, valor, contador);
                    }
                }
                else
                {
                    if (ListaEn.copiTipo.Equals("cadena"))
                    {
                        if (valor=="falso" || valor=="verdadero")
                        {
                            opc = 8;
                            copiError.ListaError(opc,v,contador);
                        }
                        else
                        {
                            Regex paraCadena = new Regex("^[a-z A-Z]+$");
                            ListaEn.buscarTipoEntrante(valor);
                            if (paraCadena.IsMatch(valor) && ListaEn.copiInput.Equals("cadena"))
                            {
                                ListaEn.modificar(ListaEn.copilexema, valor); //metodo para modicar los valores de cadenas

                            }
                            else
                            {
                                opc = 8;
                                copiError.ListaError(opc, v, contador);
                                //Agregar los errores a la lista de errores 
                            }
                        }
                       
                    }
                    else
                    {
                        if (ListaEn.copiTipo.Equals("boleano"))
                        {
                          
                            ListaEn.buscarTipoEntrante(valor);
                            if ((valor == "verdadero" || valor=="falso")|| ListaEn.copiInput.Equals("boleano"))
                            {
                                ListaEn.modificar(ListaEn.copilexema, valor); //metodo para modicar los valores de cadenas

                            }
                            else
                            {
                                opc = 10;
                                copiError.ListaError(opc,v,contador);
                                //Agregar los errores a la lista de errores 
                            }

                        }
                        else
                        {
                            {
                                Regex paraCadena = new Regex("^[a-z A-Z]+$");
                                ListaEn.buscarTipoEntrante(valor);
                                if (paraCadena.IsMatch(valor) || ListaEn.copiInput.Equals("caracter"))
                                {
                                    ListaEn.modificar(ListaEn.copilexema, valor); //metodo para modicar los valores de cadenas

                                }
                                else
                                {
                                    Console.WriteLine("Error de asignacion en caracter " + valor);
                                    //Agregar los errores a la lista de errores 
                                }
                            }
                        }
                    }
                }
            }
            else
            {

                opc = 6;
                //Error no existe la palabra reservada
                copiError.ListaError(opc, reservada, contador);

            }

        }
        public void caso3(string v,string archivo)
        {
            String GuarVar = "";
            if (v.Equals("imp"))
            {
                Regex paraImprimir = new Regex(@"^[a-z]+[ ]+[(](([#]+([a-z A-Z 0-9]|.*?)+[#])|([a-zA-Z0-9]))+[)]+[;]$");  //validacio en imprimir
                if (paraImprimir.IsMatch(archivo))
                {
                    //Console.WriteLine("Entro a imprimir " + v);
                }
                else
                {
                    opc = 12;
                    copiError.ListaError(opc,archivo,contador);
                }
            }
            else
            {
                if (v.Equals("leer"))
                {
                    Regex paraLeer = new Regex(@"^[a-z]+[ ]+[a-z A-Z]+[;]$");
                    if (paraLeer.IsMatch(archivo))
                    {
                        for (int i = 0; i < archivo.Length - 1; i++)
                        {
                            if (archivo[i] == ' ')
                            {
                                 for (int j = i + 1; j < archivo.Length - 1; j++)
                                  {
                                   GuarVar += archivo[j];  //concatena las variables 
                                  }
                                if (ListaEn.Buscar(GuarVar)!=null)
                                {
                                    ListaEn.editarLectura(GuarVar,"v");  //edita el valor de entrada
                                }
                                else
                                {
                                    opc = 9;
                                    copiError.ListaError(opc,GuarVar,contador);
                                }
                                    
                            }

                        }
                        //Console.WriteLine("Entro a leer");
                    }
                    else
                    {
                        opc = 11;
                        copiError.ListaError(opc,archivo,contador);
                       
                    }

                }
                else
                {
                    if (v.Equals("si"))
                    {
                       /* string dato1="";
                        string dato2 = "";
                        int k = 0;*/
                        Regex paraSi = new Regex(@"^[a-z]+[ ]+[(]+[a-z A-Z 0-9]+((\b)[> < >= <= ==]{1,2})+([a-z A-Z]+)+[)]$");
                        if (paraSi.IsMatch(archivo))
                        {
                           /* for (int i = 0; i < archivo.Length - 1; i++)
                            {
                                if (archivo[i] == ' ')
                                {
                                    if (archivo[i + 1] == '(')
                                    {
                                        for (int j = i + 2; j < archivo.Length - 1; j++)
                                        {
                                            if ((archivo[j] != '>' && archivo[j]!='=' && archivo[j]!='<'))
                                            {
                                              dato2 += archivo[j];
                                              k = 1;
                                            }
                                            else
                                            {
                                                if (k==1)
                                                {
                                                 dato1= dato2;
                                                 dato2 = "";
                                                }
                                                k = 0;
                                            }

                                        }
                                        
                                    }
                                } 

                            }
                            ///madar el metodo buscar para ver si son iguales los tipos de datos
                            //ListaEn.buscartipo(dato1); ListaEn.buscarTipoEntrante(dato2);
                           if (ListaEn.copiTipo.Equals(ListaEn.copiInput))
                            {
                                //Console.WriteLine("Son iguales");
                            }
                            else
                            {   ////Error de tipos de datos
                                opc = 13;
                                copiError.ListaError(opc,archivo,contador);
                            }*/

                        }
                        else
                        {
                            opc = 11;
                            copiError.ListaError(opc,archivo,contador);
                        }

                    }
                    else
                    {
                        if (v.Equals("ciclo"))
                        {
                            Regex paraCliclo = new Regex(@"^[a-z]+[ ]+[(]+[a-z A-Z]+[> < >= <= ==]+([a-z A-Z]+)+[)]$");
                            if (paraCliclo.IsMatch(archivo))
                            {
                                //Console.WriteLine("Entro a ciclo");
                            }
                            else
                            {
                                opc = 11;
                                copiError.ListaError(opc, archivo, contador);
                            }
                           
                        }
                        else
                        {
                            opc = 11;
                            copiError.ListaError(opc,v,contador);
                        }
                       
                    }
                }
                
            }
           
        }
        public void ValidarpalabraR(String reservada, String variable, int contador) ////metodo para validar palabra reservada
        {
            Regex validarpalabraR = new Regex("^[a-z]+$"); ///se valida la palabra reservada
            if (validarpalabraR.IsMatch(reservada))
            {
                for (int i = 0; i < Save.Length; i++)
                {
                    if (reservada.Equals(Save[i]))     ///se compara la palabra reservada con el arreglo de palabras reservadas
                    {
                        existe = true;
                        i = Save.Length;
                    }
                    else
                    {
                        if (i == Save.Length - 1)
                        {
                            existe = false;
                        }
                    }
                }

                if (existe.Equals(true))
                {
                    if (reservada.Equals("entero")|| reservada.Equals("cadena")|| reservada.Equals("caracter")|| reservada.Equals("boleano"))
                    {
                      Variables(reservada, variable, contador); ////varidar la veriable
                    }
                        
                }
               else
                {
                    opc = 1;
                    //Error no existe la palabra reservada
                    copiError.ListaError(opc, reservada, contador);

                }

            }
            else
            {
                opc = 2;
                ///Error de sintaxis en palabra reservada
                copiError.ListaError(opc, reservada, contador);
            }
        }
        public void Variables(String reservada, String variable, int contador)
        {
            Regex validarVariable = new Regex("^[A-Z a-z]+(|[0-9+]+(|[A-Z a-z]+))$"); ///se valida la variable

            if (reservada.Equals("entero"))
            {
                if (validarVariable.IsMatch(variable))
                {
                    // Console.WriteLine("Variable "+variable+" de tipo entero");
                    ExplorarTipoDatos(reservada,variable,contador);  
                }
           
            }
            else
            {
                if (reservada.Equals("cadena"))
                {
                    if (validarVariable.IsMatch(variable))
                    {
                        // Console.WriteLine("Variable "+variable+" de tipo cadena");
                        ExplorarTipoDatos(reservada, variable, contador);
                    }

                }
                else
                {
                    if (reservada.Equals("caracter"))
                    {
                        if (validarVariable.IsMatch(variable))
                        {
                            //Console.WriteLine("Variable "+ variable+" de tipo caracter");
                            ExplorarTipoDatos(reservada, variable, contador);
          
                        }

                    }
                    else
                    {
                        if (reservada.Equals("boleano"))
                        {
                            if (validarVariable.IsMatch(variable))
                            {
                                //  Console.WriteLine("Variable "+variable+" de tipo Bool");
                                ExplorarTipoDatos(reservada, variable, contador);
                            }

                        }
                    }

                }
            }

        }
        public void Prinft()//// imprime  los datos de la lista enlazada
        {
            Console.WriteLine("id  Lectura  Tipo  Lexema  Valor");
            ListaEn.imprimirLista();
        }
        
        public void ExplorarTipoDatos(String reservada,String variable, int contador) /// validacion de varibale
        {
            if (ListaEn.Buscar(variable)!=null)
            {
                opc = 5;
                copiError.ListaError(opc,variable,contador);
            }
            else
            {
                for (int i = 0; i < Save.Length; i++)
                {
                    if (variable != Save[i])  //ferificar que no sea de tipo palabra reservada
                    {
                        acceso = true;
                    }
                    else
                    {
                        acceso = false;
                        i = Save.Length;
                    }
                }
            }
            
            if (acceso.Equals(true))
            {
               
            ListaEn.aadNodo(contador, "f", reservada, variable, contador); // almacena los tipos de variables

            }
            else
            {
                opc = 3;
                copiError.ListaError(opc, variable, contador);
            }
        }
    }
}