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
    public partial class Employees : Form
    {
        private IEmployeeStrategy employeeStrategy;
        public Employees()
        {
            InitializeComponent();
            populate();
            employeeStrategy = new DefaultEmployeeStrategy();

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void populate()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            PhoneTb.Text = "";
            EmpNameTb.Text = "";
            AddressTb.Text = "";
            GenCb.SelectedIndex = -1;
            PassTb.Text = "";
            key = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    employeeStrategy.ProcessEmployee(Con, EmpNameTb.Text, DOB.Value.Date, GenCb.SelectedItem.ToString(), PhoneTb.Text, PassTb.Text, AddressTb.Text);
                    MessageBox.Show("Employee Saved Successfully");
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
        int key = 0;
        private void EmployeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the row index is valid
            {
                DataGridViewRow row = EmployeesDGV.Rows[e.RowIndex];

                EmpNameTb.Text = row.Cells[1].Value.ToString();
                DOB.Value = Convert.ToDateTime(row.Cells[2].Value);
                GenCb.SelectedItem = row.Cells[3].Value.ToString();
                PhoneTb.Text = row.Cells[4].Value.ToString();
                AddressTb.Text = row.Cells[5].Value.ToString();
                PassTb.Text = row.Cells[6].Value.ToString();

                if (string.IsNullOrEmpty(EmpNameTb.Text))
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(row.Cells[0].Value);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Employee to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    employeeStrategy.DeleteEmployee(Con, key);
                    MessageBox.Show("Employee Deleted Succcesfully");
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
            if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string Query = "update EmployeeTbl set EmpName='" + EmpNameTb.Text + "', EmpDOB='" + DOB.Value.Date + "', Gender=" + GenCb.SelectedItem.ToString() + ",Phone='" + PhoneTb.Text + "',Address='" + AddressTb.Text + "',EmpPass=" + PassTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Succcesfully");
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
