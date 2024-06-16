using System.Data;
using System.Data.SqlClient;

namespace DairyFarmSystem
{
    public partial class Finances : Form
    {
        private IDataPopulator expenditureDataAdapter;
        private IDataPopulator incomeDataAdapter;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Finances()
        {
            InitializeComponent();
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

            expenditureDataAdapter = new ExpenditureDataAdapter(Con);
            incomeDataAdapter = new IncomeDataAdapter(Con);

            populateExp();
            populateInc();
            FillEmpId();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Finances_Load(object sender, EventArgs e)
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
        private void populateExp()
        {
            expenditureDataAdapter.Populate(ExpDGV);
        }
        private void ClearExp()
        {
            AmountTb.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (PurposeTb.SelectedIndex == -1 || AmountTb.Text == "" || EmpIdTb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "INSERT INTO ExpenditureTbl (ExpDate, ExpPurpose, ExpAmount, EmpId) VALUES (@ExpDate, @Purpose, @Amount, @EmpId)";
                    using (SqlCommand cmd = new SqlCommand(Query, Con))
                    {
                        cmd.Parameters.AddWithValue("@ExpDate", ExpDate.Value.Date);
                        cmd.Parameters.AddWithValue("@Purpose", PurposeTb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Amount", decimal.Parse(AmountTb.Text));
                        cmd.Parameters.AddWithValue("@EmpId", int.Parse(EmpIdTb.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Expense Saved Successfully");
                    }
                    Con.Close();
                    populateExp();
                    ClearExp();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void populateInc()
        {
            incomeDataAdapter.Populate(IncDGV);
        }

        private void ClearInc()
        {
            TypeTb.SelectedIndex = -1;
            IncAmountTb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TypeTb.SelectedIndex == -1 || IncAmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "INSERT INTO IncomeTbl (IncDate, IncPurpose, IncAmt, EmpId) VALUES (@IncDate, @IncType, @IncAmount, @EmpId)";
                    using (SqlCommand cmd = new SqlCommand(Query, Con))
                    {
                        cmd.Parameters.AddWithValue("@IncDate", IncDateTb.Value.Date);
                        cmd.Parameters.AddWithValue("@IncType", TypeTb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@IncAmount", decimal.Parse(IncAmountTb.Text));
                        cmd.Parameters.AddWithValue("@EmpId", int.Parse(EmpIdTb.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Income Saved Successfully");
                    }
                    Con.Close();
                    populateInc();
                    ClearInc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void FilterExp()
        {
            expenditureDataAdapter.Filter(ExpDGV, ExpFilter.Value.Date);
        }
        private void ExpFilter_ValueChanged(object sender, EventArgs e)
        {
            FilterExp();
        }
        private void FilterInc()
        {
            incomeDataAdapter.Filter(IncDGV, Filter.Value.Date);
        }
        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            FilterInc();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            populateInc();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            populateExp();
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
            EmpIdTb.ValueMember = "EmpId";
            EmpIdTb.DataSource = dt;
            Con.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
