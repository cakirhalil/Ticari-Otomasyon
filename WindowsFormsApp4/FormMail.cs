using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp4
{
    public partial class FormMail : Form
    {
        public FormMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FormMail_Load(object sender, EventArgs e)
        {
            txtMailadres.Text = mail;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("mail","şifre");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesajim.To.Add(rchMesaj.Text);
            mesajim.From = new MailAddress("mail");
            mesajim.Subject = txtKonu.Text;
            mesajim.Body = rchMesaj.Text;
            istemci.Send(mesajim);
        }
    }
}
