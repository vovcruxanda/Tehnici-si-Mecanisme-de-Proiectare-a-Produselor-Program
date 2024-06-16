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
    public partial class Cows : Form
    {
        private readonly DatabaseFacade Con;
        public Cows()
        {
            InitializeComponent();
            Con = new DatabaseFacade(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");
            populate();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        { }

        private void panel4_Paint(object sender, PaintEventArgs e)
        { }

        private void panel5_Paint(object sender, PaintEventArgs e)
        { }

        private void panel6_Paint(object sender, PaintEventArgs e)
        { }

        private void panel7_Paint(object sender, PaintEventArgs e)
        { }

        private void panel8_Paint(object sender, PaintEventArgs e)
        { }

        private void panel9_Paint(object sender, PaintEventArgs e)
        { }

        private void label2_Click(object sender, EventArgs e)
        { }

        private void label13_Click(object sender, EventArgs e)
        { }

        private void OpenForm(IFormFactory formFactory)
        {
            Form form = formFactory.CreateForm();
            form.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OpenForm(new CowsFactory());
        }

        private void label15_Click(object sender, EventArgs e)
        {
            OpenForm(new MilkSalesFactory());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            OpenForm(new MilkProductionFactory());
        }

        private void label8_Click(object sender, EventArgs e)
        {
            OpenForm(new CowHealthFactory());
        }

        private void label14_Click(object sender, EventArgs e)
        {
            OpenForm(new BreedingFactory());
        }

        private void label16_Click(object sender, EventArgs e)
        {
            OpenForm(new FinancesFactory());
        }

        private void label17_Click(object sender, EventArgs e)
        {
            OpenForm(new DashboardFactory());
        }
        private void populate()
        {
            Con.OpenConnection();
            DataTable dt = Con.ExecuteSelectQuery("Select * From CowTbl");
            CowsDGV.DataSource = dt;
            Con.CloseConnection();
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            EarTagTb.Text = "";
            ColorTb.Text = "";
            BreedTb.Text = "";
            WeightTb.Text = "";
            AgeTb.Text = "";
            PastureTb.Text = "";
            key = 0;
        }

        int age = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeightTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.OpenConnection();
                    string Query = "insert into CowTbl values('" + CowNameTb.Text + "','" + EarTagTb.Text + "','" + ColorTb.Text + "','" + BreedTb.Text + "'," + age + "," + WeightTb.Text + ",'" + PastureTb.Text + "')";
                    Con.ExecuteNonQuery(Query);

                    MessageBox.Show("Cow Saved Succcesfully");

                    Con.CloseConnection();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        private void Cows_Load(object sender, EventArgs e)
        {

        }

        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            MessageBox.Show("" + age);
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
            AgeTb.Text = "" + age;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void CowsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = CowsDGV.Rows[e.RowIndex];

                CowNameTb.Text = row.Cells[1].Value.ToString();
                EarTagTb.Text = row.Cells[2].Value.ToString();
                ColorTb.Text = row.Cells[3].Value.ToString();
                BreedTb.Text = row.Cells[4].Value.ToString();
                WeightTb.Text = row.Cells[6].Value.ToString();
                PastureTb.Text = row.Cells[7].Value.ToString();

                if (string.IsNullOrEmpty(CowNameTb.Text))
                {
                    key = 0;
                    age = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0].Value);
                    age = Convert.ToInt32(row.Cells[5].Value);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Cow to be Deleted");
            }
            else
            {
                try
                {
                    Con.OpenConnection();
                    string Query = "delete from CowTbl where CowID=" + key + ";";

                    Con.ExecuteNonQuery(Query);
                    MessageBox.Show("Cow Deleted Succcesfully");
                    Con.CloseConnection();
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
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeightTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.OpenConnection();
                    string Query = "update CowTbl set CowName='" + CowNameTb.Text + "', EarTag='" + EarTagTb.Text + "', Color='" + ColorTb.Text + "',Breed='" + BreedTb.Text + "',Age=" + age + ",WeightAtBirth=" + WeightTb.Text + ",Pasture='" + PastureTb.Text + "' where CowID=" + key + ";";

                    Con.ExecuteNonQuery(Query);
                    MessageBox.Show("Cow Updated Succcesfully");
                    Con.CloseConnection();
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
