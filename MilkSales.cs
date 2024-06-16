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
using static Bunifu.UI.WinForms.BunifuPictureBox;

namespace DairyFarmSystem
{
    public partial class MilkSales : Form
    {
        public MilkSales()
        {
            InitializeComponent();
            FillEmpId();
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

        private void MilkSales_Load(object sender, EventArgs e)
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

        private void label16_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
        private void FillEmpId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select EmpId from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            EmpIDTb.ValueMember = "EmpId";
            EmpIDTb.DataSource = dt;
            Con.Close();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from MilkSalesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            PriceTb.Text = "";
            QuantityTb.Text = "";
            ClientNameTb.Text = "";
            ClientPhoneTb.Text = "";
            TotalTb.Text = "";

        }

        private void QuantityTb_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(PriceTb.Text) * Convert.ToInt32(QuantityTb.Text);
            TotalTb.Text = "" + total;
        }

        private void SaveTransaction()
        {
            try
            {
                string Sales = "Sales";
                Con.Open();
                string Query = "insert into IncomeTbl values('" + DateTb.Value.Date + "','" + Sales + "'," + TotalTb.Text + ", " + EmpIDTb.SelectedValue.ToString() + ")";
                SqlCommand cmd = new SqlCommand(Query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Expense Saved Succcesfully");

                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpIDTb.SelectedIndex == -1 || PriceTb.Text == "" || ClientNameTb.Text == "" || ClientPhoneTb.Text == "" || QuantityTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO MilkSalesTbl (Date, Uprice, ClientName, ClientPhone, EmpId, Quantity, Amount) VALUES (@SaleDate, @Price, @ClientName, @ClientPhone, @EmpID, @Quantity, @Total)";
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@SaleDate", DateTb.Value.Date);
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(PriceTb.Text));
                        cmd.Parameters.AddWithValue("@ClientName", ClientNameTb.Text);
                        cmd.Parameters.AddWithValue("@ClientPhone", ClientPhoneTb.Text);
                        cmd.Parameters.AddWithValue("@EmpID", int.Parse(EmpIDTb.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(QuantityTb.Text));
                        cmd.Parameters.AddWithValue("@Total", decimal.Parse(TotalTb.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Milk Sold Successfully");
                    }
                    Con.Close();
                    populate();
                    SaveTransaction();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void SalesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
