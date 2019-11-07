using System;
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
       public Error copiError = new Error();
        string[] Save = new string[8] { "cadena", "entero", "boleano", "caracter", "imp", "leer", "ciclo", "si" };
        public StreamReader leer;
        public int cont = 0, caso = 1;
        public bool existe = false, acceso = false, existe2 = false;
        public listaEnlazada ListaEn = new listaEnlazada();
        public int contador = 0, opc = 0, contVar = 0,contador2=0;
        public string reservada = "", variable = "", valor = "", copiArchivo = "", capture = "", archivo = "",sav="",archivo2="";
        public AnalizadorLexic liz = new AnalizadorLexic();
        public Dictionary<int, int> hem2 = new Dictionary<int, int>();
        public string cadd = "";
        public StreamReader leer_archivo;
        public string[] arc = new string[50];
        public string[] are = new string[50];
        public int cmaa = 0,otrom=0,otro1=0,otro2=0,ponle=0;

        public void AnalizadorL(Dictionary<int,int> hem)
        {
         
            leer = new StreamReader(@"C:\Users\jose_\source\repos\Compilador\Compilla\Leido.Neto");
            archivo = leer.ReadLine();

            hem2 = hem;
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
                    //Console.WriteLine(archivo);
                     //Console.WriteLine(hem[archivo]);
                    if (caso == 1)
                    {
                        Regex la_chida = new Regex(@"^[a-z A-Z]+[ ]+([a-z A-Z 0-9]+[;])$");
                        Regex inputAcess = new Regex(@"^[a-zA-Z]+[;]$");
                        if (la_chida.IsMatch(archivo) || inputAcess.IsMatch(archivo))
                        {
                            if (inputAcess.IsMatch(archivo))
                            {
                                capture = "";
                                for (int i = 0; i < archivo.Length - 1; i++)
                                {
                                    capture += Cadena[i];
                                }
                                if (capture!="cadena" && capture!="entero" && capture!="boleano")
                                {
                                    ListaEn.buscartipo(capture);
                                    if (ListaEn.copilexema.Equals(this.capture))
                                    {

                                    }
                                    else
                                    {
                                        ///mandar el error con la linea
                                        opc = 9;
                                        copiError.ListaError(opc, archivo, hem2[contador]);

                                    }

                                    
                                }
                                else
                                {
                                    opc = 14;
                                    copiError.ListaError(opc, archivo, hem2[contador]);

                                }
                                
                            }
                            else
                            {
                                for (int i = 0; i < Cadena.Length - 1; i++)
                                {
                                    if (Cadena[i] == ' ')
                                    {
                                        for (int j = i + 1; j < Cadena.Length - 1; j++)
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

                        }
                        else
                        {
                            Regex lachida2 = new Regex(@"^[a-z A-Z]+[ ]+([=]{1})[ ]+[#a-zA-Z0-9]+[;]$");
                            if (lachida2.IsMatch(archivo))
                            {
                                for (int i = 0; i < Cadena.Length - 1; i++)
                                {
                                    if (Cadena[i] == ' ')
                                    {
                                        if (Cadena[i + 1] == '=')
                                        {
                                            if (Cadena[i + 2] == ' ')
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
                                copiError.ListaError(opc, archivo, hem2[contador]);
                            }

                        }

                    }
                    else
                    {
                        if (caso == 2)
                        {
                            Regex Variar = new Regex(@"^[a-zA-Z]+[ ]+([=]{1})[ ]+[#a-zA-Z0-9]+[;]$");
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
                                Regex inputCaso3 = new Regex(@"^[a-z]+[ ]+[( # + a-z  > < = A-Z |.*? )]|[;]$");
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
                                    copiError.ListaError(opc, archivo, hem2[contador]);
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
            leer_archivo = new StreamReader(@"C:\Users\jose_\Desktop\masm\prog_base_compi.asm");
            StreamWriter Modificado = File.CreateText(@"C:\Users\jose_\Desktop\masm\ejec.asm");
            string nuevaL = "";
         
            try
            {
                nuevaL = leer_archivo.ReadLine();
                while (nuevaL!=null)
                {
                    if (nuevaL.Equals("cortar1"))
                    {

                        int a = ListaEn.Size();
                        for (int i = 0; i <a; i++)
                        {
                            if ((ListaEn.Tipo(i)).Equals("cadena"))
                            {

                                if ((ListaEn.Lectura(i).Equals("f")))
                                {
                                    Modificado.WriteLine(ListaEn.Lexema(i)+" db "+"\""+ListaEn.Valor(i)+"$\"");

                                }

                                if ((ListaEn.Lectura(i).Equals("v")))
                                {
                                    Modificado.WriteLine(ListaEn.Lexema(i) + " db " + "50,?,50 dup('$')");

                                }


                            }
                            else
                            {
                                if ((ListaEn.Tipo(i)).Equals("entero"))
                                {
                                    if ((ListaEn.Lectura(i).Equals("f")))
                                    {
                                     Modificado.WriteLine(ListaEn.Lexema(i) + " db " + ListaEn.Valor(i));

                                    }
                                    else
                                    {
                                        Modificado.WriteLine(ListaEn.Lexema(i) + " db " + "50,?,50 dup('$')");
                                    }
                                    

             
                                }
                            }
                            
                        }
                        Console.ReadLine();
                        

                    }
                    else
                    {
                        if (nuevaL.Equals("cortar2"))
                        {
                            
                            for (int i = 0; i < cadd.Length; i++)
                            {
                               
                                if (cadd[i].Equals('I'))
                                {
                          
                                        for (int j = 0; j < ListaEn.Size(); j++)
                                        {

                                            if (are[ponle].Equals(ListaEn.Lexema(j)))
                                            {

                                                if (ListaEn.Lectura(j).Equals("v"))
                                                {
                                                    Modificado.WriteLine("MOV DX,OFFSET " + are[otro1] + "+2");
                                                    Modificado.WriteLine("MOV AH,09");
                                                    Modificado.WriteLine("INT 21H");
                                                    otro1++;

                                                }
                                                else
                                                {
                                                    Modificado.WriteLine("MOV DX,OFFSET " + are[otro1]);
                                                    Modificado.WriteLine("MOV AH,09");
                                                    Modificado.WriteLine("INT 21H");
                                                    otro1++;

                                                }
                                                
                                            }
                                        }
                                    ponle++;
                                }
                                else
                                {
                                    if ((cadd[i].Equals('C')))
                                    {
                                        Modificado.WriteLine("lea dx," + arc[otro2]);
                                        Modificado.WriteLine("mov ah,0Ah");
                                        Modificado.WriteLine("int 21h");
                                        otro2++;
                                    }

                                }
                            }
                            
                        }
                        else
                        {
                            Modificado.WriteLine(nuevaL);
                        }
                    }
                    nuevaL = leer_archivo.ReadLine();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                Console.ReadKey();
            }
            leer_archivo.Close();
            Modificado.Close();


        }
        public void Case1() ///Declaracion
        {

            ValidarpalabraR(reservada, variable, contador, archivo); //////Cuerpo de las variables
        }
        public void Case2(String v) ////Asignacion
        {
            caso = 2;
            if (ListaEn.Buscar(v) != null)   ///condcion para las variables si existen declaradas
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
                        copiError.ListaError(opc, archivo, hem2[contador]);
                    }
                }
                else
                {
                    if (ListaEn.copiTipo.Equals("cadena"))
                    {
                        if (valor == "falso" || valor == "verdadero")
                        {
                            opc = 8;
                            copiError.ListaError(opc, v, hem2[contador]);
                        }
                        else
                        {
                            Regex paraCadena = new Regex(@"^[a-z A-Z 0-9]+$");
                            Regex paraCadena2 = new Regex(@"^(([#]+([a-z A-Z 0-9]|.*?)+[#]))$");
                            if (paraCadena.IsMatch(this.valor) || paraCadena2.IsMatch(this.valor))
                            {
                                if (paraCadena.IsMatch(this.valor))
                                {
                                    ListaEn.buscarTipoEntrante(valor);
                                    if (ListaEn.copiInput.Equals("cadena"))
                                    {
                                        ListaEn.modificar(ListaEn.copilexema, valor); //metodo para modicar los valores de cadenas
                                    }
                                    else
                                    {
                                        opc = 8;
                                        copiError.ListaError(opc, archivo, hem2[contador]);
                                        //Agregar los errores a la lista de errores 
                                    }
                                }
                                else
                                {
                                    if (paraCadena2.IsMatch(valor))
                                    {
                                        ListaEn.modificar(ListaEn.copilexema, valor);
                                    }

                                }


                            }
                            else
                            {
                                opc = 2;
                                copiError.ListaError(opc, archivo, hem2[contador]);

                            }

                        }

                    }
                    else
                    {
                        if (ListaEn.copiTipo.Equals("boleano"))
                        {
                            Regex paraBoleano = new Regex(@"^[a-z]+$");
                            if (paraBoleano.IsMatch(valor))
                            {
                                ListaEn.buscarTipoEntrante(valor);
                                if ((valor == "verdadero" || valor == "falso") || ListaEn.copiInput.Equals("boleano"))
                                {
                                    ListaEn.modificar(ListaEn.copilexema, valor); //metodo para modicar los valores de cadenas

                                }
                                else
                                {
                                    opc = 10;
                                    copiError.ListaError(opc, v, hem2[contador]);
                                    //Agregar los errores a la lista de errores 
                                }

                            }
                            else
                            {
                                opc = 10;
                                copiError.ListaError(opc,v, hem2[contador]);

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

                opc = 9;
                //Error no existe la palabra reservada
                copiError.ListaError(opc, reservada, hem2[contador]);

            }

        }
        public void caso3(string v, string archivo)
        {
            String GuarVar = ""; 
            if (v.Equals("imp"))
            {
                cadd += "I";
                Regex paraImprimir = new Regex(@"^[a-z]+[ ]+[(]{1}(([#]+([a-z A-Z 0-9]|.*?)+[#]|[+])|([a-zA-Z0-9]))+[)]{1}()+[;]$");  //validacio en imprimir
                if (paraImprimir.IsMatch(archivo))
                {
                   Regex impconvar = new Regex(@"^[a-z]+[ ]+[(](([#]+([a-z A-Z 0-9]|.*?)+[#]+[+]+[a-zA-z-9]+[)])+[;])$");
                    if (impconvar.IsMatch(archivo))
                    {
                        int n = 0;
                        for (int i = 0; i < archivo.Length - 1; i++)
                        {
                            if (archivo[i].Equals('#') && archivo[i + 1].Equals('+'))
                            {
                                n++;
                            }
                            if (n == 1)
                            {
                                for (int j = i + 2; j < archivo.Length - 2; j++)
                                {
                                    sav += archivo[j];
                                   
                                }
                               
                                i = archivo.Length;
                            }
                        }
                        
                        ListaEn.buscartipo(this.sav);
                        if (ListaEn.copilexema.Equals(this.sav))
                        {
                           
                            sav = "";
                        }
                        else
                        {
                            opc = 9;
                            copiError.ListaError(opc, this.sav, hem2[contador]);
                        }
                    }
                    else
                    {
                        Regex impvar = new Regex(@"^[a-z]+[ ]+[(]+[a-zA-Z0-9]+[)]+[;]$");
                        if (impvar.IsMatch(archivo))
                        {
                           
                            int n = 0;
                            for (int i = 0; i < archivo.Length - 1; i++)
                            {
                                if (archivo[i].Equals('('))
                                {
                                    n++;
                                }
                                if (n == 1)
                                {
                                    for (int j = i + 1; j < archivo.Length - 2; j++)
                                    {
                                        sav += archivo[j];
                                       
                                        
                                    }
                                   
                                    i = archivo.Length;
                                }
                            }

                            ListaEn.buscartipo(this.sav);
                            if (ListaEn.copilexema.Equals(this.sav))
                            {
                                are[otrom] = sav;
                                sav = "";
                                otrom++;
                              
                            }
                            else
                            {
                              
                                opc = 9;
                                copiError.ListaError(opc, this.sav, hem2[contador]);
                            }
                        }
                       
                    }

                }
                else
                {
                    
                    opc = 12;
                    copiError.ListaError(opc, archivo, hem2[contador]);
                }
            }
            else
            {
                if (v.Equals("leer"))
                {
                    cadd += "C";
                    Regex paraLeer = new Regex(@"^[a-z]+[ ]+[a-zA-Z]+[;]$");
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
                                if (ListaEn.Buscar(GuarVar) != null)
                                {
                                    arc[cmaa] = GuarVar;
                                    ListaEn.editarLectura(GuarVar, "v");  //edita el valor de entrada
                                    cmaa++;
                                    GuarVar = "";
                                }
                                else
                                {
                                    opc = 9;
                                    copiError.ListaError(opc, GuarVar, hem2[contador]);
                                }

                            }

                        }
                        //Console.WriteLine("Entro a leer");

                    }
                    else
                    {
                        opc = 11;
                        copiError.ListaError(opc, archivo, hem2[contador]);

                    }

                }
                else
                {
                    if (v.Equals("si"))
                    {
                       // string oc = "";
                       // bool acceso = false;
                        Regex paraSi = new Regex(@"^[a-z]+[ ]+[(]+[a-zA-Z0-9]+((\b)[> < >= <= ==]{1,2})+([a-zA-Z0-9]+)+[)]$");
                        if (paraSi.IsMatch(archivo))
                        {
                            /*archivo = leer.ReadLine();
                            contador++;
                            if (archivo.Equals("sisi"))
                            {
                                Regex paraImprimir = new Regex(@"^[a-z]+[ ]+[(]{1}(([#]+([a-z A-Z 0-9]|.*?)+[#]|[+])|([a-zA-Z0-9]))+[)]{1}()+[;]$");  //validacio en imprimir
                                oc += "S";
                                do
                                {
                                    contador++;
                                    archivo = leer.ReadLine();
                                    if (paraImprimir.IsMatch(archivo))
                                    {
                                        acceso = true;
                                    }
                                    else
                                    {
                                        if (archivo.Equals("sino"))
                                        {
                                            oc += "I";
                                            acceso = false;
                                        }
                                       
                                    }
                            
                                } while (acceso);


                            }
                            else
                            {
                                Console.WriteLine("Error de sintaxis en"+ archivo);
                            }

                            if (oc.Equals("SIF"))
                            {
                                Console.WriteLine("Esta correcta la sinstaxis");
                            }
                            else
                            {
                                if (oc.Equals("S"))
                                {
                                    Console.WriteLine("Error de Sintaxis en "+ archivo);

                                }
                                else
                                {
                                    if (oc.Equals("SI"))
                                    {
                                        Console.WriteLine("Error de sintaxis falta agregar el fin del si ");
                                    }
                                }
                            }
  */
                          

                        }
                        else
                        {
                            opc = 2;
                            copiError.ListaError(opc, archivo, hem2[contador]);
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
                                copiError.ListaError(opc, archivo, hem2[contador]);
                            }

                        }
                        else
                        {
                            
                            opc = 12;
                            copiError.ListaError(opc, archivo, hem2[contador]);
                        }

                    }
                }

            }

        }
        public void ValidarpalabraR(String reservada, String variable, int contador, String archivo) ////metodo para validar palabra reservada
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
                    if (reservada.Equals("entero") || reservada.Equals("cadena") || reservada.Equals("caracter") || reservada.Equals("boleano"))
                    {
                        Variables(reservada, variable, contador); ////varidar la veriable
                    }

                }
                else
                {
                    opc = 1;
                    //Error no existe la palabra reservada
                    copiError.ListaError(opc, archivo, hem2[contador]);

                }

            }
            else
            {
                opc = 2;
                ///Error de sintaxis en palabra reservada
                copiError.ListaError(opc, archivo, hem2[contador]);
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
                    ExplorarTipoDatos(reservada, variable, contador);
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

        public void ExplorarTipoDatos(String reservada, String variable, int contador) /// validacion de varibale
        {
            if (ListaEn.Buscar(variable) != null)
            {
                opc = 5;
                copiError.ListaError(opc, variable, hem2[contador]);
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
                copiError.ListaError(opc, variable, hem2[contador]);
            }
        }
    }
}