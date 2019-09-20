using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Proyecto1_201403541
{
    class Pais
    {        
        private string nombrep;
        private int poblacion;
        private int saturacion;
        private string bandera;

        public Pais(string nombre, int poblacion, int saturacion, string bandera)
        {            
            this.Nombre = nombrep;
            this.Poblacion = poblacion;
            this.Saturacion = saturacion;
            this.Bandera = bandera;
        }
        
        public string Nombre { get => nombrep; set => nombrep = value; }
        public int Poblacion { get => poblacion; set => poblacion = value; }
        public int Saturacion { get => saturacion; set => saturacion = value; }
        public string Bandera { get => bandera; set => bandera = value; }
    }
}