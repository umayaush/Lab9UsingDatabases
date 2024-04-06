using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Lab9UsingDatabases
{
    public class Courses
    {
        // Connection string to connect to MySQL Students database
        private string connstring = "server=localhost;uid=root;pwd=Minimuffs116!;database=students";
        
        // Creates a new course
        public void Create(int courseID, string name, int credits)
        {
            // Establishing a connection to the database
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();

            // Defining SQL query
            string sql = "insert into Courses (CourseID, `Name`, Credits) values (@CourseID, @Name, @Credits)";
            
            // Creating command
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // Adding parameters to the command
            cmd.Parameters.AddWithValue("@CourseID", courseID);
            cmd.Parameters.AddWithValue ("@Name", name);
            cmd.Parameters.AddWithValue("@Credits", credits);

            // Confirms course has been created with no errors
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Course created." : "Failed to create course.");
            conn.Close();
        }

        // Reads and displays all courses
        public void Read()
        {
            // Establishing a connection to the database
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();

            // Defining sql query
            string sql = "select * from courses";

            // Creating command
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // Retrieving the data executed by the query
            MySqlDataReader reader = cmd.ExecuteReader();

            // Displaying column headers
            Console.WriteLine("{0,-10} {1,-45} {2,-10}", "CourseId", "Name", "Credits"); while (reader.Read())
            {
                // Retriving values for each column
                int courseId = reader.GetInt32(0);
                string name = reader.GetString(1);
                int credits = reader.GetInt32(2);

                // Displaying values of each column
                Console.WriteLine("{0,-10} {1,-45} {2,-10}", courseId, name, credits);
            }
            reader.Close();
            conn.Close();
        }

        // Updates an existing course
        public void Update(int courseID, string newName, int newCredits)
        {
            // Establishing connection to the database
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();

            // Defining sql query
            string sql = "update Courses set `Name` = @NewName, Credits = @NewCredits where CourseID = @CourseID";
            
            // Creating command
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // Adding parameters to the command
            cmd.Parameters.AddWithValue("@NewName", newName);
            cmd.Parameters.AddWithValue("@NewCredits", newCredits);
            cmd.Parameters.AddWithValue("@CourseID", courseID);

            // Confirms course has been updated with no errors
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Course updated." : "Failed to update course.");
            conn.Close();
        }

        // Deletes an existing course
        public void Delete(int courseID) 
        {
            // Establishing a conncection to the database
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();

            // Defing sql query
            string sql = "delete from Courses where CourseID = @CourseID";
            
            // Creating command
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // Adding parameters to the command
            cmd.Parameters.AddWithValue("@CourseID", courseID);


            // Confirms course has been deleted with no errors
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Course deleted." : "Failed to delete course.");
            conn.Close();
        }

    }
}
