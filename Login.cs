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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            UserTb.Text = "";
            FarmTb.Text = "";
            PassTb.Text = "";
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\DairyFarmDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PassTb.Text == "" || UserTb.Text == "")
            {
                MessageBox.Show("Select Role");
            }
            else
            if (RoleTb.SelectedIndex > -1)
            {
                if (RoleTb.SelectedItem.ToString() == "Admin")
                {
                    Employees emp = new Employees();
                    emp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Admin Name or Password");
                }
            }
            else
            if (RoleTb.SelectedItem.ToString() == "Employee")
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from EmployeeTbl where EmpName='" + UserTb.Text + "' and EmpPass='" + PassTb.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Cows Cow = new Cows();
                    Cow.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password");
                }
                Con.Close();
            }
        }
    }
}
