using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Proyecto1_201403541
{
    class Listas
    {
        public int numero = 0;
        public string lexema = "";
        public int idtkn = 0;
        public string tkn = "";
        public int fila = 0;
        public int columna = 0;

        public Listas(int numero, string lexema, int idtkn, string tkn, int fila, int columna)
        {
            this.numero = numero;
            this.lexema = lexema;
            this.idtkn = idtkn;
            this.tkn = tkn;
            this.fila = fila;
            this.columna = columna;
        }
    }

    class Elista
    {
        public int num = 0;
        public int fil = 0;
        public int col = 0;
        public string lex = "";
        public string Etkn = "";
    }

    class Informacion
    {
        public string nombreg;
        public string nombrec;
        public string nombrep;
        public int poblacion;
        public int saturacion;
        public string url;
    }
}