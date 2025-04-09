using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace IHospitalService
{
    internal class Visitor
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        public static void visitor()
        {
            con = mainmod.DBConnection();
            cmd = new SqlCommand("select * from Patient where Patient_id=@pt_id", con);

            Console.WriteLine("Enter Patient_id");
            int Patient_id = Convert.ToInt32(Console.ReadLine());

            cmd.Parameters.AddWithValue("@pt_id", Patient_id);
            dr = cmd.ExecuteReader();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("Patient_id: " + dr["Patient_id"]);
                        Console.WriteLine("First_name: " + dr["First_name"]);
                        Console.WriteLine("Last_name: " + dr["Last_name"]);
                        Console.WriteLine("DateofBirth: " + dr["DateofBirth"]);
                        Console.WriteLine("Gender: " + dr["Gender"]);
                        Console.WriteLine("Addres: " + dr["Addres"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Patient not found..." + ex.Message);
            }
        }
    }
}
