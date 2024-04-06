using MySql.Data.MySqlClient;


namespace Lab9UsingDatabases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating instance of Course class
            Courses courses = new Courses();

            //Displaying/reading existing courses
            Console.WriteLine("Reading and Displaying Courses:");
            courses.Read();

            // Creating a new course
            Console.WriteLine("\nCreating Course:");
            courses.Create(1006, "New Course", 2);

            // Displaying courses after creating a new one
            Console.WriteLine("\nDisplaying Courses:");
            courses.Read();

            // Updating a course
            Console.WriteLine("\nUpdating Course:");
            courses.Update(1006, "Updated Course", 3);

            // Displaying courses after updating one of them
            Console.WriteLine("\nDisplaying Courses:");
            courses.Read();

            // Deleting a course
            Console.WriteLine("\nDeleting Course:");
            courses.Delete(1006);

            // Displaying courses after deleting one of them
            Console.WriteLine("\nDisplaying Courses:");
            courses.Read();
        }
    }
}
