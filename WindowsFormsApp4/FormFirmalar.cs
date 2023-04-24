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
    public partial class FormFirmalar : Form
    {
        public FormFirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void firmalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FIRMALAR",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 From TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                richKod1.Text=dr[0].ToString();
            }
            bgl.baglanti().Close();

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
            txtad.Text = "";
            txtid.Text = "";
            txtgorev.Text = "";
            txtyetkili.Text = "";
            mtbTc.Text = "";
            txtsektor.Text = "";
            mtbTel.Text = "";
            mtbTel2.Text = "";
            mtbTel3.Text = "";
            txtmail.Text = "";
            mtbFax.Text = "";
            txtvergi.Text = "";
            rtbadres.Text = "";
            txtKod3.Text = "";
            txtKod2.Text = "";
            txtKod1.Text = "";
            txtad.Focus();



        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormFirmalar_Load(object sender, EventArgs e)
        {
            firmalistesi();
            sehirlistesi();
            temizle();
            carikodaciklamalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtgorev.Text = dr["YETKILISTATU"].ToString();
                txtyetkili.Text = dr["YETKILIADSOYAD"].ToString();
                mtbTc.Text = dr["YETKILITC"].ToString();
                txtsektor.Text = dr["SEKTOR"].ToString();
                mtbTel.Text = dr["TELEFON1"].ToString();
                mtbTel2.Text = dr["TELEFON2"].ToString();
                mtbTel3.Text = dr["TELEFON3"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                mtbFax.Text = dr["FAX"].ToString();
                comboBoxIL.Text = dr["IL"].ToString();
                comboBoxILCE.Text = dr["ILCE"].ToString();
                txtvergi.Text = dr["VERGIDAIRE"].ToString();
                rtbadres.Text = dr["ADRES"].ToString();
                txtKod1.Text = dr["OZELKOD1"].ToString();
                txtKod2.Text = dr["OZELKOD2"].ToString();
                txtKod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR" +
                "(AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3," +
                "MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtgorev.Text);
            komut.Parameters.AddWithValue("@p3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", mtbTc.Text);
            komut.Parameters.AddWithValue("@p5", txtsektor.Text);
            komut.Parameters.AddWithValue("@p6", mtbTel.Text);
            komut.Parameters.AddWithValue("@p7", mtbTel2.Text);
            komut.Parameters.AddWithValue("@p8", mtbTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtmail.Text);
            komut.Parameters.AddWithValue("@p10", mtbFax.Text);
            komut.Parameters.AddWithValue("@p11", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p12", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p13", txtvergi.Text);
            komut.Parameters.AddWithValue("@p14", rtbadres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
        }

        private void comboBoxIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxILCE.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxIL.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxILCE.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Firmayı silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_FIRMALAR where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                firmalistesi();
                MessageBox.Show("Firma sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FIRMALAR set " +
                "AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5,TELEFON1=@p6,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9," +
                "FAX=@p10,IL=@p11,ILCE=@p12,VERGIDAIRE=@p13,ADRES=@p14,OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17  where ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtgorev.Text);
            komut.Parameters.AddWithValue("@p3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", mtbTc.Text);
            komut.Parameters.AddWithValue("@p5", txtsektor.Text);
            komut.Parameters.AddWithValue("@p6", mtbTel.Text);
            komut.Parameters.AddWithValue("@p7", mtbTel2.Text);
            komut.Parameters.AddWithValue("@p8", mtbTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtmail.Text);
            komut.Parameters.AddWithValue("@p10", mtbFax.Text);
            komut.Parameters.AddWithValue("@p11", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p12", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p13", txtvergi.Text);
            komut.Parameters.AddWithValue("@p14", rtbadres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.Parameters.AddWithValue("@p18", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmalistesi();
            temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
