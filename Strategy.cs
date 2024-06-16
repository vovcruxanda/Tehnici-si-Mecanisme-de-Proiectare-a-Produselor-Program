using System;
using System.Data.SqlClient;

namespace DairyFarmSystem
{
    public interface IEmployeeStrategy
    {
        void ProcessEmployee(SqlConnection connection, string empName, DateTime dob, string gender, string phone, string address, string password, int empId = 0);
        void DeleteEmployee(SqlConnection connection, int empId);
    }

    public class DefaultEmployeeStrategy : IEmployeeStrategy
    {
        public void ProcessEmployee(SqlConnection connection, string empName, DateTime dob, string gender, string phone, string address, string password, int empId = 0)
        {
            if (empId == 0)
            {
                // Save employee
                string query = "INSERT INTO EmployeeTbl (EmpName, EmpDOB, Gender, Phone, Address, EmpPass) VALUES (@EmpName, @DOB, @Gender, @Phone, @Address, @EmpPass)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EmpName", empName);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@EmpPass", password);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                // Update employee
                string query = "UPDATE EmployeeTbl SET EmpName = @EmpName, EmpDOB = @DOB, Gender = @Gender, Phone = @Phone, Address = @Address, EmpPass = @EmpPass WHERE EmpId = @EmpId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EmpName", empName);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.Parameters.AddWithValue("@EmpPass", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(SqlConnection connection, int empId)
        {
            // Delete employee
            string query = "DELETE FROM EmployeeTbl WHERE EmpId = @EmpId";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
