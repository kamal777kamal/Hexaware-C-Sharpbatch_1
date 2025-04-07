using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TicketBookingSystem
{
    internal class User
    {
        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;
        public static void user()
        {
            Console.WriteLine("----------Select an option to continue----------");
            //options that are displayed for users
            Console.WriteLine("1, Book Tickets");
            Console.WriteLine("2, Check ticket availability");
            Console.WriteLine("3, Check available events");
            Console.WriteLine("4, Check about venue");

            int Uoption = Convert.ToInt32(Console.ReadLine()); // To take input from user for performing operations
            if (Uoption == 1)
            {
                BookTicket(); //Function for users to book ticket
            }
            else if (Uoption == 2)
            {
                CheckTickets(); //Function for users to check the availability of tickets
            }
            else if (Uoption == 3)
            {
                CheckEvents(); //Function for users to check the available events
            }
            else
            {
                CheckVenue(); //Funstion for users to check the details of the venues
            }
        }

        //Includes task 10 question 4 question 9

        public static void BookTicket()
        {
            int cid;
            String cname;
            String cmail;
            int cphone;
            int cbid;

            con = DBConnection.getConnection();

            SqlCommand cmd1;

            String availTick;
            cmd1 = new SqlCommand(" Select event_name, available_seats from Event_det", con);
            dr = cmd1.ExecuteReader();
            
            char temp;

            while (dr.Read())
            {
                Console.WriteLine("event name  |  available seats");
                Console.WriteLine($"{dr["event_name"]} | {dr["available_seats"]}");
                Console.WriteLine(" Do you like to continue (y/n)");

                temp = Convert.ToChar(Console.ReadLine());
                if (temp == 'n')
                {
                    Console.WriteLine("-----------Booking cancelled-----------");
                    break;
                }

                else
                {

                    int custid;
                    String custname;
                    String custmail;
                    int custphone;
                    int bookid;

                    Console.WriteLine("Enter the Customer ID: ");
                    custid = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Customer name: ");
                    custname = Console.ReadLine();

                    Console.WriteLine("Enter the Customer email: ");
                    custmail = Console.ReadLine();

                    Console.WriteLine("Enter the Customer phone number: ");
                    custphone = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Booking ID: ");
                    bookid = Convert.ToInt32(Console.ReadLine());

                    dr = cmd.ExecuteReader();
                    cmd = new SqlCommand("insert into customers (customer_id, customer_name, email, phone_number, booking_id) values (@custid, @custname, @custmail, @custphone, @bookid)", con);
                    cmd.Parameters.AddWithValue("@custid", custid);
                    cmd.Parameters.AddWithValue("@custname", custname);
                    cmd.Parameters.AddWithValue("@custmail", custmail);
                    cmd.Parameters.AddWithValue("@custphone", custphone);
                    cmd.Parameters.AddWithValue("@bookid", bookid);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Console.WriteLine("-----------Updated Successfully----------");
                    }
                    else
                    {
                        Console.WriteLine("-----------Updation Failed-----------");
                    }
                }
            }
        }
        public static void CheckTickets()
        {
            con = DBConnection.getConnection();
            cmd = new SqlCommand("select event_name, available_seats from Event_det", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("event name  |  available seats");
                Console.WriteLine($"{dr["event_name"]} | {dr["available_seats"]}");
            }

        }
        public static void CheckEvents()
        {
            con = DBConnection.getConnection();
            cmd = new SqlCommand("select * from Event_det", con);
            dr = cmd.ExecuteReader();

            Console.WriteLine("-----The available events are mentioned below-----");
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " " + dr[1]);
            }
        }
        public static void CheckVenue()
        {
            con = DBConnection.getConnection();
            cmd = new SqlCommand("select * from Venue", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " " + dr[1]);
            }
        }
    }
}
