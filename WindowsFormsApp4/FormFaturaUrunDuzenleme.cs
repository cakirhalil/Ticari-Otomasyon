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
    public partial class FormFaturaUrunDuzenleme : Form
    {
        public FormFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public string urunid;

        private void FormFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunId.Text = urunid;

            SqlCommand komut = new SqlCommand("select * from TBL_FATURADETAY where FATURAURUNID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUrunAd.Text = dr[1].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtFiyat.Text = dr[3].ToString();
                txtTutar.Text = dr[4].ToString();

                bgl.baglanti().Close();
            }

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURADETAY set " +
                "URUNAD=@p1,MIKTAR=@p2,FIYAT=@p3,TUTAR=@p4 where FATURAURUNID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p5", txtUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura detay bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Fatura detayını silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtUrunId.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura detayı sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
