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
    public partial class FormAyarlar : Form
    {
        public FormAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_ADMIN",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FormAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            txtKullaniciadi.Text = "";
            txtSifre.Text = "";
            txtKullaniciadi3.Text = "";
            txtSifre3.Text = "";

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtKullaniciadi.Text = dr["KullaniciAdi"].ToString();
                txtSifre.Text = dr["Sifre"].ToString();
                txtKullaniciadi3.Text = dr["KullaniciAdi"].ToString();
                txtSifre3.Text = dr["Sifre"].ToString();


            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_ADMIN set " +
                "Sifre=@p1 where KullaniciAdi=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtSifre.Text);
            komut.Parameters.AddWithValue("@p2", txtKullaniciadi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_ADMIN" +
                "(KullaniciAdi,Sifre) " +
                "values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciadi2.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni kullanıcı ve şifresi sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Kullanıcıyı silmek istiyormusunuz?", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_ADMIN where KullaniciAdi=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtKullaniciadi3.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                MessageBox.Show("Kullanıcı sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
