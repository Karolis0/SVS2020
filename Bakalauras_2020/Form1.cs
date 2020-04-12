using Bakalauras_2020.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakalauras_2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
            MessageBox.Show("INITIALIZING BASETEMPLATE");
            BTpl x = new BTpl();
            x.Show();
            
        }
    }
}
