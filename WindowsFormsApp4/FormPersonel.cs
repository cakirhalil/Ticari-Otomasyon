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
    public partial class FormPersonel : Form
    {
        public FormPersonel()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void personellistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxIL.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            txtid.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mtbTel.Text = "";
            mtbTc.Text = "";
            txtMail.Text = "";
            comboBoxIL.Text = "";
            comboBoxILCE.Text = "";
            txtGorev.Text = "";
            rtbadres.Text = "";
        }
        private void FormPersonel_Load(object sender, EventArgs e)
        {
            personellistesi();
            sehirlistesi();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mtbTel.Text = dr["TELEFON"].ToString();
                mtbTc.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                comboBoxIL.Text = dr["IL"].ToString();
                comboBoxILCE.Text = dr["ILCE"].ToString();
                rtbadres.Text = dr["ADRES"].ToString();
                txtGorev.Text = dr["GOREV"].ToString();
            }
        }

        


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER" +
                "(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mtbTel.Text);
            komut.Parameters.AddWithValue("@p4", mtbTc.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p8", rtbadres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personellistesi();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Personeli silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_PERSONELLER where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                personellistesi();
                MessageBox.Show("Personel sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                temizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_PERSONELLER set " +
                "AD=@p1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7," +
                "ADRES=@P8,GOREV=@P9 where ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mtbTel.Text);
            komut.Parameters.AddWithValue("@p4", mtbTc.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p8", rtbadres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.Parameters.Add("@p10", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personellistesi();
        }

        private void comboBoxIL_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxILCE.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxIL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxILCE.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
