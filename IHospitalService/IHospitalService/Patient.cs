using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace IHospitalService
{
    internal class Patient
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        public static void patient()
        {
            Console.WriteLine("Welcome to Patient's section");
            Console.WriteLine("Select an option to continue:");

            Console.WriteLine("1. Get appointment by id");
            Console.WriteLine("2. Get appointment for doctors");
            Console.WriteLine("3. Exit");

            int op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    getAppointmentById();
                    break;
                case 2:
                    getAppointmentForDoctors();
                    break;
                case 3:
                    Console.WriteLine("Thank you....");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        public static void getAppointmentById()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("SELECT * FROM Appoinment WHERE Appoinment_id = @Appoinment_id", con);

            Console.WriteLine("Enter Appoinment_id:");
            int Appoinment_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@Appoinment_id", Appoinment_id);

            try
            {
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("\n--- Appointment Details ---");
                        Console.WriteLine("Appoinment_id: " + dr["Appoinment_id"]);
                        Console.WriteLine("Patient_id: " + dr["Patient_id"]);
                        Console.WriteLine("Doctor_id: " + dr["Doctor_id"]);
                        Console.WriteLine("Appoinment_date: " + dr["Appoinment_date"]);
                        Console.WriteLine("Descript: " + dr["Descript"]);
                        Console.WriteLine("Stat: " + dr["Stat"]);
                        Console.WriteLine("Appoinment_time: " + dr["Appoinment_time"]);
                    }
                }
                else
                {
                    Console.WriteLine("No appointment found.");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void getAppointmentForDoctors()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("SELECT * FROM Appoinment WHERE Appoinment_id = @app_id", con);

            Console.WriteLine("Enter Appoinment_id:");
            int Appoinment_id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@app_id", Appoinment_id);

            try
            {
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("\n--- Appointment Details ---");
                        Console.WriteLine("Appoinment_id: " + dr["Appoinment_id"]);
                        Console.WriteLine("Patient_id: " + dr["Patient_id"]);
                        Console.WriteLine("Doctor_id: " + dr["Doctor_id"]);
                        Console.WriteLine("Appoinment_date: " + dr["Appoinment_date"]);
                        Console.WriteLine("Descript: " + dr["Descript"]);
                        Console.WriteLine("Stat: " + dr["Stat"]);
                        Console.WriteLine("Appoinment_time: " + dr["Appoinment_time"]);
                    }
                }
                else
                {
                    Console.WriteLine("No appointments found.");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}