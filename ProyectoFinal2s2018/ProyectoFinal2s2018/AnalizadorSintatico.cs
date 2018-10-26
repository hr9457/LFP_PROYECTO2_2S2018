using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoFinal2s2018
{
    class AnalizadorSintatico
    {
        int numPreanalisis;
        Token preanalisis;
        List<Token> listTokens;
        //variables para el listado de error sintaticos
        private int numeroError;
        private String lexema;
        private int linea;
        private int fila = 1;
        private int columna = 1; 
        List<ListaErrores> errorSintaticos;
        StreamWriter escritura;//archivo para graficar
        //constructor
        public void Parsear(List<Token> list,List<ListaErrores> list2)
        {
            //this.errorSintaticos = new List<ListaErrores>();//incializacion del listado de error sintatico
            escritura = File.CreateText("t.txt");//archivo para la grafica de carpetas
            escritura.WriteLine("digraph G{");
            listTokens = list;
            errorSintaticos = list2;
            listTokens.Add(new Token("", "UltimoToken", 0, 0));
            preanalisis = list.ElementAt(0);
            numPreanalisis = 0;
            S();
        }

        void S()
        {
            MessageBox.Show("Cadena Reconocida");
            CR();
        }

        void CR()
        {
            if (preanalisis.getIdToken().Equals("tk_CrearEstructura"))
            {
                match("tk_CrearEstructura");
                match("tk_llaveIzq");
                U();
            }
        }


        
        void U()
        {
            match("tk_ComillaSimple");
            match("tk_Ubicacion");
            match("tk_ComillaSimple");
            R();
        }

        //para ruta de las carpetas
        String ubicacion_carpetas;
        String ubucacion_carpetas2;
        void R()
        {
            match("tk_DosPuntos");
            match("tk_Comillas");
            ubicacion_carpetas = @"" + preanalisis.getLexema();
            ubucacion_carpetas2 = @"" + preanalisis.getLexema();
            match("tk_Ruta");
            match("tk_Comillas");
            if (preanalisis.getIdToken().Equals("tk_Coma"))
            {
                match("tk_Coma");
                E();
            }
            else
            {
                match("tk_llaveDer");
            }
        }


        void E()
        {
            match("tk_ComillaSimple");
            match("tk_Estructura");
            match("tk_ComillaSimple");
            match("tk_DosPuntos");
            match("tk_llaveIzq");
            if (preanalisis.getIdToken().Equals("tk_<Carpeta>"))
            {
                C();
                match("tk_llaveDer");
                escritura.WriteLine("}");
                escritura.Close();
            }
            else if (preanalisis.getIdToken().Equals("tk_llaveDer"))
            {
                match("tk_llaveDer");
                escritura.WriteLine("}");
                escritura.Close();
                if (preanalisis.getIdToken().Equals("tk_Coma"))
                {
                    match("tk_Coma");
                    if (preanalisis.getIdToken().Equals("tk_CrearEstructura"))
                    {
                        CR();
                    }
                    else if (preanalisis.getIdToken().Equals("tk_LeerArchivo"))
                    {
                        LEERARCHIVO();
                    }
                }
            }
        }

        //creacion de carpetas
        void C()
        {
            match("tk_<Carpeta>");
            DE();
            match("tk_</Carpeta>");
            escritura.WriteLine(""+signo);//para graficos
            signo2="";//para graficos
            signo="";//para graficos
            preCarpeta="";
            if (preanalisis.getIdToken().Equals("tk_<Carpeta>"))
            {
                C();
            }
            ubicacion_carpetas = ubucacion_carpetas2;
        }


        //para ir agregando carpetas
        String nombreCarpeta;
        void DE()
        {
            match("tk_Comillas");
            creacionCarpetas();//metodo para crear carpetas
            match("tk_Declaracion");
            match("tk_Comillas");
            if (preanalisis.getIdToken().Equals("tk_<Carpeta>"))
            {
                //escritura.WriteLine(signoEscritura);
                C();
            }
            else if (preanalisis.getIdToken().Equals("tk_<Archivo>"))
            {
                AR();
                extensionArchivo = "";
            }
        }



        //variables para la creacion del contenido de los archivos
        String archivo;
        String nombreArchivo;
        String extensionArchivo;
        String puntoExtencionArchivo;
        String textoParaArchivo="";
        void AR()
        {
            match("tk_<Archivo>");
            NO();
            EX();
            if (preanalisis.getIdToken().Equals("tk_<Texto>"))
            {
                TXT();
            }
            
            try
            {
                archivo = ubicacion_carpetas + @"\" + nombreArchivo + "" + puntoExtencionArchivo + "" + extensionArchivo;
                using (File.Create(archivo)) ;
                File.WriteAllText(archivo,textoParaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error tipo" + ex);
            }
            match("tk_</Archivo>");
        }



        
        void NO()
        {
            match("tk_<Nombre>");
            match("tk_Comillas");
            nombreArchivo = preanalisis.getLexema();
            match("tk_Declaracion");
            match("tk_Comillas");
            match("tk_</Nombre>");
        }



        
        void EX()
        {
            match("tk_<Extension>");
            puntoExtencionArchivo = preanalisis.getLexema();
            match("tk_Punto");
            extensionArchivo = preanalisis.getLexema();
            match("tk_ExtensionArchivo");
            match("tk_</Extension>");
        }



        
        void TXT()
        {
            match("tk_<Texto>");
            match("tk_Comillas");
            textoParaArchivo = preanalisis.getLexema();
            match("tk_Declaracion");
            match("tk_Comillas");
            match("tk_</Texto>");
            if (preanalisis.getIdToken().Equals("tk_<Texto>"))
            {
                TXT();
            }
        }



        void LEERARCHIVO()
        {
            match("tk_LeerArchivo");
            match("tk_llaveIzq");
            match("tk_ComillaSimple");
            match("tk_Ubicacion");
            match("tk_ComillaSimple");
            match("tk_DosPuntos");
            match("tk_Comillas");
            match("tk_Ruta");
            match("tk_Comillas");
        }

        void match(String tipo)
        {
            if (!tipo.Equals(preanalisis.getIdToken()))
            {
                MessageBox.Show("Error Sintactico se esperaba " + tipo);
                errorSintaticos.Add(new ListaErrores(""+tipo,"Erro Sintatico",fila,0));
                return;
                return;
                return;
                return;
                return;
                return;
            }

            if (!preanalisis.getIdToken().Equals("UltimoToken"))
            {
                numPreanalisis++;
                preanalisis = listTokens.ElementAt(numPreanalisis);
            }


        }

        String signo2 = "";
        String signo = "";
        String preCarpeta="";
        //metodo para agregar a la lista de errrores
        public void creacionCarpetas()
        {
            nombreCarpeta = preanalisis.getLexema();//AGARA EL NOMBRE DE LA CARPETA
            escritura.WriteLine(""+signo2);
            escritura.WriteLine("\""+nombreCarpeta+"\"");
            escritura.WriteLine(""+signo);
            signo = ";";
            if(preCarpeta != "")
            {
                escritura.WriteLine("\""+nombreCarpeta+"\"");
                preCarpeta = nombreCarpeta;
            }
            else
            {
                signo2 = "->";
                preCarpeta = nombreCarpeta;
            }
            try
            {
                Directory.CreateDirectory(ubicacion_carpetas + @"\" + nombreCarpeta);
                ubicacion_carpetas = ubicacion_carpetas + "\\" + nombreCarpeta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la ubucacion" + ex);
            }
        }

    }
}
