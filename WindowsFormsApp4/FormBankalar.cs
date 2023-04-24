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
    public partial class FormBankalar : Form
    {
        public FormBankalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("execute BankaBilgileri", bgl.baglanti());
            DataTable dt = new DataTable();
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
        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD from TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.NullText = "Bir Firma Seçin";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;
        }
        void temizle()
        {
            txtbankaad.Text = "";
            txtid.Text = "";
            comboBoxIL.Text = "";
            comboBoxILCE.Text = "";
            txtsube.Text = "";
            txtıban.Text = "";
            mtbTel.Text = "";
            txthesapno.Text = "";
            txthesapturu.Text = "";
            txtyetkili.Text = "";
            mtbTarih.Text = "";
            lookUpEdit1.Text = "";
            txtbankaad.Focus();
        }

        private void FormBankalar_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            firmalistesi();
            temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR" +
                "(BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbankaad.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p3", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p4", txtsube.Text);
            komut.Parameters.AddWithValue("@p5", txtıban.Text);
            komut.Parameters.AddWithValue("@p6", txthesapno.Text);
            komut.Parameters.AddWithValue("@p7", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p8", mtbTel.Text);
            komut.Parameters.AddWithValue("@p9", mtbTarih.Text);
            komut.Parameters.AddWithValue("@p10", txthesapturu.Text);
            komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka sisteme eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtbankaad.Text = dr["BANKAADI"].ToString();
                comboBoxIL.Text = dr["IL"].ToString();
                comboBoxILCE.Text = dr["ILCE"].ToString();
                txtsube.Text = dr["SUBE"].ToString();
                txtıban.Text = dr["IBAN"].ToString();
                txthesapno.Text = dr["HESAPNO"].ToString();
                txtyetkili.Text = dr["YETKILI"].ToString();
                mtbTel.Text = dr["TELEFON"].ToString();
                mtbTarih.Text = dr["TARIH"].ToString();
                txthesapturu.Text = dr["HESAPTURU"].ToString();
                
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Banka bilgisini silmek istiyormusunuz.", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("delete from TBL_BANKALAR where ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                MessageBox.Show("Banka bilgisi sistemden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_BANKALAR set " +
                "BANKAADI=@p1,IL=@p2,ILCE=@p3,SUBE=@p4,IBAN=@p5,HESAPNO=@p6,YETKILI=@p7," +
                "TELEFON=@p8,TARIH=@p9,HESAPTURU=@p10,FIRMAID=@p11 where ID=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbankaad.Text);
            komut.Parameters.AddWithValue("@p2", comboBoxIL.Text);
            komut.Parameters.AddWithValue("@p3", comboBoxILCE.Text);
            komut.Parameters.AddWithValue("@p4", txtsube.Text);
            komut.Parameters.AddWithValue("@p5", txtıban.Text);
            komut.Parameters.AddWithValue("@p6", txthesapno.Text);
            komut.Parameters.AddWithValue("@p7", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p8", mtbTel.Text);
            komut.Parameters.AddWithValue("@p9", mtbTarih.Text);
            komut.Parameters.AddWithValue("@p10", txthesapturu.Text);
            komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue);
            komut.Parameters.AddWithValue("@p12", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka bilgisi sistemde güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }
    }
}
