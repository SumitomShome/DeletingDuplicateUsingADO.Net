using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DuplicateRemoval
{
    class DeletingDuplicate
    {
        public static string connectionString = @"Data Source= DESKTOP-RA9N9FA\SQLEXPRESS; Initial Catalog=PracticeDB;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            Model model = new Model();
            using (this.connection)
            {
                try
                {
                    string query = @"SELECT * FROM PracticeTable2;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            model.Name = dr.GetString(0);
                            model.email = dr.GetString(1);
                            model.address = dr.GetString(2);
                            System.Console.WriteLine(model.Name + " " + model.email + " " + model.address);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
        }
        public void DeleteDuplicateRecord()
        {
            using (this.connection)
            {
                try
                {
                    string query1 = @"SELECT DISTINCT * INTO PracticeTableNewlyCreated FROM PracticeTable2;";
                    string query2 = @"DROP TABLE PracticeTable2;";
                    string query3 = @"EXEC sp_rename 'PracticeTableNewlyCreated', 'PracticeTable2';";
                    SqlCommand cmd1 = new SqlCommand(query1, this.connection);
                    SqlCommand cmd2 = new SqlCommand(query2, this.connection);
                    SqlCommand cmd3 = new SqlCommand(query3, this.connection);
                    this.connection.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    this.connection.Close();
                    this.connection.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    this.connection.Close();
                    this.connection.Open();
                    SqlDataReader dr3 = cmd3.ExecuteReader();
                    this.connection.Close();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
        }
        public bool AddEmployee(Model model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeePayrollDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.Name);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@address", model.address);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}