using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
namespace TicketBookingSystem
{
    internal class DBConnection
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        //Main function
        static void Main(string[] args)
        {

            Console.WriteLine("--------------------Welcome to Ticket Booking System--------------------");

            Console.WriteLine("--------------------Select an option to continue--------------------");

            Console.WriteLine("Admin");
            Console.WriteLine("User");

            String option = Console.ReadLine();

            if(option == "Admin")
            {
                Admin.admin();
            }
            else if (option == "User")
            {
                User.user();
            }
        }

        //Function for database connectivity, task 11 question 6
        public static SqlConnection getConnection()
        {
            if (con == null || con.State == ConnectionState.Closed)
            {
                con = new SqlConnection("data source=KAMAL;initial catalog=TicketBookingSystem;integrated security=true;TrustServerCertificate=true;");
                con.Open();
            }
            return con;
        }
    }
}