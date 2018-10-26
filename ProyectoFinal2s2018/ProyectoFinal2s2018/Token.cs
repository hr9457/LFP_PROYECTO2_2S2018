using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal2s2018
{
    class Token
    {
        //variables de almacenamiento
        private String lexema;
        private String idToken;
        private int linea;
        private int columna;

        //contructor con parametros
        public Token(String lexema,String idToken,int linea,int columna)
        {
            this.lexema = lexema;
            this.idToken = idToken;
            this.linea = linea;
            this.columna = columna;
        }

        //metodos get y set
        public String getLexema()
        {
            return lexema;
        }
        public void setLexema(String lexema)
        {
            this.lexema = lexema;
        }
        public String getIdToken()
        {
            return idToken;
        }
        public void setIdToken(String idToken)
        {
            this.idToken = idToken;
        }
        public int getLinea()
        {
            return linea;
        }
        public void setLinea(int linea)
        {
            this.linea = linea;
        }
        public int getColumna()
        {
            return columna;
        }
        public void setColumna(int columna)
        {
            this.columna = columna;
        }

    }
}
