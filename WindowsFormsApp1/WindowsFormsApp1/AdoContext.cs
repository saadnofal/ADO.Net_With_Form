using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class AdoContext
    {
         
        private static string connectionString = "Server=DESKTOP-HB779TC\\SQLEXPRESS;Database=InhertinceTest;User Id=sa;Password=123456;";
        public void CreateUser(string name, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public  void ReadUsers( DataGridView dataGrid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Users";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGrid.DataSource=dt;
                    }
                }
            }
        }
            public void DeleteAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Delete From Users ";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                   // command.Parameters.Clear();
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                }
            }
        }

        public void UpdateUser(string strID, string name, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (int.TryParse(strID, out int id))
                {
                    string sqlQuery = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {

                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                    }
                }
               
            }
        }

        public void DeleteUser(string strID)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               if(int.TryParse(strID, out int id))
                {
                    string sqlQuery = "DELETE FROM Users WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                    }
                }
               
            }
        }
       /* static void CreateTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // استعلام SQL لإنشاء جدول جديد  
                string sqlQuery = @"  
                    CREATE TABLE Users (  
                        Id INT PRIMARY KEY IDENTITY(1,1),  
                        Name NVARCHAR(100) NOT NULL,  
                        Email NVARCHAR(100) NOT NULL  
                    )";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Table 'Users' created successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error creating table: " + ex.Message);
                    }
                }
            }
        }*/

    }
}

