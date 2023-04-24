using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FormAnamodul : Form
    {
        public FormAnamodul()
        {
            InitializeComponent();
        }
        FrmUrunler fr;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed) 
            {
                fr = new FrmUrunler();
                fr.MdiParent = this;
                fr.Show();
            }
            
        }
        FormMusteriler fr2;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new FormMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        public string kullanici;
        private void FormAnamodul_Load(object sender, EventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new FormAnasayfa();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
        FormFirmalar fr3;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new FormFirmalar();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }
        FormPersonel fr4;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new FormPersonel();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        FormRehber fr5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new FormRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        FormGiderler fr6;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new FormGiderler();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        FormBankalar fr7;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new FormBankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
        FormFaturalar fr8;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new FormFaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        FormNotlar fr9;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new FormNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
        FormHareketler fr10;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new FormHareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }
        FormStoklar fr11;
        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new FormStoklar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }
        FormAyarlar fr12;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new FormAyarlar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }
        FormKasa fr13;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new FormKasa();
                fr13.Ad = kullanici;
                fr13.MdiParent = this;
                fr13.Show();
            }
        }
        FormAnasayfa fr14;
        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new FormAnasayfa();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
    }
}
