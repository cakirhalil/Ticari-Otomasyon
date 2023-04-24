using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FormNotDetay : Form
    {
        public FormNotDetay()
        {
            InitializeComponent();
        }

        public string metin;
        public string saat;
        public string tarih;
        private void FormNotDetay_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = metin;
            label3.Text = saat;
            label4.Text = tarih;
        }
    }
}
