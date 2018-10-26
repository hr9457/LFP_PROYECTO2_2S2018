using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoFinal2s2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPrincipal.ScrollBars = ScrollBars.Both;
            txtPrincipal.WordWrap = false;
        }

        private String cadena;
        private AnalizadorLexico analisisLexico;
        private AnalizadorSintatico analisisSintatico;
        private void BtnAnalizar_Click(object sender, EventArgs e)
        {
            analisisLexico = new AnalizadorLexico();
            analisisSintatico = new AnalizadorSintatico();
            cadena = txtPrincipal.Text;
            analisisLexico.automa(cadena);
            analisisSintatico.Parsear(analisisLexico.getTokens(),analisisLexico.getErrorestokens());
        }


        //apertura de archivos
        OpenFileDialog buscador = new OpenFileDialog();
        string ruta;
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (buscador.ShowDialog() == DialogResult.OK)//buscador.ShowDialog(); dialogo para la busqueda del archivo
            {
                ruta = buscador.FileName;//guardando la ruta del archivo
            }
            //lectura del archivo 
            try//manejo de excepciones
            {
                StreamReader leer = new StreamReader(ruta);
                while (!leer.EndOfStream)                    //lee hasta el ultimo elemento del archivo
                {
                    string lectura = leer.ReadToEnd();       //lectura de todo el archivo
                    txtPrincipal.Text = lectura;             //mandando al cuadro de texto
                }
                leer.Close();
            }
            catch (IOException ioex)
            {
                throw new IOException("ha ocurrdio un error con el archivo", ioex);
            }
        }

        //cierre del programa
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            analisisLexico.mostrarReporteToken();
            System.Diagnostics.Process.Start("Reportetoken.html");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            File.WriteAllText(ruta,txtPrincipal.Text);
        }

        private void btnGraphviz_Click(object sender, EventArgs e)
        {

            String path = Directory.GetCurrentDirectory();
            String archivoTXT = "t.txt";
            //System.Diagnostics.Process.Start(archivoTXT);
            try
            {
                //var command = string.Format("dot -Tjpg {0} -o {1}",Path.Combine(path,archivoTXT),Path.Combine(path,archivoTXT.Replace(".txt",".jpg")));
                var command2 = string.Format("dot -Tpng t.txt -o t.png");
                var proStarInfo = new System.Diagnostics.ProcessStartInfo("cmd","/C"+command2);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = proStarInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro tipo" + ex);
            }
            System.Diagnostics.Process.Start("t.png");

        }
    }
}
