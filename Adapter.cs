using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFarmSystem
{
    public interface IDataPopulator
    {
        void Populate(DataGridView dgv);
        void Filter(DataGridView dgv, DateTime date);
    }

    public class ExpenditureDataAdapter : IDataPopulator
    {
        private SqlConnection _con;

        public ExpenditureDataAdapter(SqlConnection con)
        {
            _con = con;
        }

        public void Populate(DataGridView dgv)
        {
            _con.Open();
            string query = "select * from ExpenditureTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, _con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            _con.Close();
        }

        public void Filter(DataGridView dgv, DateTime date)
        {
            _con.Open();
            string query = "select * from ExpenditureTbl where ExpDate = @ExpDate";
            SqlDataAdapter sda = new SqlDataAdapter(query, _con);
            sda.SelectCommand.Parameters.AddWithValue("@ExpDate", date);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            _con.Close();
        }
    }

    public class IncomeDataAdapter : IDataPopulator
    {
        private SqlConnection _con;

        public IncomeDataAdapter(SqlConnection con)
        {
            _con = con;
        }

        public void Populate(DataGridView dgv)
        {
            _con.Open();
            string query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, _con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            _con.Close();
        }

        public void Filter(DataGridView dgv, DateTime date)
        {
            _con.Open();
            string query = "select * from IncomeTbl where IncDate = @IncDate";
            SqlDataAdapter sda = new SqlDataAdapter(query, _con);
            sda.SelectCommand.Parameters.AddWithValue("@IncDate", date);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            _con.Close();
        }
    }


}
