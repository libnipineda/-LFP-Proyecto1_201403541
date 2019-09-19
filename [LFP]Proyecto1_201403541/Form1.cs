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

namespace _LFP_Proyecto1_201403541
{
    public partial class Form1 : Form
    {
        int a;

        public Form1()
        {
            InitializeComponent();            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            RichTextBox archivos = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            abrir.Filter = "Documento | *.ORG";
            abrir.Title = "Abrir Documento";
            abrir.FileName = "Sin titulo";
            var dato = abrir.ShowDialog();
            if (dato == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                archivos.Text = leer.ReadToEnd();
                leer.Close();
                tabControl1.SelectedTab.Text = abrir.SafeFileName;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RichTextBox archivo = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            StreamWriter file = new StreamWriter("C:\\Users\\libni\\OneDrive\\Escritorio\\" + "Archivo" + ".ORG");
            file.Write(archivo.Text);
            MessageBox.Show("Archivo guardado en escritorio", "Guardar");
            file.Close();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox archivo = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (MessageBox.Show("Desea Guardar los cambios", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "Documento|*.ORG";
                guardar.Title = "Guardar Archivo";
                guardar.FileName = "Sin Titulo";
                var dato = guardar.ShowDialog();
                if (dato == DialogResult.OK)
                {
                    StreamWriter escribir = new StreamWriter(guardar.FileName);
                    foreach (Object line in archivo.Lines)
                    {
                        escribir.WriteLine(line);
                    }
                    escribir.Close();
                }
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "LFP PROYECTO No.1\n Uzzi Libni Aarón Pineda Solórzano\n 201403541",
               "Acerca de...");
            try
            {
                System.Diagnostics.Process aux = new System.Diagnostics.Process();
                aux.StartInfo.FileName = "E:\\Lenguajes\\Segundo_semestre\\[LFP]Proyecto1_201403541\\Manual de Usuario.pdf";
                aux.Start(); aux.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al encontrar manual de usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir de la aplicación", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pintar();
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            Scanner enviar = new Scanner();
            enviar.Lexico(texto.Text);
            enviar.Reporte1();
            enviar.Reporte2();

            Imagen imagen = new Imagen();
            imagen.Graficar(enviar.ListaC); // Enviar el listado de los nodos.
            imagen.AbrirG();

            string acceso = @"C:\\Users\\libni\\OneDrive\\Escritorio\\Imagen\\imagen.png";
            // mostrar la imagen creada en el picturebox
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap picture = new Bitmap(acceso);

            pictureBox1.Image = (Image)picture;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage pagina = new TabPage(); // Crea la pestaña
            RichTextBox rich = new RichTextBox(); // Crea la superficie donde se ingresan los datos
            rich.Width = 418;
            rich.Height = 760;
            rich.Name = "Pestaña " + a.ToString(); //Carga el nombre del archivo en la pestaña
            rich.Location = new Point(-4, 0);
            pagina.Name = "Pestaña " + a.ToString();
            pagina.Text = "Pestaña " + a.ToString();
            pagina.Controls.Add(rich);
            this.tabControl1.TabPages.Add(pagina); // agrega la pestaña
            this.tabControl1.SelectedTab = pagina; // agrega la superficie donde se ingresan los datos
            a++; //Contador para generar pestañas

            List<Listas> ListaA = new List<Listas>();
            List<Elista> ListaB = new List<Elista>();

            ListaA.Clear();
            ListaB.Clear();
        }

        // Codigo para pintar las palbras        
        string valor; int indice;

        public void Pintar()
        {
            string comparar = richTextBox1.Text;
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];

            valor = "grafica";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "nombre";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "continente";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "pais";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "poblacion";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "saturacion";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "bandera";
            indice = texto.Text.IndexOf(valor);
            pintaReservadas(indice, comparar);

            valor = "0";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "1";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "2";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "3";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "4";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "5";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "6";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "7";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "8";
            indice = texto.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "9";
            indice = richTextBox1.Text.IndexOf(valor);
            pintaNumeros(indice, comparar);

            valor = "{";
            indice = richTextBox1.Text.IndexOf(valor);
            pintaLlaves(indice, comparar);

            valor = "}";
            indice = richTextBox1.Text.IndexOf(valor);
            pintaLlaves(indice, comparar);

            valor = ";";
            indice = richTextBox1.Text.IndexOf(valor);
            pintaPunto_C(indice, comparar);
        }

        public void pintaReservadas(int pintar, String comparar)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            indice = pintar + valor.Length - 1;
            try
            {
                texto.Select(pintar, valor.Length);
                texto.SelectionColor = Color.Blue;
                texto.SelectionStart = texto.Text.Length;

                comparar = texto.Text.Substring(pintar + valor.Length);
                pintar = comparar.IndexOf(valor) + pintar + valor.Length;

                if (pintar != indice)
                {
                    pintaReservadas(pintar, comparar);
                }
                else
                {
                    indice = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en metodo pintaReservadas");
            }
        }

        public void pintaNumeros(int pindice, String comparar)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            try
            {
                indice = pindice + valor.Length - 1;

                texto.Select(pindice, valor.Length);
                texto.SelectionColor = Color.Green;
                texto.SelectionStart = texto.Text.Length;

                comparar = texto.Text.Substring(pindice + valor.Length);
                pindice = comparar.IndexOf(valor) + pindice + valor.Length;

                if (pindice != indice)
                {
                    pintaNumeros(pindice, comparar);
                }
                else
                {
                    indice = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en metodo pintaNumeros");
            }
        }

        public void pintaLlaves(int pindice, String comparar)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            try
            {
                indice = pindice + valor.Length - 1;

                texto.Select(pindice, valor.Length);
                texto.SelectionColor = Color.Red;
                texto.SelectionStart = texto.Text.Length;

                comparar = texto.Text.Substring(pindice + valor.Length);
                pindice = comparar.IndexOf(valor) + pindice + valor.Length;

                if (pindice != indice)
                {
                    pintaLlaves(pindice, comparar);
                }
                else
                {
                    indice = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en metodo pintaNumeros");
            }
        }

        public void pintaPunto_C(int pindice, String comparar)
        {
            RichTextBox texto = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            try
            {
                indice = pindice + valor.Length - 1;

                texto.Select(pindice, valor.Length);
                texto.SelectionColor = Color.Orange;
                texto.SelectionStart = texto.Text.Length;

                comparar = texto.Text.Substring(pindice + valor.Length);
                pindice = comparar.IndexOf(valor) + pindice + valor.Length;

                if (pindice != indice)
                {
                    pintaPunto_C(pindice, comparar);
                }
                else
                {
                    indice = 0;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en metodo pintaNumeros");
            }
        }
        
    }
}