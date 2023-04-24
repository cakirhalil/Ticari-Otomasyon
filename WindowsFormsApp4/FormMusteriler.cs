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
    public partial class FormMusteriler : Form
    {
        public FormMusteriler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_MUSTERILER", bgl.baglanti());
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

        private void FormMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
            sehirlistesi();
        }

        void temizle()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            txtvergi.Text = "";
            txtmail.Text = "";
            mtbTc.Text = "";
            mtbTel.Text = "";
            mtbTel2.Text = "";
            rtbadres.Text = "";
            txtid.Text = "";
            comboBoxIL.Text = "";
            comboBoxILCE.Text = "";

        }

        private void comboBoxIL_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER" +
                "(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRESI) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mtbTel.Text);
            komut.Parameters.AddWithValue("@p4", mtbTel2.Text);
            komut.Parameters.AddWithValue("@p5", mtbTc.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p8", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p9", rtbadres.Text);
            komut.Parameters.AddWithValue("@p10", txtvergi.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Kişiyi silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_MUSTERILER where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                MessageBox.Show("Kişi sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!= null)
            {
                txtid.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtsoyad.Text = dr["SOYAD"].ToString();
                mtbTel.Text = dr["TELEFON"].ToString();
                mtbTel2.Text = dr["TELEFON2"].ToString();
                mtbTc.Text = dr["TC"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                comboBoxIL.Text = dr["IL"].ToString();
                comboBoxILCE.Text = dr["ILCE"].ToString();
                txtvergi.Text = dr["VERGIDAIRESI"].ToString();
                rtbadres.Text = dr["ADRES"].ToString();
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERILER set " +
                "AD=@p1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7," +
                "ILCE=@P8,ADRES=@P9,VERGIDAIRESI=@P10 where ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mtbTel.Text);
            komut.Parameters.AddWithValue("@p4", mtbTel2.Text);
            komut.Parameters.AddWithValue("@p5", mtbTc.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p8", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p9", rtbadres.Text);
            komut.Parameters.AddWithValue("@p10", txtvergi.Text);
            komut.Parameters.Add("@p11", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kişi bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
