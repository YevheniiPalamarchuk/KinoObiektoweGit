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

namespace kino
{
    public partial class Order : Form
    {
        public static KINOSEANS seans;
        public class FILM
        {
            public int film_id;
            public String film_name;
            public String film_actor;
            public String film_comm;
            public FILM(int cls_film_id)
            {
                film_id = cls_film_id;
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"SELECT film_name,film_actor,film_comm FROM film WHERE film_id={0}", film_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            film_name = reader.GetString(0);
                            film_actor = reader.GetString(1);
                            film_comm = reader.GetString(2);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    film_name = "";
                    film_actor = "";
                    film_name = "";
                }
            }
        }
        public class KINO
        {
            public int kino_id;
            public String kino_name;
            public String kino_adress;
            public String kino_comm;
            public KINO(int cls_kino_id)
            {
                kino_id = cls_kino_id;
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"SELECT kino_name,kino_adress,kino_comm FROM kino WHERE kino_id={0}", kino_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            kino_name = reader.GetString(0);
                            kino_adress = reader.GetString(1);
                            kino_comm = reader.GetString(2);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kino_name = "";
                    kino_adress = "";
                    kino_comm = "";
                }
            }
        }
        public class KINOSEANS : KINO
        {
            public int seans_id;
            public FILM film;
            public DateTime date_beg;
            public DateTime date_end;
            public Panel seans_panel;
            public List<rezerv_mesto> spis_mest = new List<rezerv_mesto>();
            public KINOSEANS(Panel cls_pnl,int cls_kino_id, int cls_seans_id) : base(cls_kino_id)
            {
                kino_id = cls_kino_id;
                seans_id = cls_seans_id;
                seans_panel = cls_pnl;
                this.refresh_seans();
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"SELECT film_id, date_beg, date_end FROM seans WHERE seans_id={0} and kino_id={1}", seans_id, kino_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var film_id = reader.GetInt32(0);
                            date_beg = reader.GetDateTime(1);
                            date_end = reader.GetDateTime(2);
                            film = new FILM(film_id);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    film = new FILM(0);
                }
            }
            public void clear_panel()
            {
                foreach (rezerv_mesto iDel in spis_mest)
                {
                    iDel.close();
                }
                spis_mest.Clear();
            }
            public void refresh_seans()
            {
                clear_panel();
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"
select a.mesto_id,a.nrow,a.ncell,a.category_id 
,isnull((select klient_id from REZERV b where a.mesto_id=b.mesto_id and a.kino_id={1} and b.seans_id={0}),0) as klient_id
from MESTO a
where a.kino_id={1}", seans_id, kino_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        int mesto_id;
                        int klient_id;
                        while (reader.Read())
                        {
                            mesto_id = reader.GetInt32(0);
                            klient_id = reader.GetInt32(4);
                            spis_mest.Add(new rezerv_mesto(seans_panel, mesto_id, kino_id, seans_id, klient_id));
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public class chair
        {
            public int chair_id;
            public String chair_name;
            public Decimal chair_width;

            public void chair_create(int cls_chair_id)
            {
                chair_id = cls_chair_id;
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"SELECT chair_name,chair_width FROM chair WHERE chair_id={0}", chair_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            chair_name = reader.GetString(0);
                            chair_width = reader.GetDecimal(1);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chair_name = "";
                    chair_width = 0;
                }

            }
        }
        public class mesto : chair
        {
            public int mesto_id;
            public int kino_id;
            public int nrow;
            public int ncell;
            public int category_id;
            public Button btn;
            public String category_name;
            public mesto(Panel pnl, int cls_mesto_id, int cls_kino_id)
            {
                mesto_id = cls_mesto_id;
                kino_id = cls_kino_id;
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"SELECT nrow,ncell,A.category_id,chair_id, ISNULL(B.category_name, '') as category_name
FROM mesto AS A INNER JOIN CATEGORY AS B on A.category_id = B.category_id 
WHERE mesto_id={0} AND kino_id={1}", mesto_id, kino_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //kino_id = reader.GetInt32(0);
                            nrow = reader.GetInt32(0);
                            ncell = reader.GetInt32(1);
                            category_id = reader.GetInt32(2);
                            chair_id = reader.GetInt32(3);
                            category_name = reader.GetString(4);
                            //chair_name = reader.GetString(5);
                            base.chair_create(chair_id);
                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //kino_id = 0;
                    nrow = 0;
                    ncell = 0;
                    category_id = 0;
                }

                btn = new Button();
                btn.Left = (ncell-1)*55;
                btn.Top = (nrow-1)*25;
                btn.Text = nrow.ToString()+"-"+ncell.ToString();
                btn.Width = 50;
                pnl.Controls.Add(btn);
                //btn.Click += ButtonOnClick;
            }
            //private void ButtonOnClick(object sender, EventArgs eventArgs)
            //{
            //}
        }
        public class rezerv_mesto : mesto
        {
            public int seans_id;
            public int klient_id;
            public Decimal cena;
            private int _status;
            public int status
            {
                get
                {
                    return _status;
                }
                set
                {
                    _status = value;
                    OnStatusChanged();
                }
            }
            protected void OnStatusChanged()
            {
                //FREE
                if (_status == 0)
                {
                    this.btn.BackColor = Color.Green;
                    this.btn.ForeColor = Color.FromName("Yellow");
                }
                //REZERV OTHER KLIENT
                if (_status == 1)
                {
                    this.btn.BackColor = Color.Red;
                    this.btn.ForeColor = Color.Yellow;
                }
                //REZERV OUR CLIENT
                if (_status == 2)
                {
                    this.btn.BackColor = Color.Orange;
                    this.btn.ForeColor = Color.White;
                }
            }

            public rezerv_mesto(Panel pnl, int cls_mesto_id, int cls_kino_id, int cls_seans_id, int cls_klient_id) : base(pnl, cls_mesto_id, cls_kino_id)
            {
                kino_id = cls_kino_id;
                seans_id = cls_seans_id;
                klient_id = cls_klient_id;
                try
                {
                    SqlConnection con = new SqlConnection(Program.connectionString);
                    using (con)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(String.Format(@"SELECT cena FROM price WHERE seans_id={0} AND category_id={1} AND kino_id={2}", seans_id, category_id, kino_id), con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cena = reader.GetDecimal(0);

                        }
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cena = 0;
                }
                //btn.ForeColor = Color.White;
                if (klient_id == 0)
                {
                    status = 0;
                }
                else
                {
                    if (klient_id != Program.pbKlient.klient_id)
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 2;
                    }
                }
                btn.Click += ButtonOnClick;
                ToolTip toolTip1 = new ToolTip();
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(btn, String.Format(@"Kategoria: {0} 
Rodzaj: {1} 
Cena {2}", category_name.Trim(), chair_name.Trim(), cena.ToString()));
            }
            private void ButtonOnClick(object sender, EventArgs eventArgs)
            {
                var button = (Button)sender;
                if (button != null)
                {
                    if (status != 1)
                    {
                        if (Program.pbKlient.klient_id != 0)
                        {
                            Choice newFormChoice = new Choice(mesto_id, kino_id, seans_id, cena, status);
                            newFormChoice.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Nie zarejestrowany", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
            public void close()
            {
                btn.Dispose();
            }
        }
        public Order()
        {
            InitializeComponent();
        }
        private void Order_Load(object sender, EventArgs e)
        {
            gridKINO.ColumnCount = 4;
            gridKINO.AllowUserToAddRows = false;
            gridKINO.AllowUserToDeleteRows = false;
            gridKINO.ReadOnly = true;
            gridKINO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridKINO.MultiSelect = false;
            gridKINO.RowHeadersVisible = false;
            gridKINO.AllowUserToResizeColumns = false;
            gridKINO.AllowUserToResizeRows = false;
            gridKINO.BackgroundColor = SystemColors.Control;
            gridKINO.BorderStyle = BorderStyle.None;
            gridKINO.Columns[0].HeaderText = "ID";
            gridKINO.Columns[0].Name = "KINO_ID";
            gridKINO.Columns[0].Visible = false;
            gridKINO.Columns[1].HeaderText = "Nazwa kina";
            gridKINO.Columns[1].Name = "KINO_NAME";
            gridKINO.Columns[1].Width = 200;
            gridKINO.Columns[2].HeaderText = "Adres";
            gridKINO.Columns[2].Name = "KINO_ADRESS";
            gridKINO.Columns[2].Width = 150;
            gridKINO.Columns[3].HeaderText = "Opis";
            gridKINO.Columns[3].Name = "KINO_COMM";
            gridKINO.Columns[3].Width = 250;

            //a.seans_id,a.kino_id,b.kino_name,a.film_id,c.film_name,a.date_beg,a.date_end
            gridSEANS.ColumnCount = 7;
            gridSEANS.AllowUserToAddRows = false;
            gridSEANS.AllowUserToDeleteRows = false;
            gridSEANS.ReadOnly = true;
            gridSEANS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSEANS.MultiSelect = false;
            gridSEANS.RowHeadersVisible = false;
            gridSEANS.AllowUserToResizeColumns = false;
            gridSEANS.AllowUserToResizeRows = false;
            gridSEANS.BackgroundColor = SystemColors.Control;
            gridSEANS.BorderStyle = BorderStyle.None;
            gridSEANS.Columns[0].HeaderText = "SEANS_ID";
            gridSEANS.Columns[0].Name = "SEANS_ID";
            gridSEANS.Columns[0].Visible = false;
            gridSEANS.Columns[0].HeaderText = "KINO_ID";
            gridSEANS.Columns[1].Name = "KINO_ID";
            gridSEANS.Columns[1].Visible = false;
            gridSEANS.Columns[2].HeaderText = "Kino";
            gridSEANS.Columns[2].Name = "KINO_NAME";
            gridSEANS.Columns[2].Width = 150;
            gridSEANS.Columns[3].HeaderText = "FILM_ID";
            gridSEANS.Columns[3].Name = "FILM_ID";
            gridSEANS.Columns[3].Visible = false;
            gridSEANS.Columns[4].HeaderText = "Nazwa filmu";
            gridSEANS.Columns[4].Name = "FILM_NAME";
            gridSEANS.Columns[4].Width = 150;
            gridSEANS.Columns[5].HeaderText = "Start";
            gridSEANS.Columns[5].Name = "DAT_BEG";
            gridSEANS.Columns[5].Width = 150;
            gridSEANS.Columns[6].HeaderText = "Koniec";
            gridSEANS.Columns[6].Name = "DAT_END";
            gridSEANS.Columns[6].Width = 150;

            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT kino_id,kino_name,kino_adress,kino_comm FROM kino", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] row = new string[] {
                        reader.GetInt32(0).ToString(),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3) };
                        gridKINO.Rows.Add(row);

                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridKINO_SelectionChanged(object sender, EventArgs e)
        {
            if (gridKINO.Rows.Count == 0 || gridKINO.CurrentRow.Cells["KINO_ID"].Value == null)
            {
                return;
            }
            if (seans != null)
            {
                seans.clear_panel();
            }
            seans = null;
            gridSEANS.Rows.Clear();
            try
            {
                SqlConnection con = new SqlConnection(Program.connectionString);
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(String.Format(@"
SELECT a.seans_id,a.kino_id,b.kino_name,a.film_id,c.film_name,a.date_beg,a.date_end 
FROM seans a
INNER JOIN kino b on a.kino_id=b.kino_id
INNER JOIN film c on a.film_id=c.film_id
WHERE a.kino_id={0} AND a.date_beg > GETDATE()", gridKINO.CurrentRow.Cells[0].Value), con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] row = new string[] {
                        reader.GetInt32(0).ToString(),
                        reader.GetInt32(1).ToString(),
                        reader.GetString(2),
                        reader.GetInt32(3).ToString(),
                        reader.GetString(4),
                        reader.GetDateTime(5).ToString(),
                        reader.GetDateTime(6).ToString() };
                        gridSEANS.Rows.Add(row);
                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error DataBase!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridSEANS_SelectionChanged(object sender, EventArgs e)
        {
            if (seans != null)
            {
                seans.clear_panel();
            }
            seans = null;
        }
        private void btnREZERV_Click(object sender, EventArgs e)
        {
            if (seans != null)
            {
                seans.clear_panel();
            }
            seans = null;
            if (gridSEANS.Rows.Count == 0 || gridSEANS.CurrentRow.Cells["SEANS_ID"].Value == null)
            {
                return;
            }
            int kino_id = Convert.ToInt32(gridSEANS.CurrentRow.Cells["KINO_ID"].Value);
            int seans_id = Convert.ToInt32(gridSEANS.CurrentRow.Cells["SEANS_ID"].Value);
            seans = new KINOSEANS(pnlREZERV, kino_id, seans_id);
        }

        private void Order_Activated(object sender, EventArgs e)
        {
            this.Text = @"Order";
            if (Program.pbKlient.klient_id != 0)
            {
                this.Text += " (zarejestrowany " + Program.pbKlient.klient_name.Trim() + ")";
            }
            else
            {
                this.Text += " (nie zarejestrowany)";
            }
            //if(seans!=null)
            //{
            //    seans.refresh_seans();
            //}
        }
    }
}
