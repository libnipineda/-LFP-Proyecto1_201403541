using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LFP_Proyecto1_201403541
{
    class Html
    {
        string tabla = "";
        string Etabla = "";

        public void ReporteTKN(List<Listas> datos)
        {
            if (datos.Count != 0)
            {
                for (int i = 0; i < datos.Count; i++)
                {
                    tabla = tabla + "<tr>"
                      + "<td><strong>" + datos[i].numero + "</strong></td>"
                      + "<td><strong>" + datos[i].lexema + "</strong></td>"
                      + "<td><strong>" + datos[i].idtkn + "</strong></td>"
                      + "<td><strong>" + datos[i].tkn + "</strong></td>"
                      + "<td><strong>" + datos[i].fila + "</strong></td>"
                      + "<td><strong>" + datos[i].columna + "</strong></td>"
                      + "</tr>";
                }
            }

            string[] texto = { "<html>"
                    ,"<head>"
                ,"<title>TABLA DE TOKEN'S</title>"
                ,"</head>"
                ,"<body>"
                ,"<h1> LFP PROYECTO NO.1 Listado de Tokens</h1>"
                ,"<table border>"
                ,"<tr>"
                ,"<td><strong>No</strong></td>"
                ,"<td><strong>Lexema</strong></td>"
                ,"<td><strong>ID_Token</strong></td>"
                ,"<td><strong>Token</strong></td>"
                ,"<td><strong>Fila</strong></td>"
                ,"<td><strong>Coluna</strong></td>"
                ,"</tr>"
                ,tabla
                ,"</table>"
                ,"</body>"
                ,"</html> "
                };
            System.IO.File.WriteAllLines(@"C:\Users\libni\OneDrive\Escritorio\ReporteToken.html", texto);
        }

        public void ReporteETKN(List<Elista> valor)
        {
            if (valor.Count != 0)
            {
                for (int i = 0; i < valor.Count; i++)
                {
                    Etabla = Etabla + "<tr>"
                        + "<td><strong>" + valor[i].num + "</strong></td>"
                        + "<td><strong>" + valor[i].fil + "</strong></td>"
                        + "<td><strong>" + valor[i].col + "</strong></td>"
                        + "<td><strong>" + valor[i].lex + "</strong></td>"
                        + "<td><strong>" + valor[i].Etkn + "</strong></td>"
                        + "</tr>";
                }
            }

            string[] text = { "<html>"
                ,"<head>"
                ,"<title>TABLA DE ERRORES</title>"
                ,"</head>"
                ,"<body>"
                ,"<h1> LFP PROYECTO NO.1 Listado de Errores</h1>"
                ,"<table border>"
                ,"<tr>"
                ,"<td><strong>No</strong></td>"
                ,"<td><strong>Fila</strong></td>"
                ,"<td><strong>Columna</strong></td>"
                ,"<td><strong>Caracter</strong></td>"
                ,"<td><strong>Descripcion</strong></td>"
                ,"</tr>"
                ,Etabla
                ,"</table>"
                ,"</body>"
                ,"</html> " };
            System.IO.File.WriteAllLines(@"C:\Users\libni\OneDrive\Escritorio\ReporteError.html", text);
        }
    }
}
