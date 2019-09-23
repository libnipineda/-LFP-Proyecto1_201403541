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
                        if (aux.Equals("grafica")) { tipo = 1; continue; }
                        else if (aux.Equals("continente")) { tipo = 2; continue; }
                        else if (aux.Equals("pais")) { tipo = 3; continue; }
                        else if (aux.Equals("poblacion")) { tipo = 4; continue; }
                        else if (aux.Equals("saturacion")) { tipo = 5; continue; }
                        else if (aux.Equals("bandera")) { tipo = 6; continue; }
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

                    case 3:                        
                        if (aux.Equals("nombre")) { temp = true; }
                        if (temp)
                        {
                            if (ListaA[i].tkn.Equals("Cadena"))
                            {
                                nomp = ListaA[i].lexema;
                                temp = false;
                                Datos();
                                tipo = tipo - 1;
                                tipo = 0;
                            }
                        }
                        break;

                    case 4:
                        temp = true;
                        if (temp)
                        {
                            if (ListaA[i].tkn.Equals("Numero."))
                            {
                                pob = aux;
                                temp = false;
                                Datos();
                                tipo = tipo - 1;
                                tipo = 0;
                            }
                        }                       
                        break;

                    case 5:
                        temp = true;
                        if (temp)
                        {
                            if (ListaA[i].tkn.Equals("Numero."))
                            {
                                satu = aux;
                                temp = false;
                                Datos();
                                tipo = tipo - 1;
                                tipo = 0;
                            }
                        }                        
                        break;

                    case 6:
                        temp = true;
                        if (temp)
                        {
                            if (ListaA[i].tkn.Equals("Cadena"))
                            {
                                url = aux;
                                temp = false;
                                Datos();
                                tipo = tipo - 1;
                                tipo = 0;
                            }
                        }                        
                        break;
                }
            }
            return ListaC;
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
        }

        public void Datos()
        {
            if (nomp != null && pob != null && satu != null && url != null)
            {
                Pais pais = new Pais(nomp, Convert.ToInt32(pob), Convert.ToInt32(satu), url);
                ListaP.Add(pais);

                Console.WriteLine("Valores obtenidos para la clase pais.");
                Console.WriteLine("nombre pais: " + nomp);
                Console.WriteLine("poblacion: " + pob);
                Console.WriteLine("saturacion: " + satu);
                Console.WriteLine("bandera: " + url);
            }
        }        

    }
}