using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto1_201403541
{
    class Scanner
    {
        List<Listas> ListaA = new List<Listas>();
        List<Elista> ListaB = new List<Elista>();        
        public List<Continente> ListaC = new List<Continente>();

        int idtkn;
        int nutknen = 0;
        int idtkns = 13; // numero de tokens
        int fila = 1; int columna = 1;
        string token = "";
        String concatenar = ""; String Etoken = "";        

        public void Lexico(string cadena)
        {
            int estado = 0;
            for (int i=0; i < cadena.Length; i++)
            {
                switch(estado)
                {
                    case 0:
                        if (((char)09).Equals(cadena[i]) || ((char)32).Equals(cadena[i])) // tecla tab, espacio
                        {
                            estado = 0;
                        }
                        else if (((char)10).Equals(cadena[i])) // salto de linea
                        {
                            estado = 0; fila++; columna++;
                        }
                        else if (char.IsLetter(cadena[i]))
                        {
                            estado = 1; concatenar += cadena[i]; columna++;
                        }
                        else if (char.IsNumber(cadena[i]))
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)34).Equals(cadena[i]))
                        {
                            estado = 3; concatenar += cadena[i]; columna++;
                        }
                        else if (((char)37).Equals(cadena[i]) || ((char)58).Equals(cadena[i]) || ((char)59).Equals(cadena[i]) || ((char)123).Equals(cadena[i]) || ((char)125).Equals(cadena[i])) // signo porcentaje, dos puntos, punto y coma, llave abierto y llave cerrada.
                        {
                            estado = 4; concatenar += cadena[i]; columna++;
                        }                        
                        else
                        {
                            Etoken += cadena[i];
                            Elista temp = new Elista();
                            temp.num = nutknen;
                            temp.fil = fila;
                            temp.col = columna;
                            temp.lex = "" + Etoken;
                            temp.Etkn = "Valor Desconocido.";
                            ListaB.Add(temp); nutknen++; concatenar = ""; Etoken = "";
                        }
                        break;

                    case 1:
                        if (char.IsLetter(cadena[i]))
                        {
                            estado = 1; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                            AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                            nutknen++; concatenar = "";
                        }
                        break;

                    case 2:
                        if (char.IsNumber(cadena[i]))
                        {
                            estado = 2; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                            AgregarListaA(nutknen, concatenar, 2, "Numero.", fila, columna);
                            nutknen++; concatenar = "";
                        }
                        break;

                    case 3:
                        if (((char)34).Equals(cadena[i])) //Signo de comillas
                        {
                            estado = 6; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 5; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 4:
                        AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                        AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                        nutknen++; concatenar = "";
                        break;

                    case 5:
                        if (((char)34).Equals(cadena[i])) // Signo de comillas
                        {
                            estado = 6; concatenar += cadena[i]; columna++;
                        }
                        else
                        {
                            estado = 5; concatenar += cadena[i]; columna++;
                        }
                        break;

                    case 6:
                        AnalizarTkn(concatenar); i--; estado = estado - 1; estado = 0;
                        AgregarListaA(nutknen, concatenar, idtkn, token, fila, columna);
                        nutknen++; concatenar = "";
                        break;
                }
            }
            MessageBox.Show("Analisis Concluido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AnalizarTkn(string tkn)
        {            
            tkn.Trim();
            tkn.ToLower();
            switch (tkn)
            {
                case "grafica":
                    token = "Palabra Reservada"; idtkn = 1;
                    break;
                case "nombre":
                    token = "Palabra Reservada"; idtkn = 2;
                    break;
                case "continente":
                    token = "Palabra Reservada"; idtkn = 3;
                    break;
                case "pais":
                    token = "Palabra Reservada"; idtkn = 4;
                    break;
                case "poblacion":
                    token = "Palabra Reservada"; idtkn = 5;
                    break;
                case "saturacion":
                    token = "Palabra Reservada"; idtkn = 6;
                    break;
                case "bandera":
                    token = "Palabra Reservada"; idtkn = 7;
                    break;
                case ":":
                    token = "Signo dos puntos"; idtkn = 8;
                    break;
                case "{":
                    token = "Signo llave abierta"; idtkn = 9;
                    break;
                case ";":
                    token = "Signo punto y coma"; idtkn = 10;
                    break;
                case "}":
                    token = "Signo llave cerrada"; idtkn = 11;
                    break;
                case "%":
                    token = "Signo de porcentaje"; idtkn = 12;
                    break;
                case "destino":
                    token = "Palabra reservada"; idtkn = 13;
                    break;
                default:
                    token = "Cadena"; idtkns++; idtkn = idtkns;
                    break;
            }
        }

        public void AgregarListaA(int num, string lexema, int idtkn, string tkn, int fila, int columna)
        {
            Listas aux = new Listas(num, lexema, idtkn, tkn, fila, columna);
            aux.numero = num;
            aux.lexema = lexema.Trim();
            aux.idtkn = idtkn;
            aux.tkn = tkn;
            aux.fila = fila;
            aux.columna = columna;
            ListaA.Add(aux);
        }

        public void Reporte1()
        {
            try
            {
                MessageBox.Show("Espere en un momento se abrira el reporte de token´s", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Html item = new Html();
                item.ReporteTKN(ListaA);
                Process.Start(@"C:\Users\libni\OneDrive\Escritorio\ReporteToken.html");
                EnviarDatos();                
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el reporte de Token´s", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reporte2()
        {
           if (ListaB.Count  != 0)
           {
               Html html = new Html();
               html.ReporteETKN(ListaB);
               Process.Start(@"C:\Users\libni\OneDrive\Escritorio\ReporteError.html");
           }
           else
           {
               MessageBox.Show("No se encontro errores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
           
        }

        public void EnviarDatos()
        {
            Funcionalidad fun = new Funcionalidad();
            ListaC = fun.ObtenerInfo1(ListaA);
        }
    }
}