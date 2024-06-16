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
    public partial class Breeding : Form
    {
        public Breeding()
        {
            InitializeComponent();
            FillCowId();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
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

        private void Breeding_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            Breeding Ob = new Breeding();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click_1(object sender, EventArgs e)
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
            string query = "select * from BreedTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BreedDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            AgeTb.Text = "";
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
                CowNameTb.Text = dr["CowName"].ToString();
                AgeTb.Text = dr["Age"].ToString();
            }
            Con.Close();
        }

        private void CowIDTb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIDTb.SelectedIndex == -1 || CowNameTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO BreedTbl (HeatDate, BreedDate, CowID, CowName, PregDate, ExpDateCalve, DateCalved, CowAge) " +
                                   "VALUES (@Heat, @Breed, @CowID, @CowName, @PregDate, @EDC, @DateCalved, @Age)";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Heat", HeatTb.Value.Date);
                    cmd.Parameters.AddWithValue("@Breed", BreedTb.Value.Date);
                    cmd.Parameters.AddWithValue("@CowID", CowIDTb.SelectedValue);
                    cmd.Parameters.AddWithValue("@CowName", CowNameTb.Text);
                    cmd.Parameters.AddWithValue("@PregDate", PregTb.Value.Date);
                    cmd.Parameters.AddWithValue("@EDC", EDCTb.Value.Date);
                    cmd.Parameters.AddWithValue("@DateCalved", DateCalvedTb.Value.Date);
                    cmd.Parameters.AddWithValue("@Age", AgeTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breeding Report Saved Successfully");
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
        int key = 0;

        private void BreedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HeatTb.Text = BreedDGV.SelectedRows[0].Cells[1].Value.ToString();
            BreedTb.Text = BreedDGV.SelectedRows[0].Cells[2].Value.ToString();
            CowIDTb.Text = BreedDGV.SelectedRows[0].Cells[3].Value.ToString();
            CowNameTb.Text = BreedDGV.SelectedRows[0].Cells[4].Value.ToString();
            PregTb.Text = BreedDGV.SelectedRows[0].Cells[6].Value.ToString();
            EDCTb.Text = BreedDGV.SelectedRows[0].Cells[7].Value.ToString();
            DateCalvedTb.Text = BreedDGV.SelectedRows[0].Cells[8].Value.ToString();
            AgeTb.Text = BreedDGV.SelectedRows[0].Cells[9].Value.ToString();

            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BreedDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Breed Report to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "delete from BreedTbl where BrId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed Report Deleted Succcesfully");
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
            if (CowIDTb.SelectedIndex == -1 || CowNameTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update BreedTbl set HeatDate='" + HeatTb.Value.Date + "', BreedDate='" + BreedTb.Value.Date + "', CowID=" + CowIDTb.SelectedValue.ToString() + ",CowName='" + CowNameTb.Text + "',PregDate='" + PregTb.Value.Date + "',ExpDateCalve='" + EDCTb.Value.Date + "',DateCalved='" + DateCalvedTb.Value.Date + "',CowAge=" + AgeTb.Text + " where CowID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed Report Updated Succcesfully");
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
