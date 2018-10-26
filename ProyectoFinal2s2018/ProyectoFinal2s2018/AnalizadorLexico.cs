using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal2s2018
{
    class AnalizadorLexico
    {

        //varialbes de almacenamiento
        private String rutaCreacionEstructura;
        private String rutaLectura;
        private String nombreCarpeta;
        private String textoArchivo;
        private String extensionArchivo;
        private String tokenPalabraReservada;
        private String cadena;
        private char caracter;
        private int puntero;
        private int estado = 0;
        private int largoCadena;
        private int fila = 1;
        private int columna = 1;
        private List<Token> listadoTokens;
        private List<ListaErrores> listadoErrores;
        private char posToken;
        private char preToken;


       

        //metodo contructor
        public AnalizadorLexico()
        {
            this.listadoTokens = new List<Token>();
            this.listadoErrores = new List<ListaErrores>();
        }


        //automa para el analisis lexico
        public void automa(String cadena)
        {
            this.cadena = cadena;
            largoCadena = cadena.Length-1;
            puntero = 0;
            while (puntero <= largoCadena)
            {
                //automata
                caracter = cadena[puntero];
                switch (estado)
                {
                    //esado para signos { } , '
                    case 0:
                        if (caracter.Equals(','))
                        {
                            addToken("" + caracter, "tk_Coma", fila, columna);
                            columna++;
                            estado = 0;
                            puntero++;
                        }
                        else if (caracter.Equals('{'))
                        {
                            addToken("" + caracter, "tk_llaveIzq", fila, columna);
                            estado = 0;
                            puntero++;
                        }
                        else if (caracter.Equals('}'))
                        {
                            addToken("" + caracter, "tk_llaveDer", fila, columna);
                            estado = 0;
                            puntero++;
                        }
                        else if (caracter.Equals('\''))
                        {
                            addToken("" + caracter, "tk_ComillaSimple", fila, columna);
                            columna++;
                            estado = 0;
                            puntero++;
                        }
                        else if (caracter.Equals(':'))
                        {
                            estado = 2;
                        }
                        else if (caracter.Equals('"'))
                        {
                            estado = 3;
                        }
                        else if (caracter.Equals('<'))
                        {
                            estado = 4;
                        }
                        else if (caracter.Equals(' '))
                        {
                            puntero++;
                            columna++;
                            estado = 0;
                        }
                        else if (caracter.Equals('\n'))
                        {
                            puntero++;
                            fila++;
                            columna = 1;
                            estado = 0;
                        }
                        else if (caracter.Equals('\t'))
                        {
                            puntero++;
                            columna++;
                            estado = 0;
                        }
                        else if (caracter.Equals('\r'))
                        {
                            puntero++;
                            estado = 0;
                        }
                        else if (char.IsLetter(caracter))
                        {
                            estado = 1;
                        }
                        else
                        {
                            addErrorToken("" + caracter, "Error Lexio", fila, columna);
                            columna++;
                            estado = 0;
                            puntero++;
                        }
                        break;


                    //estado para letras
                    case 1:
                        if (char.IsLetter(caracter))
                        {
                            tokenPalabraReservada += caracter;
                            puntero++;
                            estado = 1;
                        }
                        else if (caracter.Equals(':'))
                        {
                            estado = 2;
                        }
                        else if (caracter.Equals(',') || caracter.Equals('{') || caracter.Equals('\''))
                        {
                            libreriaPalabrasReservadas(tokenPalabraReservada);
                            tokenPalabraReservada = "";
                            estado = 0;
                        }

                        else if (caracter!='"')
                        {
                            tokenPalabraReservada += caracter;
                            puntero++;
                            estado = 1;
                        }
                        else if (caracter.Equals('"'))
                        {
                            addToken(tokenPalabraReservada, "tk_Declaracion", fila, columna);
                            tokenPalabraReservada = "";
                            estado = 3;
                        }
                        else if (caracter.Equals('}'))
                        {
                            estado = 0;
                        }

                        else if (caracter.Equals(' '))
                        {
                            puntero++;
                            columna++;
                            estado = 1;
                        }
                        else if (caracter.Equals('\n'))
                        {
                            puntero++;
                            fila++;
                            estado = 1;
                        }
                        else if (caracter.Equals('\t'))
                        {
                            puntero++;
                            columna++;
                            estado = 1;
                        }
                        else
                        {
                            addErrorToken("" + caracter, "Error Lexio", fila, columna);
                            estado = 1;
                            puntero++;
                        }
                        break;


                    //estado para dos puntos
                    case 2:
                        if (caracter.Equals(':'))
                        {
                            posToken = cadena[puntero + 1];
                            if (posToken.Equals('\\'))
                            {
                                rutaCreacionEstructura = tokenPalabraReservada;
                                rutaCreacionEstructura += caracter;
                                tokenPalabraReservada = "";
                                puntero++;
                                estado = 2;
                            }
                            else
                            {
                                addToken("" + caracter, "tk_DosPuntos", fila, columna);
                                estado = 2;
                                puntero++;
                            }
                        }
                        else if (caracter.Equals(',') || caracter.Equals('{') || caracter.Equals('}') || caracter.Equals('\''))
                        {
                            estado = 0;
                        }
                        else if (caracter != '"')
                        {
                            rutaCreacionEstructura += caracter;
                            puntero++;
                            estado = 2;
                        }
                        else if (caracter.Equals('"'))
                        {
                            if (rutaCreacionEstructura == null)
                            {
                                estado = 3;
                                fila++;
                            }
                            else
                            {
                                addToken(rutaCreacionEstructura, "tk_Ruta", fila, columna);
                                estado = 3;
                            }
                            
                        }
                        
                        //no contiene estado de error
                        break;


                    //estado para comillas dobles "
                    case 3:
                        if (caracter.Equals('"'))
                        {
                            addToken("" + caracter, "tk_Comillas", fila, columna);
                            estado = 3;
                            puntero++;
                        }
                        else if (char.IsLetter(caracter))
                        {
                            estado = 1;
                        }
                        else if(caracter.Equals(',') || caracter.Equals('{') || caracter.Equals('}') || caracter.Equals('\''))
                        {
                            estado = 0;
                        }
                        else if (caracter.Equals('<'))
                        {
                            estado = 4;
                        }
                        else if (caracter.Equals(' '))
                        {
                            puntero++;
                            columna++;
                            estado = 3;
                        }
                        else if (caracter.Equals('\n'))
                        {
                            puntero++;
                            fila++;
                            columna = 1;
                            estado = 3;
                        }
                        else if (caracter.Equals('\t'))
                        {
                            puntero++;
                            columna++;
                            estado = 3;
                        }
                        else if (caracter.Equals('\r'))
                        {
                            puntero++;
                            estado = 3;
                        }
                        else
                        {
                            addErrorToken("" + caracter, "Error Lexico", fila, columna);
                            estado = 3;
                            puntero++;
                        }
                        break;

                    //estado para <
                    case 4:
                        if (caracter.Equals('<'))
                        {
                            tokenPalabraReservada += caracter;
                            estado = 4;
                            puntero++;
                        }
                        else if(caracter.Equals('/')  || char.IsLetter(caracter))
                        {
                            tokenPalabraReservada += caracter;
                            estado = 4;
                            puntero++;
                        }
                        else if (caracter.Equals('>'))
                        {
                            tokenPalabraReservada += caracter;
                            libreriaPalabrasReservadas(tokenPalabraReservada);
                            tokenPalabraReservada = "";
                            estado = 4;
                            puntero++;
                        }
                        else if (caracter.Equals('"'))
                        {
                            estado = 3;
                        }
                        else if (caracter.Equals(',') || caracter.Equals('{') || caracter.Equals('}') || caracter.Equals('\''))
                        {
                            estado = 0;
                        }
                        else if (caracter.Equals(' '))
                        {
                            puntero++;
                            columna++;
                            estado = 4;
                        }
                        else if (caracter.Equals('\n'))
                        {
                            puntero++;
                            fila++;
                            columna = 1;
                            estado = 4;
                        }
                        else if (caracter.Equals('\t'))
                        {
                            puntero++;
                            columna++;
                            estado = 4;
                        }
                        else if (caracter.Equals('\r'))
                        {
                            puntero++;
                            estado = 4;
                        }
                        else if (caracter.Equals('.'))
                        {
                            estado = 5;
                        }
                        else
                        {
                            addErrorToken("" + caracter, "Error Lexico", fila, columna);
                            estado = 4;
                            puntero++;
                        }

                        break;

                    //estado para punto(.)
                    case 5:
                        if (caracter.Equals('.'))
                        {
                            addToken("" + caracter, "tk_Punto", fila, columna);
                            puntero++;
                            columna++;
                            estado = 5;
                        }
                        else if (char.IsLetter(caracter))
                        {
                            extensionArchivo += caracter;
                            puntero++;
                            estado = 5;
                        }
                        else if (caracter.Equals('<'))
                        {
                            addToken("" + extensionArchivo, "tk_ExtensionArchivo", fila, columna);
                            extensionArchivo = "";
                            estado = 4;
                        }
                        else
                        {
                            addErrorToken("" + caracter, "Error Lexico", fila, columna);
                            puntero++;
                            estado = 5;
                        }
                        break;
                        

                }//fin del switch

            }
        }


        //METODO PARA BUSQUEDA DE PALABRAS RESERVADAS
        public void libreriaPalabrasReservadas(String token)
        {
            switch (token)
            {
                case "CrearEstructura":
                    addToken(tokenPalabraReservada,"tk_CrearEstructura",fila,columna);
                    columna++;
                    break;

                case "Ubicacion":
                    addToken(tokenPalabraReservada, "tk_Ubicacion", fila, columna);
                    columna++;
                    break;

                case "Estructura":
                    addToken(tokenPalabraReservada, "tk_Estructura", fila, columna);
                    columna++;
                    break;

                case "<Carpeta>":
                    addToken(tokenPalabraReservada, "tk_<Carpeta>", fila, columna);
                    columna++;
                    break;

                case "</Carpeta>":
                    addToken(tokenPalabraReservada, "tk_</Carpeta>", fila, columna);
                    columna++;
                    break;

                case "<Archivo>":
                    addToken(tokenPalabraReservada, "tk_<Archivo>", fila, columna);
                    columna++;
                    break;

                case "</Archivo>":
                    addToken(tokenPalabraReservada, "tk_</Archivo>", fila, columna);
                    columna++;
                    break;

                case "<Nombre>":
                    addToken(tokenPalabraReservada, "tk_<Nombre>", fila, columna);
                    columna++;
                    break;

                case "</Nombre>":
                    addToken(tokenPalabraReservada, "tk_</Nombre>", fila, columna);
                    columna++;
                    break;

                case "<Extension>":
                    addToken(tokenPalabraReservada, "tk_<Extension>", fila, columna);
                    columna++;
                    break;

                case "</Extension>":
                    addToken(tokenPalabraReservada, "tk_</Extension>", fila, columna);
                    columna++;
                    break;

                case "<Texto>":
                    addToken(tokenPalabraReservada, "tk_<Texto>", fila, columna);
                    columna++;
                    break;

                case "</Texto>":
                    addToken(tokenPalabraReservada, "tk_</Texto>", fila, columna);
                    columna++;
                    break;

                case "LeerArchivo":
                    addToken(tokenPalabraReservada, "tk_LeerArchivo", fila, columna);
                    columna++;
                    break;

                default:
                    addErrorToken(tokenPalabraReservada, "Error Lexico", fila, columna);
                    columna++;
                    break;
            }
        }//FIN DEL METODO


        //metodo para agregar a la lista de token
        public void addToken(String lexema,String idToken,int linea, int columna)
        {
            Token nuevotoken = new Token(lexema,idToken,linea,columna);
            listadoTokens.Add(nuevotoken); 
        }

        //metodo para agregar a la lista de errores
        public void addErrorToken(String lexema, String idToken, int linea, int columna)
        {
            ListaErrores nuevotoken = new ListaErrores(lexema, idToken, linea, columna);
            listadoErrores.Add(nuevotoken);
        }


        //metodo para el reporte de token
        public void mostrarReporteToken()
        {
            TextWriter archivo;
            archivo = new StreamWriter("Reportetoken.html");
            archivo.WriteLine("<html>");
            archivo.WriteLine("<head><title>Reporte</title></head>");
            archivo.WriteLine("<body>");
            //archivo.WriteLine("<center>");
            archivo.WriteLine("<h1 ALIGN=LEFT >TOKENS</h1>");
            //archivo.WriteLine("</center>");
            //archivo.WriteLine("<center>");
            archivo.WriteLine("<table border=\"6\" bordercolor=\"blue\" ALIGN=LEFT >");
            archivo.WriteLine("<tr>");
            archivo.WriteLine("<td><strong>LEXEMA</strong></td>");
            archivo.WriteLine("<td><strong>IDTOKEN</strong></td>");
            archivo.WriteLine("<td><strong>FILA</strong></td>");
            archivo.WriteLine("<td><strong>COLUMNA</strong></td>");
            archivo.WriteLine("</tr>");
            for (int i = 0; i < listadoTokens.Count; i++)
            {
                Token actual = listadoTokens.ElementAt(i);
                archivo.WriteLine("<tr>");
                archivo.WriteLine("<td><strong>" + actual.getLexema() + "</strong></td>");
                archivo.WriteLine("<td><strong>" + actual.getIdToken() + "</strong></td>");
                archivo.WriteLine("<td><strong>" + actual.getLinea() + "</strong></td>");
                archivo.WriteLine("<td><strong>" + actual.getColumna() + "</strong></td>");
                archivo.WriteLine("</tr>");
            }
            archivo.WriteLine("</table>");
            //archivo.WriteLine("</center>");

            archivo.WriteLine("<h1 ALIGN=RIGHT >ERRORES</h1>");
            archivo.WriteLine("<table border=\"6\" bordercolor=\"blue\" ALIGN=RIGHT >");
            archivo.WriteLine("<tr>");
            archivo.WriteLine("<td><strong>LEXEMA</strong></td>");
            archivo.WriteLine("<td><strong>IDTOKEN</strong></td>");
            archivo.WriteLine("<td><strong>FILA</strong></td>");
            archivo.WriteLine("<td><strong>COLUMNA</strong></td>");
            archivo.WriteLine("</tr>");
            for (int i = 0; i < listadoErrores.Count; i++)
            {
                ListaErrores actual = listadoErrores.ElementAt(i);
                archivo.WriteLine("<tr>");
                archivo.WriteLine("<td><strong>" + actual.getLexema() + "</strong></td>");
                archivo.WriteLine("<td><strong>" + actual.getIdToken() + "</strong></td>");
                archivo.WriteLine("<td><strong>" + actual.getLinea() + "</strong></td>");
                archivo.WriteLine("<td><strong>" + actual.getColumna() + "</strong></td>");
                archivo.WriteLine("</tr>");
            }
            archivo.WriteLine("</table>");
            archivo.Close();
        }


        //devolver lista con todos los tokens
        public List<Token> getTokens()
        {
            return this.listadoTokens;
        }


        //devolver lista de error
        public List<ListaErrores> getErrorestokens()
        {
            return this.listadoErrores;
        }


    }
}
