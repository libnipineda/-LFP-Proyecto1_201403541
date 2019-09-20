using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Proyecto1_201403541
{
    class Imagen
    {
        string ruta;
        StringBuilder grafo;

        public Imagen()
        {
            ruta = @"C:\\Users\\libni\\OneDrive\\Escritorio";
        }

        private void Generardot(String rdot, String rpng)
        {
            System.IO.File.WriteAllText(rdot, grafo.ToString());
            String comandoDot = "dot.exe -Tpng " + rdot + " -o " + rpng;
            var comando = string.Format(comandoDot);
            var proStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
            var procedimiento = new System.Diagnostics.Process();

            procedimiento.StartInfo = proStart;
            procedimiento.Start();
            procedimiento.WaitForExit();
        }

        string start, cont, a,s;

        public void Graficar(Object datos)
        {
            List<Continente> con = (List<Continente>)datos;            

            grafo = new StringBuilder();
            String rdot = ruta + "\\Imagen\\imagen.dot";
            String rpng = ruta + "\\Imagen\\imagen.png";

            grafo.Append("digraph structs{");
            //grafo.Append("rankdir = TB;");
            //grafo.Append("node [shape = record];");
            foreach (Continente temp in con)
            {
                start = temp.Grafica;
                cont = temp.Nombre;

                grafo.Append(start + "->" + cont + ";");
                List<Pais> aux = temp.ListaPais1;
                for (int i = 0; i < aux.Count; i++)
                {
                    a = aux[i].Nombre;
                    s = Convert.ToString(aux[i].Saturacion);

                    grafo.Append(cont + "->" + a + ";");
                    grafo.Append(a + "[shape=record label=\"{" + a + "|" + s + "}\"style=filled]");
                }

                grafo.Append(start + "[shape=Mdiamond];");
                grafo.Append(cont + "[shape=record style=filled];");
            }            
            grafo.Append("}");
            this.Generardot(rdot, rpng);
        }

        public void AbrirG()
        {
            if (File.Exists(ruta + "\\Imagen\\imagen.png"))
            {
                try
                {
                    //System.Diagnostics.Process.Start(ruta + "\\Imagen\\imagen.png");
                    MessageBox.Show("Imagen Creada Correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error " + e, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error no existe la ruta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}