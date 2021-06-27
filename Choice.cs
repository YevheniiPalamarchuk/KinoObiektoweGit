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

using System.Net;
using System.Net.Mail;

namespace kino
{
    public partial class Choice : Form
    {
        public int mesto_id;
        public int kino_id;
        public int seans_id;
        public Decimal cena;
        public int status;
        public int rezerv_id;
        
        public Choice(int p_mesto_id,int p_kino_id, int p_seans_id, Decimal p_cena, int p_status)
        {
            mesto_id = p_mesto_id;
            kino_id = p_kino_id;
            seans_id = p_seans_id;
            cena = p_cena;
            status = p_status;
            InitializeComponent();
        }

        private void Choice_Load(object sender, EventArgs e)
        {
            lbKINO.Text = Order.seans.kino_name;
            lbFILM.Text = Order.seans.film.film_name;
            lbSEANS.Text = Order.seans.date_beg.ToString() + " - " + Order.seans.date_end.ToString();
            lblCENA.Text = cena.ToString();
            if (status == 0)
            {
                btnREZERV.Text = "Zarezerwować";
            }
            else
            {
                btnREZERV.Text = "Anulować";
            }
            btnREZERV.AutoSize = true;
        }

        private void btnREZERV_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    if (status == 0)
                    {
                        SqlCommand cmd = new SqlCommand(String.Format(@"
insert into REZERV
(mesto_id, kino_id,seans_id,klient_id)
values(@mesto_id,@kino_id,@seans_id,@klient_id);
SELECT CAST(scope_identity() AS int)"), con);
                        cmd.Parameters.Add("@mesto_id", SqlDbType.Int);
                        cmd.Parameters.Add("@kino_id", SqlDbType.Int);
                        cmd.Parameters.Add("@seans_id", SqlDbType.Int);
                        cmd.Parameters.Add("@klient_id", SqlDbType.Int);
                        cmd.Parameters["@mesto_id"].Value = mesto_id;
                        cmd.Parameters["@kino_id"].Value = kino_id;
                        cmd.Parameters["@seans_id"].Value = seans_id;
                        cmd.Parameters["@klient_id"].Value = Program.pbKlient.klient_id;
                        rezerv_id = (Int32)cmd.ExecuteScalar();
                        this.Send();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(String.Format(@"
delete from REZERV 
where mesto_id=@mesto_id and kino_id=@kino_id and seans_id=@seans_id"), con);
                        cmd.Parameters.Add("@mesto_id", SqlDbType.Int);
                        cmd.Parameters.Add("@kino_id", SqlDbType.Int);
                        cmd.Parameters.Add("@seans_id", SqlDbType.Int);
                        cmd.Parameters["@mesto_id"].Value = mesto_id;
                        cmd.Parameters["@kino_id"].Value = kino_id;
                        cmd.Parameters["@seans_id"].Value = seans_id;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
            Order.seans.refresh_seans();
        }
        private void Send()
        {
            if (string.IsNullOrEmpty(Program.pbKlient.klient_email.Trim()) == false)
            {
                try
                {                  
                    MailAddress from = new MailAddress("kinoreservation@gmail.com", "Kinoreservation");
                    MailAddress to = new MailAddress(Program.pbKlient.klient_email);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Zaproszenie";
                    m.Body = String.Format(@"<h2>ID {0} {1} {2} {3} {4}</h2>", rezerv_id, lbFILM.Text,lbKINO.Text,lbSEANS.Text,lblCENA.Text);
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("kinoreservation@gmail.com", "Kinoreservation$1");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                }
                catch (System.Exception error)
                {
                    MessageBox.Show(String.Format(@"Error SendMail!!! 
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
