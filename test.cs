using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PF
{
    public partial class test : Form
    {
        public static int numero = 1;

        public test()
        {
            InitializeComponent();
            numero = 0;
            //ListaProducto.BackColor = Color.Beige;
            ListaProducto.DrawMode = DrawMode.OwnerDrawFixed;
            ListaProducto.DrawItem += new DrawItemEventHandler(ListaProducto_DrawItem);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scanner.Enabled = false;

            if (numero == 1) {
                pictureBox1.Left = pictureBox1.Left + 3;
                if (pictureBox1.Left >= 300)
                {
                    timer1.Enabled = false;
                    Console.Beep();
                }
            }

            if (numero == 2)
            {
                pictureBox2.Left = pictureBox2.Left + 3;
                if (pictureBox2.Left >= 300)
                {
                    timer1.Enabled = false;
                    Console.Beep();
                }
            }

            if (numero == 3)
            {
                pictureBox3.Left = pictureBox3.Left + 3;
                if (pictureBox3.Left >= 300)
                {
                    timer1.Enabled = false;
                    Console.Beep();
                }
            }

            if (numero == 4)
            {
                pictureBox4.Left = pictureBox4.Left + 3;
                if (pictureBox4.Left >= 300)
                {
                    timer1.Enabled = false;
                    Console.Beep();
                }
            }

            if (timer1.Enabled == false)
            {
                scanner.Enabled=true;
                pictureBox1.Location = new System.Drawing.Point(-49, 25);
                pictureBox2.Location = new System.Drawing.Point(-49, 25);
                pictureBox3.Location = new System.Drawing.Point(-49, 25);
                pictureBox4.Location = new System.Drawing.Point(-49, 25);
            }
        }

        private void scanner_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            Random r = new Random();

            //ListaProducto.Items.Add("- XXXXXX " + (r.Next(1,100)) + " Bs");

            numero = r.Next(1,4);

            var index = this.dataGridView2.Rows.Add();
            dataGridView2.Rows[index].Cells[0].Value = "XXXXXX";
            dataGridView2.Rows[index].Cells[1].Value = (r.Next(1, 100)) + " Bs";

            //numero++;
        }

        private void test_Load(object sender, EventArgs e)
        {
            ListaProducto.Items.Add("                              [ FACTURA ] ");

            ListaProducto.Items.Add("NIF: ****** ");
            ListaProducto.Items.Add("CLIENTE: XXXXXX ");
            ListaProducto.Items.Add("EMITIDA: ");
            ListaProducto.Items.Add("        Fecha: " + DateTime.Now.ToLongDateString().ToString());
            ListaProducto.Items.Add("        Hora: " + DateTime.Now.ToLongTimeString().ToString());
            
        }

        private void ListaProducto_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Brush myBrush = Brushes.White;

                string sayi = ((ListBox)sender).Items[e.Index].ToString();
                if (sayi.Equals("                              [ FACTURA ] "))
                {
                    myBrush = Brushes.Red;
                }
                else
                {
                    if (sayi.Contains("X"))
                    {
                        myBrush = Brushes.Blue;
                    }
                    else
                    {
                        myBrush = Brushes.Green;
                    }
                }
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch
            {

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
