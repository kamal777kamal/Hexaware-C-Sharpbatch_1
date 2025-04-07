using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace VirtualArtGallery
{
    internal class DBConnection
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------Welcome to VirtualArtGallery--------------------");
            Console.WriteLine("--------Select an option to continue--------");
            Console.WriteLine("Management");
            Console.WriteLine("User");

            String temp = Console.ReadLine();

            if(temp == "Management")
            {
                Management.Admin();
            }
            else if (temp == "User")
            {
                User.user();
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
        public static SqlConnection getConnection()
        {
            if (con == null || con.State == ConnectionState.Closed)
            {
                con = new SqlConnection("Data Source=KAMAL;Initial Catalog=VirtualArtGallery;Integrated Security=True;TrustServerCertificate=true;");
                con.Open();
            }
            return con;
        }
    }
}
