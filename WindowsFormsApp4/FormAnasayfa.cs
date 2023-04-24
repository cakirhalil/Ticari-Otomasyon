using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace WindowsFormsApp4
{
    public partial class FormAnasayfa : Form
    {
        public FormAnasayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD AS 'ÜRÜN',sum(ADET) as 'Miktar' from TBL_URUNLER " +
                "group by URUNAD having sum(ADET)<=100 order by URUNAD  ", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ajanda()
        {
            SqlDataAdapter da = new SqlDataAdapter("select top 5 TARIH,SAAT,BASLIK FROM TBL_NOTLAR " +
                "order by ID desc  ", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void firmaHareketler()
        {
            SqlDataAdapter da = new SqlDataAdapter("exec firmaHareket2", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void fihrist()
        {
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 AS 'TELEFON' FROM TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }

        private void FormAnasayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            firmaHareketler();
            fihrist();

            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");
            

        }
    }
}
