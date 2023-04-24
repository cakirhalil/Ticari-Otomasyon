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
    public partial class FormNotlar : Form
    {
        public FormNotlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FormNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
        void temizle()
        {
            mtbSaat.Text = "";
            txtid.Text = "";
            mtbTarih.Text = "";
            txtOlusturan.Text = "";
            txtHitap.Text = "";
            txtBaslik.Text = "";
            rtbDetay.Text = "";

            mtbTarih.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR" +
                "(TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mtbTarih.Text);
            komut.Parameters.AddWithValue("@p2", mtbSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rtbDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                mtbTarih.Text = dr["TARIH"].ToString();
                mtbSaat.Text = dr["SAAT"].ToString();
                txtBaslik.Text = dr["BASLIK"].ToString();
                rtbDetay.Text = dr["DETAY"].ToString();
                txtOlusturan.Text = dr["OLUSTURAN"].ToString();
                txtHitap.Text = dr["HITAP"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Notu silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_NOTLAR where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                MessageBox.Show("Not sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_NOTLAR set " +
                "TARIH=@p1,SAAT=@P2,BASLIK=@P3,DETAY=@P4,OLUSTURAN=@P5,HITAP=@P6 where ID=@P7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mtbTarih.Text);
            komut.Parameters.AddWithValue("@p2", mtbSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rtbDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.Parameters.Add("@p7", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormNotDetay fr = new FormNotDetay();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
                fr.tarih = dr["TARIH"].ToString();
                fr.saat = dr["SAAT"].ToString();
            }
            fr.Show();
        }
    }
}
