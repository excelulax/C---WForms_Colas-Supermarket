using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PF
{
    public partial class Form1 : Form
    {
        public static int contador = 0;

        public static int contadorAG = 0;
        public static int contadorAA = 0;
        public static int contadorAE = 0;

        
        Queue cola1 = new Queue();
        Queue cola2 = new Queue();
        Queue cola3 = new Queue();


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }


        //--metodo para insertar
        public void insertar(int numerodecola)
        {
            switch (numerodecola)
            {
                case 1:
                    {
                        cola1.Enqueue(contador);
                        PanelPersonas1.Controls.Clear();
                        foreach (object aux in cola1)
                        {
                            Persona h = new Persona();
                            h.Numero = aux.ToString();
                            h.Normal();
                            PanelPersonas1.Controls.Add(h);
                        }
                        break;
                    }
                case 2:
                    {
                        cola2.Enqueue(contador);
                        PanelPersonas2.Controls.Clear();
                        foreach (object aux in cola2)
                        {
                            Persona h = new Persona();
                            h.Numero = aux.ToString();
                            h.Embarazo();
                            PanelPersonas2.Controls.Add(h);
                        }
                        break;
                    }
                case 3:
                    {
                        cola3.Enqueue(contador);
                        PanelPersonas3.Controls.Clear();
                        foreach (object aux in cola3)
                        {
                            Persona h = new Persona();
                            h.Numero = aux.ToString();
                            h.Adulto();
                            PanelPersonas3.Controls.Add(h);
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("error");
                        break;
                    }
            }
            contador++;
        }
        //----

        //para actualizar al quitar un dato
        public void MostrarCola(int numerodecola)
        {

            switch (numerodecola)
            {
                case 1:
                    {
                        PanelPersonas1.Controls.Clear();

                        foreach (object aux in cola1)
                        {
                            Persona h = new Persona();
                            h.Numero = aux.ToString();
                            h.Normal();
                            PanelPersonas1.Controls.Add(h);
                        }
                        break;
                    }
                case 2:
                    {
                        PanelPersonas2.Controls.Clear();

                        foreach (object aux in cola2)
                        {
                            Persona h = new Persona();
                            h.Numero = aux.ToString();
                            h.Embarazo();
                            PanelPersonas2.Controls.Add(h);
                        }
                        break;
                    }
                default:
                    {
                        PanelPersonas3.Controls.Clear();

                        foreach (object aux in cola3)
                        {
                            Persona h = new Persona();
                            h.Numero = aux.ToString();
                            h.Adulto();
                            PanelPersonas3.Controls.Add(h);
                        }
                        break;
                    }
            }
        }
        //----


        //para insertar en cola
        private void TicketCola1_Click(object sender, EventArgs e)
        {
            insertar(1);
            enColaActualizar(1);
            Estadistica();

            //SoundPlayer music = Properties.Resources.;
        }

        private void TicketCola2_Click(object sender, EventArgs e)
        {
            insertar(2);
            enColaActualizar(2);
            Estadistica();
        }

        private void TicketCola3_Click(object sender, EventArgs e)
        {
            insertar(3);
            enColaActualizar(3);
            Estadistica();
        }

        //para la animacion de boton con tiket
        private void TicketCola1_MouseHover(object sender, EventArgs e)
        {
            this.TicketCola1.BackgroundImage = Properties.Resources.ticket;
        }

        private void TicketCola1_MouseLeave(object sender, EventArgs e)
        {
            this.TicketCola1.BackgroundImage = Properties.Resources.registradora;
        }

        private void TicketCola2_MouseHover(object sender, EventArgs e)
        {
            this.TicketCola2.BackgroundImage = Properties.Resources.ticket;
        }

        private void TicketCola2_MouseLeave(object sender, EventArgs e)
        {
            this.TicketCola2.BackgroundImage = Properties.Resources.registradora;
        }

        private void TicketCola3_MouseHover(object sender, EventArgs e)
        {
            this.TicketCola3.BackgroundImage = Properties.Resources.ticket;
        }

        private void TicketCola3_MouseLeave(object sender, EventArgs e)
        {
            this.TicketCola3.BackgroundImage = Properties.Resources.registradora;
        }
        //----

        private void siguientecola1_Click(object sender, EventArgs e)
        {
            if (cola1.Count > 0)
            {
                this.encola1.Text = cola1.Dequeue().ToString();
                MostrarCola(1);
                contadorAG++;
                label1.Text = contadorAG.ToString();

                Cajero();
                Estadistica();
            }
            else
            {
                MessageBox.Show("NO HAY PERSONAS EN COLA");
            }
            enColaActualizar(1);
        }

        private void siguientecola2_Click(object sender, EventArgs e)
        {
            if (cola2.Count > 0)
            {
                this.encola2.Text = cola2.Dequeue().ToString();
                MostrarCola(2);
                contadorAE++;
                label2.Text = contadorAE.ToString();

                Cajero();
                Estadistica();
            }
            else
            {
                MessageBox.Show("NO HAY PERSONAS EN COLA");
            }
            enColaActualizar(2);
        }

        private void siguientecola3_Click(object sender, EventArgs e)
        {
            if (cola3.Count > 0)
            {
                this.encola3.Text = cola3.Dequeue().ToString();
                MostrarCola(3);
                contadorAA++;
                label3.Text = contadorAA.ToString();

                Cajero();
                Estadistica();
            }
            else
            {
                MessageBox.Show("NO HAY PERSONAS EN COLA");
            }
            enColaActualizar(3);
        }
        //----

        //par actualizar los datos en cola
        public void enColaActualizar(int numerodecola)
        {
            switch (numerodecola)
            {
                case 1:
                    {
                        label4.Text = PanelPersonas1.Controls.Count.ToString();
                        break;
                    }
                case 2:
                    {
                        label5.Text = PanelPersonas2.Controls.Count.ToString();
                        break;
                    }
                default:
                    {
                        label6.Text = PanelPersonas3.Controls.Count.ToString();
                        break;
                    }
            }
        }

        //para obetener la fecha y hora
        private void fecha_Tick(object sender, EventArgs e)
        {
            //hora en tiempo real
            lbHora.Text = DateTime.Now.ToLongTimeString();
            //fecha
            lbfecha.Text = DateTime.Now.ToShortDateString();
        }
        //----

        public void Cajero()
        {
            //fondo oscuro
            Form f = new Form();
            using (test f2 = new test())
            {

                f.StartPosition = FormStartPosition.Manual;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Opacity = .70d;
                f.BackColor = Color.Black;
                f.WindowState = FormWindowState.Maximized;
                f.TopMost = true;
                f.Location = this.Location;
                f.ShowInTaskbar = false;
                f.Show();

                //cajero
                f2.TopMost = true;
                f2.StartPosition = FormStartPosition.CenterParent;
                f2.FormBorderStyle = FormBorderStyle.None;
                f2.ShowDialog();
                //--

                f.Dispose();
            }
        }

        //chart
        public void Estadistica()
        {
            //para reset chart graficos
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            chart1.Series["Series1"].Points.AddXY("GENERAL", PanelPersonas1.Controls.Count.ToString());
            chart1.Series["Series1"].Points.AddXY("PREFERENCIAL 1", PanelPersonas2.Controls.Count.ToString());
            chart1.Series["Series1"].Points.AddXY("PREFERECNIAL 2", PanelPersonas3.Controls.Count.ToString());
        }
    }
}
