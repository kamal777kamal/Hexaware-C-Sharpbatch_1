using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;


//Task 9 creation of mainmod

namespace IHospitalService
{
    internal class mainmod
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to IHospitalService");

            Console.WriteLine("Select an option to continue: ");

            Console.WriteLine("1. Doctor");
            Console.WriteLine("2. Patient");
            Console.WriteLine("3. Visitor");
            Console.WriteLine("4. Admin");
            Console.WriteLine("5. Exit");

            int op = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
            {
                Doctor.doctor();
            }
            else if (op == 2)
            {
                Patient.patient();
            }
            else if (op == 3)
            {
                Visitor.visitor();
            }
            else if (op == 4)
            {
                Admin.admin();
            }
            else if (op == 5)
            {
                Console.WriteLine("Thank you....");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }

        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;


        //Task 7
        public static SqlConnection DBConnection()
        {
                con = new SqlConnection("Data Source=KAMAL;Initial Catalog=hospitalservice;Integrated Security=True;TrustServerCertificate=true;");
                con.Open();
            return con;
        }
    }
}
