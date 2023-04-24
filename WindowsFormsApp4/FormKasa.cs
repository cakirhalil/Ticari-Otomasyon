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
using DevExpress.Charts;

namespace WindowsFormsApp4
{
    public partial class FormKasa : Form
    {
        public FormKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void MusteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute MusteriHareketler",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void FirmaHareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("execute FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }

        void Giderler()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR from TBL_GIDERLER", bgl.baglanti());
            da3.Fill(dt3);
            gridControl2.DataSource = dt3;
        }
        public string Ad;
        private void FormKasa_Load(object sender, EventArgs e)
        {
            lblAktifkullanici.Text = Ad;
            MusteriHareket();
            FirmaHareket();
            Giderler();

            //TOPLAM TUTAR:
            SqlCommand komut1 = new SqlCommand("Select sum(TUTAR) from TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamtutar.Text = dr1[0].ToString() +" TL";
            }
            bgl.baglanti().Close();

            //ÖDEMELER:
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //PERSONEL MAAŞ:
            SqlCommand komut3 = new SqlCommand("Select MAASLAR FROM TBL_GIDERLER ORDER BY ID ASC", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelmaas.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //MUSTERI SAYISI:
            SqlCommand komut4 = new SqlCommand("Select COUNT(*) FROM TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblmusterisayi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //FIRMA SAYISI:
            SqlCommand komut5 = new SqlCommand("Select COUNT(*) FROM TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmasayi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //PERSONEL SAYISI:
            SqlCommand komut6 = new SqlCommand("Select COUNT(*) FROM TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblPersonelsayi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //STOK SAYISI:
            SqlCommand komut7 = new SqlCommand("Select SUM(ADET) FROM TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblStoksayi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

        }
        int sayac = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            //elektrik
            if (sayac > 0 && sayac <= 5)
            {
                groupControl6.Text = "Elektrik";
                chartControl1.Series["Aylar"].Points.Clear();               
                SqlCommand komut8 = new SqlCommand("Select top 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr8 = komut8.ExecuteReader();
                while (dr8.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr8[0], dr8[1]));
                }
                bgl.baglanti().Close();
            }
            //su
            if (sayac > 5 && sayac <= 10)
            {
                groupControl6.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //dogalgaz
            if (sayac > 11 && sayac <= 15)
            {
                groupControl6.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //İNTERNET
            if (sayac > 15 && sayac <= 20)
            {
                groupControl6.Text = "İnternet";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //ekstra
            if (sayac > 20 && sayac <= 25)
            {
                groupControl6.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac == 26)
            {
                sayac=0;
            }
        }

        // 2---------------------------------------------------

        int sayac2 = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            //elektrik
            if (sayac2 > 11 && sayac2 <= 15)
            {
                groupControl10.Text = "Elektrik";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut8 = new SqlCommand("Select top 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr8 = komut8.ExecuteReader();
                while (dr8.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr8[0], dr8[1]));
                }
                bgl.baglanti().Close();
            }
            //su
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl10.Text = "Su";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //dogalgaz
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl10.Text = "Doğalgaz";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //İNTERNET
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl10.Text = "İnternet";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            //ekstra
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl10.Text = "Ekstra";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("Select top 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
