using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto1_201403541
{
    class Funcionalidad
    {
        public List<Pais> ListaP = new List<Pais>();
        public List<Continente> ListaC = new List<Continente>();

        string nomgraf, nomcon, nomp, pob, satu, url;

        int tipo = 0;
        /* valores que puede tomar la variable tipo
         * 1: nombre de la grafica.
         * 2: nombre del continente.
         * 3: nombre del pais.
         * 4: poblacion.
         * 5: saturacion.
         * 6: imagen de la bandera (es decir direccion URL).
        */

        Boolean temp = false;

        public List<Continente> ObtenerInfo1(List<Listas> ListaA)
        {            
            for (int i=0; i < ListaA.Count; i++)
            {
                string aux = ListaA[i].lexema;
                switch (tipo)
                {
                    case 0:
                        if (aux.Equals("grafica")) { tipo = 1; }
                        else if (aux.Equals("continente")) { tipo = 2; }                        
                        break;

                    case 1:
                        if (aux.Equals("nombre")) { temp = true; }
                        if (temp)
                        {
                            if (ListaA[i].tkn.Equals("Cadena"))
                            {
                                nomgraf = ListaA[i].lexema;
                                temp = false;
                                tipo = tipo - 1;
                                tipo = 0;
                            }
                        }
                        break;

                    case 2:
                        if (aux.Equals("nombre")) { temp = true; }
                        if (temp)
                        {
                            if (ListaA[i].tkn.Equals("Cadena"))
                            {                                
                                nomcon = ListaA[i].lexema;
                                temp = false;
                                ListarDatosC();
                                tipo = tipo - 1;
                                tipo = 0;
                            }
                        }
                        break;                    
                }
            }
            return ListaC;
        }

        public List<Pais> ObtenerInfo2(List<Listas> ListaB)
        {
            for (int i = 0; i < ListaB.Count; i++)
            {
                string aux = ListaB[i].lexema;
                switch (tipo)
                {
                    case 0:
                        if (aux.Equals("pais")) { tipo = 1; }
                        else if (aux.Equals("poblacion")) { tipo = 2; temp = true; }
                        else if (aux.Equals("saturacion")) { tipo = 3; temp = true; }
                        else if (aux.Equals("bandera")) { tipo = 4; temp = true; }
                        break;
                    case 1:
                        if (aux.Equals("nombre")) { temp = true; }
                        if (temp)
                        {
                            if (ListaB[i].tkn.Equals("Cadena"))
                            {
                                nomp = ListaB[i].lexema;
                                temp = false;
                                AgregarDatos();
                                tipo = tipo - 1;
                                tipo = 0;
                            }
                        }
                        break;

                    case 2:
                        if (temp)
                        {
                            if (ListaB[i].tkn.Equals("Numero."))
                            {
                                i--;
                                pob = ListaB[i].lexema;
                                AgregarDatos();
                                tipo = tipo - 1;
                                tipo = 0;
                                temp = false;
                            }
                        }
                        break;

                    case 3:
                        if (temp)
                        {
                            if (ListaB[i].tkn.Equals("Numero."))
                            {
                                satu = ListaB[i].lexema;
                                AgregarDatos();
                                tipo = tipo - 1;
                                tipo = 0;
                                temp = false;
                            }
                        }
                        break;

                    case 4:
                        if (temp)
                        {
                            if (ListaB[i].tkn.Equals("Cadena"))
                            {
                                url = ListaB[i].lexema;
                                AgregarDatos();
                                tipo = tipo - 1;
                                tipo = 0;
                                temp = false;
                            }
                        }
                        break;
                }
            }
            return ListaP;
        }

        public void ListarDatosC()
        {
            if (nomcon != null)
            {
                Continente con = new Continente(nomgraf, nomcon);
                ListaC.Add(con);

                //Console.WriteLine("Valores Agregados a la clase Continente.");
                //Console.WriteLine("nombre grafica: " + nomgraf);
                //Console.WriteLine("nombre continente: " + nomcon);
            }
            else
            { Console.WriteLine("No hay valores a agregar en la lista de continente."); }
        }

        public void AgregarDatos()
        {
            if (nomp != null && pob != null && satu != null && url != null)
            {
                Pais pais = new Pais(nomp, Convert.ToInt32(pob), Convert.ToInt32(satu), url);
                ListaP.Add(pais);

                //Console.WriteLine("Valores obtenidos para la clase pais.");
                //Console.WriteLine("nombre pais: " + nomp);
                //Console.WriteLine("poblacion: " + pob);
                //Console.WriteLine("saturacion: " + satu);
                //Console.WriteLine("bandera: " + url);
            }
            else { Console.WriteLine("No hay valores a agregar en la lista de paises."); }
        }        

    }
}