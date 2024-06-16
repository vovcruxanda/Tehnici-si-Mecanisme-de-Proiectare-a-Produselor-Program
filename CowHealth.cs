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
    public partial class CowHealth : Form
    {
        public CowHealth()
        {
            InitializeComponent();
            FillCowId();
            populate();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void CowHealth_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            string query = "select * from HealthTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HealthDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            EventTb.Text = "";
            DiagnosisTb.Text = "";
            TreatmentTb.Text = "";
            CostTb.Text = "";
            VetNameTb.Text = "";
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
            }
            Con.Close();
        }

        private void DiagnosisTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CowIDTb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIDTb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || DiagnosisTb.Text == "" || TreatmentTb.Text == "" || CostTb.Text == "" || VetNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "insert into HealthTbl values(@CowID, @CowName, @Date, @Event, @Diagnosis, @Treatment, @Cost, @VetName)";
                    using (SqlCommand cmd = new SqlCommand(Query, Con))
                    {
                        cmd.Parameters.AddWithValue("@CowID", CowIDTb.SelectedValue);
                        cmd.Parameters.AddWithValue("@CowName", CowNameTb.Text);
                        cmd.Parameters.AddWithValue("@Date", DateTb.Value.Date);
                        cmd.Parameters.AddWithValue("@Event", EventTb.Text);
                        cmd.Parameters.AddWithValue("@Diagnosis", DiagnosisTb.Text);
                        cmd.Parameters.AddWithValue("@Treatment", TreatmentTb.Text);
                        cmd.Parameters.AddWithValue("@Cost", decimal.Parse(CostTb.Text));
                        cmd.Parameters.AddWithValue("@VetName", VetNameTb.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Health Issue Saved Successfully");
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
        int key = 0;
        private void HealthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = HealthDGV.Rows[e.RowIndex];

                CowIDTb.Text = row.Cells[1].Value.ToString();
                CowNameTb.Text = row.Cells[2].Value.ToString();
                DateTb.Text = row.Cells[3].Value.ToString();
                EventTb.Text = row.Cells[4].Value.ToString();
                DiagnosisTb.Text = row.Cells[5].Value.ToString();
                TreatmentTb.Text = row.Cells[6].Value.ToString();
                CostTb.Text = row.Cells[7].Value.ToString();
                VetNameTb.Text = row.Cells[8].Value.ToString();

                if (string.IsNullOrEmpty(CowNameTb.Text))
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Health Statement to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "delete from HealthTbl where RepId=" + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Report Deleted Succcesfully");
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
            if (CowIDTb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || DiagnosisTb.Text == "" || TreatmentTb.Text == "" || CostTb.Text == "" || VetNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update into HealthTbl set cowId=" + CowIDTb.SelectedValue.ToString() + ",cowname='" + CowNameTb.Text + "',RepDate='" + DateTb.Value.Date + "',Event='" + EventTb.Text + "',Diagnosis='" + DiagnosisTb.Text + "',Treatment='" + TreatmentTb.Text + "',Cost=" + CostTb.Text + ",VetName='" + VetNameTb.Text + "' where RepID=" + key + ";";
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

        private void CowHealth_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
