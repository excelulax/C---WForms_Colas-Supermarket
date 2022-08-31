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
    public partial class Persona : UserControl
    {
        public Persona()
        {
            InitializeComponent();
        }

        public string Numero { get { return tbnumero.Text; } set { tbnumero.Text = value; } }

        public void Normal()
        {
            pictureBox1.Image = Properties.Resources.cariitolleno;
        }

        public void Adulto()
        {
            pictureBox1.Image = Properties.Resources.baston;
        }
        public void Embarazo()
        {
            pictureBox1.Image = Properties.Resources.carritobb;
        }
    }
}
