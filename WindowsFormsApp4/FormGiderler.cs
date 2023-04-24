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
    public partial class FormGiderler : Form
    {
        public FormGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void giderlerlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_GIDERLER order by ID asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FormGiderler_Load(object sender, EventArgs e)
        {
            giderlerlistesi();
            temizle();
        }
        void temizle()
        {
            txtid.Text = "";
            comboBoxAY.Text = "";
            comboBoxYIL.Text = "";
            txtExtra.Text = "";
            txtElektrik.Text = "";
            txtDogalgaz.Text = "";
            txtInternet.Text = "";
            txtMaaslar.Text = "";
            txtSu.Text = "";
            rtbNot.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER" +
                "(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxAY.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxYIL.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse( txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtExtra.Text));
            komut.Parameters.AddWithValue("@p9", rtbNot.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni gider sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlerlistesi();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                comboBoxAY.Text = dr["AY"].ToString();
                comboBoxYIL.Text = dr["YIL"].ToString();
                txtElektrik.Text = dr["ELEKTRIK"].ToString();
                txtSu.Text = dr["SU"].ToString();
                txtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                txtInternet.Text = dr["INTERNET"].ToString();
                txtMaaslar.Text = dr["MAASLAR"].ToString();
                txtExtra.Text = dr["EKSTRA"].ToString();
                rtbNot.Text = dr["NOTLAR"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Gider bilgisini silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_GIDERLER where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                giderlerlistesi();
                MessageBox.Show("Gider bilgisi sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                temizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDERLER set " +
                "AY=@p1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7," +
                "EKSTRA=@P8,NOTLAR=@P9 where ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", comboBoxAY.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxYIL.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtExtra.Text));
            komut.Parameters.AddWithValue("@p9", rtbNot.Text);
            komut.Parameters.Add("@p10", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            giderlerlistesi();
            temizle();
        }
    }
}
