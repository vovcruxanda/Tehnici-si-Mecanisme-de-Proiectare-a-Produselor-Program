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

namespace DairyFarmSystem
{
    public partial class MilkProduction : Form
    {
        // Singleton instance
        private static MilkProduction instance;

        // Private constructor to prevent instantiation
        public MilkProduction()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }

        // Singleton instance getter
        public static MilkProduction GetInstance()
        {
            if (instance == null)
            {
                instance = new MilkProduction();
            }
            return instance;
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MilkProduction_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
        private void FillCowId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CowID from CowTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowID", typeof(int));
            dt.Load(Rdr);
            CowIDTb.ValueMember = "CowID";
            CowIDTb.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from MilkTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MilkDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            CowNnameTb.Text = "";
            AMMTb.Text = "";
            NoonMTb.Text = "";
            PMMTb.Text = "";
            TotalMTb.Text = "";
            key = 0;
        }
        private void GetCowName()
        {
            Con.Open();
            string query = "select * from CowTbl where CowID=" + CowIDTb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNnameTb.Text = dr["CowName"].ToString();
            }
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIDTb.SelectedIndex == -1 || CowNnameTb.Text == "" || AMMTb.Text == "" || PMMTb.Text == "" || NoonMTb.Text == "" || TotalMTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into MilkTbl values(@CowID, @CowNname, @AMM, @NoonM, @PMM, @TotalM, @Date)";
                    using (SqlCommand cmd = new SqlCommand(Query, Con))
                    {
                        cmd.Parameters.AddWithValue("@CowID", CowIDTb.SelectedValue);
                        cmd.Parameters.AddWithValue("@CowNname", CowNnameTb.Text);
                        cmd.Parameters.AddWithValue("@AMM", decimal.Parse(AMMTb.Text));
                        cmd.Parameters.AddWithValue("@NoonM", decimal.Parse(NoonMTb.Text));
                        cmd.Parameters.AddWithValue("@PMM", decimal.Parse(PMMTb.Text));
                        cmd.Parameters.AddWithValue("@TotalM", decimal.Parse(TotalMTb.Text));
                        cmd.Parameters.AddWithValue("@Date", DateTb.Value.Date);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Milk Saved Successfully");
                    }

                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CowIDTb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void PMMTb_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void PMMTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int amMilk = Convert.ToInt32(AMMTb.Text);
                int noonMilk = Convert.ToInt32(NoonMTb.Text);
                int pmMilk = Convert.ToInt32(PMMTb.Text);

                int total = amMilk + noonMilk + pmMilk;
                TotalMTb.Text = "" + total;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure all milk amount fields contain valid numbers.");
            }
        }
        int key = 0;
        private void MilkDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = MilkDGV.Rows[e.RowIndex];

                CowIDTb.Text = row.Cells[1].Value.ToString();
                CowNnameTb.Text = row.Cells[2].Value.ToString();
                AMMTb.Text = row.Cells[3].Value.ToString();
                NoonMTb.Text = row.Cells[4].Value.ToString();
                PMMTb.Text = row.Cells[5].Value.ToString();
                TotalMTb.Text = row.Cells[6].Value.ToString();
                DateTb.Text = row.Cells[7].Value.ToString();

                if (string.IsNullOrEmpty(CowNnameTb.Text))
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0].Value);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Milk Product to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "delete from MilkTbl where Mid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Succcesfully");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CowIDTb.SelectedIndex == -1 || CowNnameTb.Text == "" || AMMTb.Text == "" || PMMTb.Text == "" || NoonMTb.Text == "" || TotalMTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update MilkTbl set CowName='" + CowNnameTb.Text + "', AMMilk=" + AMMTb.Text + ", NoonMilk=" + NoonMTb.Text + ",PMMilk=" + PMMTb.Text + ",TotalMilk=" + TotalMTb + ",DateProd=" + DateTb.Value.Date + " where CowID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Succcesfully");
                    Con.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
