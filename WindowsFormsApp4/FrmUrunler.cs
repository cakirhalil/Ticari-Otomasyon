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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_URUNLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
        void temizle()
        {
            txtad.Text = "";
            txtmarka.Text = "";
            txtmodel.Text = "";
            mtbyil.Text = "";
            rtbdetay.Text = "";
            nudadet.Value = 0;
            txtalisfiyat.Text = "";
            txtsatisfiyat.Text = "";
            txtid.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //verileri kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER" +
                "(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtmarka.Text);
            komut.Parameters.AddWithValue("@p3", txtmodel.Text);
            komut.Parameters.AddWithValue("@p4", mtbyil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nudadet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtalisfiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtsatisfiyat.Text));
            komut.Parameters.AddWithValue("@p8", rtbdetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ürün sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Ürünü silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_URUNLER where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("ürün sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["ID"].ToString();
            txtad.Text = dr["URUNAD"].ToString();
            txtmarka.Text = dr["MARKA"].ToString();
            txtmodel.Text = dr["MODEL"].ToString();
            mtbyil.Text = dr["YIL"].ToString();
            nudadet.Value = decimal.Parse( dr["ADET"].ToString());
            txtalisfiyat.Text = dr["ALISFIYAT"].ToString();
            txtsatisfiyat.Text = dr["SATISFIYAT"].ToString();
            rtbdetay.Text = dr["DETAY"].ToString();

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set " +
                "URUNAD=@p1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 where ID=@P9",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtmarka.Text);
            komut.Parameters.AddWithValue("@p3", txtmodel.Text);
            komut.Parameters.AddWithValue("@p4", mtbyil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((nudadet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtalisfiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtsatisfiyat.Text));
            komut.Parameters.AddWithValue("@p8", rtbdetay.Text);
            komut.Parameters.Add("@p9", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ürün bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

       

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
