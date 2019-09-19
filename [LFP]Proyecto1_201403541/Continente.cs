using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Proyecto1_201403541
{
    class Continente
    {
        private string grafica;
        private string nombre;
        private List<Pais> ListaPais;

        public Continente(string grafica,string nombre)
        {
            this.Grafica = grafica;
            this.Nombre = nombre;
            ListaPais1 = new List<Pais>();
        }

        public string Grafica { get => grafica; set => grafica = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Pais> ListaPais1 { get => ListaPais; set => ListaPais = value; }
    }
}