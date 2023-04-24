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

namespace WindowsFormsApp4
{
    public partial class FormFaturalar : Form
    {
        public FormFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            txtSeri.Text = "";
            txtSiraNo.Text = "";
            txtid.Text = "";
            mtbTarih.Text = "";
            mtbSaat.Text = "";
            txtVergi.Text = "";
            txtAlici.Text = "";
            txtEdilen.Text = "";
            txtAlan.Text = "";
            txtid.Focus();
        }

        private void FormFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //firma carisi  *********************
            if (txtFaturaId.Text == "") 
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI" +
                "(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtSeri.Text);
                komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", mtbTarih.Text);
                komut.Parameters.AddWithValue("@p4", mtbSaat.Text);
                komut.Parameters.AddWithValue("@p5", txtVergi.Text);
                komut.Parameters.AddWithValue("@p6", txtAlici.Text);
                komut.Parameters.AddWithValue("@p7", txtEdilen.Text);
                komut.Parameters.AddWithValue("@p8", txtAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (txtFaturaId.Text != "" && comboBox1.Text == "Firma")
            {
                double miktar, fiyat, tutar;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID)" +
                    " values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse( txtFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //hareket tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER(URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH)" +
                    " values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonelId.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mtbTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //stoktan düşme
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER SET ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Faturaya ait ürün sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //müşteri carisi ***********************
            if (txtFaturaId.Text != "" && comboBox1.Text == "Müşteri")
            {
                double miktar, fiyat, tutar;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID)" +
                    " values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //hareket tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKETLER(URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH)" +
                    " values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonelId.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mtbTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //stoktan düşme
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER SET ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Faturaya ait ürün sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["FATURABILGIID"].ToString();
                txtSeri.Text = dr["SERI"].ToString();
                txtSiraNo.Text = dr["SIRANO"].ToString();
                mtbTarih.Text = dr["TARIH"].ToString();
                mtbSaat.Text = dr["SAAT"].ToString();
                txtVergi.Text = dr["VERGIDAIRE"].ToString();
                txtAlici.Text = dr["ALICI"].ToString();
                txtEdilen.Text = dr["TESLIMEDEN"].ToString();
                txtAlan.Text = dr["TESLIMALAN"].ToString();
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Fatura bilgisini silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_FATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                MessageBox.Show("Fatura bilgisi sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set " +
                "SERI=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRE=@p5,ALICI=@p6,TESLIMEDEN=@p7," +
                "TESLIMALAN=@p8 where FATURABILGIID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtSeri.Text);
            komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", mtbTarih.Text);
            komut.Parameters.AddWithValue("@p4", mtbSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtVergi.Text);
            komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            komut.Parameters.AddWithValue("@p7", txtEdilen.Text);
            komut.Parameters.AddWithValue("@p8", txtAlan.Text);
            komut.Parameters.AddWithValue("@p9", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormFaturaUrunDetay fr = new FormFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select URUNAD,SATISFIYAT FROM TBL_URUNLER WHERE ID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunId.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUrunAd.Text = dr[0].ToString();
                txtFiyat.Text = dr[1].ToString();

            }
            bgl.baglanti().Close();
        }

       
    }
}
