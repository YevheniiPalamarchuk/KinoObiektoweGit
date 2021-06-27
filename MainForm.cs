using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.Util.Collections;
using NPOI;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;

using System.IO;

using System.Data.SqlClient;

namespace kino
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }


        private void cmdOrder_Click(object sender, EventArgs e)
        {
            Order newFormOrder = new Order();
            newFormOrder.ShowDialog();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.pnlDATABASE.BackColor = Color.Transparent;
            this.pnlLogin.BackColor = Color.Transparent;
        }

        private void btnLoadFILM_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() != "admin")
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IWorkbook hssfwb = new HSSFWorkbook();

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            //using (FileStream file = new FileStream("DATABASE.xls",FileMode.Open,FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            ISheet sheet = hssfwb.GetSheet("FILM");
            IRow rowObj;
            int film_id;
            String film_name;
            String film_actor;
            String film_comm;
            for (int row=1;row<=sheet.LastRowNum;row++)
            {
                if (sheet.GetRow(row)!=null)
                {
                    rowObj = sheet.GetRow(row);
                    film_id = (int)rowObj.GetCell(0).NumericCellValue;
                    film_name = rowObj.GetCell(1).StringCellValue;
                    film_actor = rowObj.GetCell(2).StringCellValue;
                    film_comm = rowObj.GetCell(3).StringCellValue;
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.connectionString);
                        using (con)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE film as t_base
USING (select @film_id as film_id,@film_name as film_name,@film_actor as film_actor,@film_comm as film_comm) as t_source
ON (t_base.film_id=t_source.film_id)
WHEN MATCHED THEN update set film_name=t_source.film_name, film_actor=t_source.film_actor, film_comm=t_source.film_comm
WHEN NOT MATCHED THEN insert (film_id,film_name,film_actor,film_comm) values(t_source.film_id,t_source.film_name,t_source.film_actor,t_source.film_comm);"), con);
                            cmd.Parameters.Add("@film_id", SqlDbType.Int);
                            cmd.Parameters.Add("@film_name", SqlDbType.Char);
                            cmd.Parameters.Add("@film_actor", SqlDbType.Char);
                            cmd.Parameters.Add("@film_comm", SqlDbType.Char);
                            cmd.Parameters["@film_id"].Value = film_id;
                            cmd.Parameters["@film_name"].Value = film_name;
                            cmd.Parameters["@film_actor"].Value = film_actor;
                            cmd.Parameters["@film_comm"].Value = film_comm;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException error)
                    {
                        if (error.Source != null)
                        {
                            MessageBox.Show(String.Format(@"Error DataBase!!! 
Row FILM_ID = {1}
{0}", error.Message, film_id), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            MessageBox.Show("Load Complete");
        }

        private void brnLoadKINO_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() != "admin")
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IWorkbook hssfwb = new HSSFWorkbook();

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            //using (FileStream file = new FileStream("DATABASE.xls",FileMode.Open,FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            ISheet sheet = hssfwb.GetSheet("KINO");
            IRow rowObj;
            int kino_id;
            String kino_name;
            String kino_adress;
            String kino_comm;
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    rowObj = sheet.GetRow(row);
                    kino_id = (int)rowObj.GetCell(0).NumericCellValue;
                    kino_name = rowObj.GetCell(1).StringCellValue;
                    kino_adress = rowObj.GetCell(2).StringCellValue;
                    kino_comm = rowObj.GetCell(3).StringCellValue;
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.connectionString);
                        using (con)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE kino as t_base
USING (select @kino_id as kino_id,@kino_name as kino_name,@kino_adress as kino_adress,@kino_comm as kino_comm) as t_source
ON (t_base.kino_id=t_source.kino_id)
WHEN MATCHED THEN update set kino_name=t_source.kino_name, kino_adress=t_source.kino_adress, kino_comm=t_source.kino_comm
WHEN NOT MATCHED THEN insert (kino_id,kino_name,kino_adress,kino_comm) values(t_source.kino_id,t_source.kino_name,t_source.kino_adress,t_source.kino_comm);"), con);
                            cmd.Parameters.Add("@kino_id", SqlDbType.Int);
                            cmd.Parameters.Add("@kino_name", SqlDbType.Char);
                            cmd.Parameters.Add("@kino_adress", SqlDbType.Char);
                            cmd.Parameters.Add("@kino_comm", SqlDbType.Char);
                            cmd.Parameters["@kino_id"].Value = kino_id;
                            cmd.Parameters["@kino_name"].Value = kino_name;
                            cmd.Parameters["@kino_adress"].Value = kino_adress;
                            cmd.Parameters["@kino_comm"].Value = kino_comm;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException error)
                    {
                        if (error.Source != null)
                        {
                            MessageBox.Show(String.Format(@"Error DataBase!!! 
Row KINO_ID = {1}
{0}", error.Message, kino_id), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            MessageBox.Show("Load Complete");
        }

        private void btnLoadMESTO_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() != "admin")
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IWorkbook hssfwb = new HSSFWorkbook();

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            //using (FileStream file = new FileStream("DATABASE.xls",FileMode.Open,FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            ISheet sheet = hssfwb.GetSheet("MESTO");
            IRow rowObj;
            int mesto_id;
            int kino_id;
            int chair_id;            
            int nrow;
            int ncell;
            int category_id;
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    rowObj = sheet.GetRow(row);
                    kino_id = (int)rowObj.GetCell(0).NumericCellValue;
                    mesto_id = (int)rowObj.GetCell(1).NumericCellValue;
                    chair_id = (int)rowObj.GetCell(2).NumericCellValue;                    
                    nrow = (int)rowObj.GetCell(3).NumericCellValue;
                    ncell = (int)rowObj.GetCell(4).NumericCellValue;
                    category_id = (int)rowObj.GetCell(5).NumericCellValue;
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.connectionString);
                        using (con)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE mesto as t_base
USING (select @mesto_id as mesto_id, @kino_id as kino_id,@chair_id as chair_id,@nrow as nrow,@ncell as ncell, @category_id as category_id) as t_source
ON (t_base.mesto_id=t_source.mesto_id AND t_base.kino_id=t_source.kino_id)
WHEN MATCHED THEN update set chair_id=t_source.chair_id, category_id=t_source.category_id
WHEN NOT MATCHED THEN insert (mesto_id, kino_id, chair_id, nrow, ncell, category_id) values(t_source.mesto_id, t_source.kino_id, t_source.chair_id, t_source.nrow, t_source.ncell, t_source.category_id);"), con);
                            cmd.Parameters.Add("@mesto_id", SqlDbType.Int);
                            cmd.Parameters.Add("@kino_id", SqlDbType.Int);
                            cmd.Parameters.Add("@chair_id", SqlDbType.Int);
                            cmd.Parameters.Add("@nrow", SqlDbType.Int);
                            cmd.Parameters.Add("@ncell", SqlDbType.Int);
                            cmd.Parameters.Add("@category_id", SqlDbType.Int);
                            cmd.Parameters["@mesto_id"].Value = mesto_id;
                            cmd.Parameters["@kino_id"].Value = kino_id;
                            cmd.Parameters["@chair_id"].Value = chair_id;
                            cmd.Parameters["@nrow"].Value = nrow;
                            cmd.Parameters["@ncell"].Value = ncell;
                            cmd.Parameters["@category_id"].Value = category_id;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException error)
                    {
                        if (error.Source != null)
                        {
                            MessageBox.Show(String.Format(@"Error DataBase!!! 
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            MessageBox.Show("Load Complete");
        }

        private void btnLoadSEANS_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() != "admin")
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IWorkbook hssfwb = new HSSFWorkbook();

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            //using (FileStream file = new FileStream("DATABASE.xls",FileMode.Open,FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            ISheet sheet = hssfwb.GetSheet("SEANS");
            IRow rowObj;
            int seans_id;
            int kino_id;
            int film_id;
            String date_beg;
            String date_end;
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    rowObj = sheet.GetRow(row);
                    kino_id = (int)rowObj.GetCell(0).NumericCellValue;
                    seans_id = (int)rowObj.GetCell(1).NumericCellValue;
                    film_id = (int)rowObj.GetCell(2).NumericCellValue;
                    date_beg = rowObj.GetCell(3).StringCellValue;
                    date_end = rowObj.GetCell(4).StringCellValue;
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.connectionString);
                        using (con)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE seans as t_base
USING (select @seans_id as seans_id, @kino_id as kino_id,@film_id as film_id,@date_beg as date_beg,@date_end as date_end) as t_source
ON (t_base.seans_id=t_source.seans_id AND t_base.kino_id=t_source.kino_id)
WHEN MATCHED THEN update set seans_id=t_source.seans_id, kino_id=t_source.kino_id, film_id=t_source.film_id, date_beg = t_source.date_beg, date_end = t_source.date_end
WHEN NOT MATCHED THEN insert (seans_id, kino_id, film_id, date_beg, date_end) values(t_source.seans_id, t_source.kino_id, t_source.film_id, t_source.date_beg, t_source.date_end);"), con);
                            cmd.Parameters.Add("@seans_id", SqlDbType.Int);
                            cmd.Parameters.Add("@kino_id", SqlDbType.Int);
                            cmd.Parameters.Add("@film_id", SqlDbType.Int);
                            cmd.Parameters.Add("@date_beg", SqlDbType.DateTime);
                            cmd.Parameters.Add("@date_end", SqlDbType.DateTime);
                            cmd.Parameters["@seans_id"].Value = seans_id;
                            cmd.Parameters["@kino_id"].Value = kino_id;
                            cmd.Parameters["@film_id"].Value = film_id;
                            cmd.Parameters["@date_beg"].Value = Convert.ToDateTime(date_beg);
                            cmd.Parameters["@date_end"].Value = Convert.ToDateTime(date_end);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException error)
                    {
                        if (error.Source != null)
                        {
                            MessageBox.Show(String.Format(@"Error DataBase!!! 
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            MessageBox.Show("Load Complete");
        }

        private void btnLoadPRICE_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() != "admin")
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IWorkbook hssfwb = new HSSFWorkbook();

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            //using (FileStream file = new FileStream("DATABASE.xls",FileMode.Open,FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            ISheet sheet = hssfwb.GetSheet("PRICE");
            IRow rowObj;
            int kino_id;
            int seans_id;
            int category_id;
            int cena;
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    rowObj = sheet.GetRow(row);
                    kino_id = (int)rowObj.GetCell(0).NumericCellValue;
                    seans_id = (int)rowObj.GetCell(1).NumericCellValue;
                    category_id = (int)rowObj.GetCell(2).NumericCellValue;
                    cena = (int)rowObj.GetCell(3).NumericCellValue;
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.connectionString);
                        using (con)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE price as t_base
USING (select @seans_id as seans_id, @kino_id as kino_id,@category_id as category_id,@cena as cena) as t_source
ON (t_base.seans_id=t_source.seans_id AND t_base.kino_id=t_source.kino_id AND t_base.category_id = t_source.category_id)
WHEN MATCHED THEN update set seans_id=t_source.seans_id, kino_id=t_source.kino_id, category_id=t_source.category_id, cena=t_source.cena
WHEN NOT MATCHED THEN insert (seans_id, kino_id, category_id, cena) values(t_source.seans_id, t_source.kino_id, t_source.category_id, t_source.cena);"), con);
                            cmd.Parameters.Add("@kino_id", SqlDbType.Int);
                            cmd.Parameters.Add("@seans_id", SqlDbType.Int);
                            cmd.Parameters.Add("@category_id", SqlDbType.Int);
                            cmd.Parameters.Add("@cena", SqlDbType.Int);
                            cmd.Parameters["@kino_id"].Value = kino_id;
                            cmd.Parameters["@seans_id"].Value = seans_id;
                            cmd.Parameters["@category_id"].Value = category_id;
                            cmd.Parameters["@cena"].Value = cena;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException error)
                    {
                        if (error.Source != null)
                        {
                            MessageBox.Show(String.Format(@"Error DataBase!!! 
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            MessageBox.Show("Load Complete");

        }

        private void btnLoadCHAIR_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() != "admin")
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IWorkbook hssfwb = new HSSFWorkbook();

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            //using (FileStream file = new FileStream("DATABASE.xls",FileMode.Open,FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            ISheet sheet = hssfwb.GetSheet("CHAIR");
            IRow rowObj;
            int chair_id;
            String chair_name;
            int chair_width;
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    rowObj = sheet.GetRow(row);
                    chair_id = (int)rowObj.GetCell(0).NumericCellValue;
                    chair_name = rowObj.GetCell(1).StringCellValue;
                    chair_width = (int)rowObj.GetCell(2).NumericCellValue;
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.connectionString);
                        using (con)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE chair as t_base
USING (select @chair_id as chair_id, @chair_name as chair_name,@chair_width as chair_width) as t_source
ON (t_base.chair_id=t_source.chair_id)
WHEN MATCHED THEN update set chair_id=t_source.chair_id, chair_name=t_source.chair_name, chair_width=t_source.chair_width
WHEN NOT MATCHED THEN insert (chair_id, chair_name, chair_width) values(t_source.chair_id, t_source.chair_name, t_source.chair_width);"), con);
                            cmd.Parameters.Add("@chair_id", SqlDbType.Int);
                            cmd.Parameters.Add("@chair_name", SqlDbType.Char);
                            cmd.Parameters.Add("@chair_width", SqlDbType.Int);
                            cmd.Parameters["@chair_id"].Value = chair_id;
                            cmd.Parameters["@chair_name"].Value = chair_name;
                            cmd.Parameters["@chair_width"].Value = chair_width;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException error)
                    {
                        if (error.Source != null)
                        {
                            MessageBox.Show(String.Format(@"Error DataBase!!! 
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            MessageBox.Show("Load Complete");
        }

        private void btnLoadCATEGORY_Click(object sender, EventArgs e)
        {
            if (Program.pbKlient.klient_login.Trim() != "admin")
            {
                MessageBox.Show(String.Format(@"Wymagane uprawnienia administratora"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IWorkbook hssfwb = new HSSFWorkbook();

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            //using (FileStream file = new FileStream("DATABASE.xls",FileMode.Open,FileAccess.Read))
            //{
            //    hssfwb = new HSSFWorkbook(file);
            //}
            ISheet sheet = hssfwb.GetSheet("CATEGORY");
            IRow rowObj;
            int category_id;
            String category_name;
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null)
                {
                    rowObj = sheet.GetRow(row);
                    category_id = (int)rowObj.GetCell(0).NumericCellValue;
                    category_name = rowObj.GetCell(1).StringCellValue;
                    try
                    {
                        SqlConnection con = new SqlConnection(Program.connectionString);
                        using (con)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand(String.Format(@"
MERGE category as t_base
USING (select @category_id as category_id, @category_name as category_name) as t_source
ON (t_base.category_id=t_source.category_id)
WHEN MATCHED THEN update set category_id=t_source.category_id, category_name=t_source.category_name
WHEN NOT MATCHED THEN insert (category_id, category_name) values(t_source.category_id, t_source.category_name);"), con);
                            cmd.Parameters.Add("@category_id", SqlDbType.Int);
                            cmd.Parameters.Add("@category_name", SqlDbType.Char);
                            cmd.Parameters["@category_id"].Value = category_id;
                            cmd.Parameters["@category_name"].Value = category_name;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException error)
                    {
                        if (error.Source != null)
                        {
                            MessageBox.Show(String.Format(@"Error DataBase!!! 
{0}", error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            MessageBox.Show("Load Complete");
        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            this.Text = @"Kino w61765";
            if (Program.pbKlient.klient_id != 0)
            {
                this.Text += " (zarejestrowany " + Program.pbKlient.klient_name.Trim() + ")";
            }
            else
            {
                this.Text += " (nie zarejestrowany)";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register formRegister = new Register();
            formRegister.ShowDialog();
        }

        private void btnLOGIN_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            formLogin.ShowDialog();
        }
    }
}
