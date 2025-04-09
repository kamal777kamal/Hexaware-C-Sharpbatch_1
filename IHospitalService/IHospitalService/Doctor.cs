using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace IHospitalService
{
    internal class Doctor
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        public static void doctor()
        {
            Console.WriteLine("Welcome to Doctor's section");
            Console.WriteLine("Select an option to continue: ");
            Console.WriteLine("1. Schedule an appointment");
            Console.WriteLine("2. Cancel appointment");
            Console.WriteLine("3. Update Appointment");
            Console.WriteLine("4. Exit");

            int op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    ScheduleAppointment();
                    break;
                case 2:
                    CancelAppointment();
                    break;
                case 3:
                    UpdateAppointment();
                    break;
                case 4:
                    Console.WriteLine("Thank you for using the Doctor's section.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        public static bool ScheduleAppointment()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("INSERT INTO Appoinment (Appoinment_id, Patient_id, Doctor_id, Appoinment_date, Descript, Stat, Appoinment_time) VALUES (@Appoinment_id, @Patient_id, @Doctor_id, @Appoinment_date, @Descript, @Stat, @Appoinment_time)", con);

            Console.WriteLine("Enter Appointment ID:");
            int Appoinment_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Patient ID:");
            int Patient_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Doctor ID:");
            int Doctor_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Appointment Date (yyyy-MM-dd):");
            DateTime Appoinment_date = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Description:");
            string Descript = Console.ReadLine();

            Console.WriteLine("Enter Status:");
            string Stat = Console.ReadLine();

            Console.WriteLine("Enter Appointment Time (HH:mm):");
            DateTime Appoinment_time = Convert.ToDateTime(Console.ReadLine());

            cmd.Parameters.AddWithValue("@Appoinment_id", Appoinment_id);
            cmd.Parameters.AddWithValue("@Patient_id", Patient_id);
            cmd.Parameters.AddWithValue("@Doctor_id", Doctor_id);
            cmd.Parameters.AddWithValue("@Appoinment_date", Appoinment_date);
            cmd.Parameters.AddWithValue("@Descript", Descript);
            cmd.Parameters.AddWithValue("@Stat", Stat);
            cmd.Parameters.AddWithValue("@Appoinment_time", Appoinment_time);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Appointment scheduled successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to schedule appointment.");
                return false;
            }
        }

        public static bool CancelAppointment()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("DELETE FROM Appoinment WHERE Appoinment_id = @Appoinment_id", con);

            Console.WriteLine("Enter the Appointment ID to cancel: ");
            int Appoinment_id = Convert.ToInt32(Console.ReadLine());

            cmd.Parameters.AddWithValue("@Appoinment_id", Appoinment_id);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Appointment cancelled successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to cancel appointment.");
                return false;
            }
        }

        public static bool UpdateAppointment()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("UPDATE Appoinment SET Patient_id = @Patient_id, Doctor_id = @Doctor_id, Appoinment_date = @Appoinment_date, Descript = @Descript, Stat = @Stat, Appoinment_time = @Appoinment_time WHERE Appoinment_id = @Appoinment_id", con);

            Console.WriteLine("Enter Appointment ID:");
            int Appoinment_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Patient ID:");
            int Patient_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Doctor ID:");
            int Doctor_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Appointment Date (yyyy-MM-dd):");
            DateTime Appoinment_date = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Description:");
            string Descript = Console.ReadLine();

            Console.WriteLine("Enter Status:");
            string Stat = Console.ReadLine();

            Console.WriteLine("Enter Appointment Time (HH:mm):");
            DateTime Appoinment_time = Convert.ToDateTime(Console.ReadLine());

            cmd.Parameters.AddWithValue("@Appoinment_id", Appoinment_id);
            cmd.Parameters.AddWithValue("@Patient_id", Patient_id);
            cmd.Parameters.AddWithValue("@Doctor_id", Doctor_id);
            cmd.Parameters.AddWithValue("@Appoinment_date", Appoinment_date);
            cmd.Parameters.AddWithValue("@Descript", Descript);
            cmd.Parameters.AddWithValue("@Stat", Stat);
            cmd.Parameters.AddWithValue("@Appoinment_time", Appoinment_time);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Appointment updated successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to update appointment.");
                return false;
            }
        }
    }
}