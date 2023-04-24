
namespace WindowsFormsApp4
{
    partial class FormBankalar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBankalar));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.txtsube = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txthesapturu = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxILCE = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxIL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.mtbTel = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnGüncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbankaad = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.mtbTarih = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtyetkili = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txthesapno = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtıban = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsube.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthesapturu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxILCE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbankaad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.BorderColor = System.Drawing.Color.Green;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseBorderColor = true;
            this.gridView1.DetailHeight = 437;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(13, 14);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1489, 726);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // txtsube
            // 
            this.txtsube.Location = new System.Drawing.Point(118, 194);
            this.txtsube.Margin = new System.Windows.Forms.Padding(4);
            this.txtsube.Name = "txtsube";
            this.txtsube.Size = new System.Drawing.Size(178, 22);
            this.txtsube.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 198);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "ŞUBE:";
            // 
            // txthesapturu
            // 
            this.txthesapturu.Location = new System.Drawing.Point(118, 384);
            this.txthesapturu.Margin = new System.Windows.Forms.Padding(4);
            this.txthesapturu.Name = "txthesapturu";
            this.txthesapturu.Size = new System.Drawing.Size(178, 22);
            this.txthesapturu.TabIndex = 28;
            // 
            // comboBoxILCE
            // 
            this.comboBoxILCE.Location = new System.Drawing.Point(118, 159);
            this.comboBoxILCE.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxILCE.Name = "comboBoxILCE";
            this.comboBoxILCE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxILCE.Size = new System.Drawing.Size(178, 22);
            this.comboBoxILCE.TabIndex = 27;
            // 
            // comboBoxIL
            // 
            this.comboBoxIL.Location = new System.Drawing.Point(118, 124);
            this.comboBoxIL.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxIL.Name = "comboBoxIL";
            this.comboBoxIL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxIL.Size = new System.Drawing.Size(178, 22);
            this.comboBoxIL.TabIndex = 26;
            this.comboBoxIL.SelectedIndexChanged += new System.EventHandler(this.comboBoxIL_SelectedIndexChanged);
            // 
            // mtbTel
            // 
            this.mtbTel.Location = new System.Drawing.Point(118, 322);
            this.mtbTel.Margin = new System.Windows.Forms.Padding(4);
            this.mtbTel.Mask = "(999) 000-0000";
            this.mtbTel.Name = "mtbTel";
            this.mtbTel.Size = new System.Drawing.Size(176, 23);
            this.mtbTel.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 387);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "HESAP TÜRÜ:";
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(59, 510);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(245, 42);
            this.btnSil.TabIndex = 22;
            this.btnSil.Text = "SİL";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGüncelle
            // 
            this.btnGüncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGüncelle.ImageOptions.Image")));
            this.btnGüncelle.Location = new System.Drawing.Point(59, 560);
            this.btnGüncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnGüncelle.Name = "btnGüncelle";
            this.btnGüncelle.Size = new System.Drawing.Size(245, 42);
            this.btnGüncelle.TabIndex = 21;
            this.btnGüncelle.Text = "GÜNCELLE";
            this.btnGüncelle.Click += new System.EventHandler(this.btnGüncelle_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(59, 455);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(245, 48);
            this.btnKaydet.TabIndex = 20;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 411);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "FİRMA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "İLÇE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 129);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "İL:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 325);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "TELEFON:";
            // 
            // txtbankaad
            // 
            this.txtbankaad.Location = new System.Drawing.Point(118, 89);
            this.txtbankaad.Margin = new System.Windows.Forms.Padding(4);
            this.txtbankaad.Name = "txtbankaad";
            this.txtbankaad.Size = new System.Drawing.Size(178, 22);
            this.txtbankaad.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "BANKA ADI:";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(118, 53);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(178, 22);
            this.txtid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookUpEdit1);
            this.groupControl1.Controls.Add(this.btnTemizle);
            this.groupControl1.Controls.Add(this.mtbTarih);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Controls.Add(this.txtyetkili);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.txthesapno);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.txtıban);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtsube);
            this.groupControl1.Controls.Add(this.label11);
            this.groupControl1.Controls.Add(this.txthesapturu);
            this.groupControl1.Controls.Add(this.comboBoxILCE);
            this.groupControl1.Controls.Add(this.comboBoxIL);
            this.groupControl1.Controls.Add(this.mtbTel);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.btnSil);
            this.groupControl1.Controls.Add(this.btnGüncelle);
            this.groupControl1.Controls.Add(this.btnKaydet);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txtbankaad);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtid);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(1510, 14);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(401, 726);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "KONTROL";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(118, 411);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(176, 24);
            this.lookUpEdit1.TabIndex = 42;
            // 
            // btnTemizle
            // 
            this.btnTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTemizle.ImageOptions.Image")));
            this.btnTemizle.Location = new System.Drawing.Point(59, 610);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(245, 42);
            this.btnTemizle.TabIndex = 41;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // mtbTarih
            // 
            this.mtbTarih.Location = new System.Drawing.Point(118, 353);
            this.mtbTarih.Margin = new System.Windows.Forms.Padding(4);
            this.mtbTarih.Mask = "00/00/0000";
            this.mtbTarih.Name = "mtbTarih";
            this.mtbTarih.Size = new System.Drawing.Size(176, 23);
            this.mtbTarih.TabIndex = 39;
            this.mtbTarih.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 356);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "TARİH:";
            // 
            // txtyetkili
            // 
            this.txtyetkili.Location = new System.Drawing.Point(118, 291);
            this.txtyetkili.Margin = new System.Windows.Forms.Padding(4);
            this.txtyetkili.Name = "txtyetkili";
            this.txtyetkili.Size = new System.Drawing.Size(178, 23);
            this.txtyetkili.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "YETKİLİ:";
            // 
            // txthesapno
            // 
            this.txthesapno.Location = new System.Drawing.Point(118, 260);
            this.txthesapno.Margin = new System.Windows.Forms.Padding(4);
            this.txthesapno.Name = "txthesapno";
            this.txthesapno.Size = new System.Drawing.Size(178, 23);
            this.txthesapno.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 263);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 34;
            this.label4.Text = "HESAP NO:";
            // 
            // txtıban
            // 
            this.txtıban.Location = new System.Drawing.Point(118, 229);
            this.txtıban.Margin = new System.Windows.Forms.Padding(4);
            this.txtıban.Name = "txtıban";
            this.txtıban.Size = new System.Drawing.Size(178, 23);
            this.txtıban.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 232);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "IBAN:";
            // 
            // FormBankalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 753);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormBankalar";
            this.Text = "Bankalar";
            this.Load += new System.EventHandler(this.FormBankalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsube.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txthesapturu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxILCE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxIL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbankaad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.TextEdit txtsube;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txthesapturu;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxILCE;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxIL;
        private System.Windows.Forms.MaskedTextBox mtbTel;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnGüncelle;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtbankaad;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtid;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.MaskedTextBox mtbTarih;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtyetkili;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txthesapno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtıban;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
    }
}