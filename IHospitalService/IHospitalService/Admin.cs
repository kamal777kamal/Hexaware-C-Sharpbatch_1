using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace IHospitalService
{
    internal class Admin
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;
        public static void admin()
        {
            Console.WriteLine("Select an option to conitinue");
            Console.WriteLine("1. Add new patient");
            Console.WriteLine("2. Delete Existing patient");
            Console.WriteLine("3. Add new docctor");
            Console.WriteLine("4. Delete new doctor");
            Console.WriteLine("5. Exit");

            int op = Convert.ToInt32(Console.ReadLine());

            if (op == 1)
            {
                // Function call to add new patient
                AddNewPatient();
            }
            else if (op == 2)
            {
                // Function call to delete existing patient
                DeleteExistingPatient();
            }
            else if (op == 3)
            {
                // Function call to add new doctor
                AddNewDoctor();
            }
            else if (op == 4)
            {
                // Function call to delete existing doctor
                DeleteExistingDoctor();
            }
            else if (op == 5)
            {
                Console.WriteLine("Thank you....");
                Environment.Exit(0);
            }
        }

        public static void AddNewPatient()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand ("insert into Patient(Patient_id, First_name, Last_name, DateofBirth, Gender, Contact_number, Addres) values (@Patient_id, @First_name, @Last_name, @DateofBirth, @Gender, @Contact_number, @Addres)", con);

            Console.WriteLine("Enter Patient_id");
            int Patient_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter First_name");
            string First_name = Console.ReadLine();

            Console.WriteLine("Enter Last_name");
            string Last_name = Console.ReadLine();

            Console.WriteLine("Enter DateofBirth");
            DateTime DateofBirth = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Gender");
            string Gender = Console.ReadLine();

            Console.WriteLine("Enter Contact_number");
            string Contact_number = Console.ReadLine();

            Console.WriteLine("Enter Addres");
            string Addres = Console.ReadLine();

            cmd.Parameters.AddWithValue("@Patient_id", Patient_id);
            cmd.Parameters.AddWithValue("@First_name", First_name);
            cmd.Parameters.AddWithValue("@Last_name", Last_name);
            cmd.Parameters.AddWithValue("@DateofBirth", DateofBirth);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@Contact_number", Contact_number);
            cmd.Parameters.AddWithValue("@Addres", Addres);
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Patient added successfully");
                }
                else
                {
                    Console.WriteLine("Failed to add patient");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        public static void DeleteExistingPatient()
        {
            con =
                mainmod.DBConnection();
            cmd = new SqlCommand("delete from Patient where Patient_id=@Patient_id", con);
            Console.WriteLine("Enter Patient_id");
            int Patient_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@Patient_id", Patient_id);
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Patient deleted successfully");
                }
                else
                {
                    Console.WriteLine("Failed to delete patient");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void AddNewDoctor()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("insert into Doctor (Doctor_id, First_name, Last_name, Specialization, Contact_number) values (@Doctor_id, @First_name, @Last_name, @Specialization, @Contact_number)", con);

            Console.WriteLine("Enter Doctor_id");
            int Doctor_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter First_name");
            string First_name = Console.ReadLine();

            Console.WriteLine("Enter Last_name");
            string Last_name = Console.ReadLine();

            Console.WriteLine("Enter Specialization");
            string Specialization = Console.ReadLine();

            Console.WriteLine("Enter Contact_number");
            string Contact_number = Console.ReadLine();

            cmd.Parameters.AddWithValue("@Doctor_id", Doctor_id);
            cmd.Parameters.AddWithValue("@First_name", First_name);
            cmd.Parameters.AddWithValue("@Last_name", Last_name);
            cmd.Parameters.AddWithValue("@Specialization", Specialization);
            cmd.Parameters.AddWithValue("@Contact_number", Contact_number);

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Doctor added successfully");
                }
                else
                {
                    Console.WriteLine("Failed to add doctor");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void DeleteExistingDoctor()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("delete from Doctor where Doctor_id=@Doctor_id", con);

            Console.WriteLine("Enter Doctor_id");
            int Doctor_id = Convert.ToInt32(Console.ReadLine());

            cmd.Parameters.AddWithValue("@Doctor_id", Doctor_id);

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Doctor deleted successfully");
                }
                else
                {
                    Console.WriteLine("Failed to delete doctor");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
