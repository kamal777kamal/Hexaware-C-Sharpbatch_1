using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Data.SqlClient;

namespace TicketBookingSystem
{
    internal class Admin
    {
        public static void admin()
        {
            Console.WriteLine("----------Select an option to continue----------");
            //options that are displayed for admin
            Console.WriteLine("1, Add new records");
            Console.WriteLine("2, Delete records");
            Console.WriteLine("3, Check the revenue generated");
            Console.WriteLine("4, Check the total tickets booked");
            Console.WriteLine("5, Refresh");

            int Aoption = Convert.ToInt32(Console.ReadLine());


            // Includes task 10 question 5
            if (Aoption == 1)
            {
                InsertData(); //Function for admin to insert new data
            }
            else if (Aoption == 3)
            {
                Revenue(); //Function to check the revenue gennerated
            }
            else if (Aoption == 4)
            {
                Total(); //Function to check the amount of tickets booked
            }
            else if (Aoption == 2)
            {
                DeleteData(); //Function for admin to delete data
            }
            else
            {
                Refresh(); //Function to delete all the data from the table
            }
        }

        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        public static void InsertData()
        {
            con = DBConnection.getConnection();

            Console.WriteLine("Select the table tp update : ");
            Console.WriteLine("1, Venue");
            Console.WriteLine("2, Event Deatails");
            Console.WriteLine("3, Customer");

            int ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 1)
            {
                int venid;
                String venname;
                String add;
                Console.WriteLine("Enter the Venue ID: ");
                venid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Venue name: ");
                venname = Console.ReadLine();
                Console.WriteLine("Enter the venue address: ");
                add = Console.ReadLine();

                cmd = new SqlCommand("insert into Venue (venue_id, venue_name, adress) values (@venid, @venname, @add) ", con);

                cmd.Parameters.AddWithValue("@venid", venid);
                cmd.Parameters.AddWithValue("@venname", venname);
                cmd.Parameters.AddWithValue("@add", add);

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

            else if (ch == 2)
            {
                int eventid;
                String eventname;
                String eventdate;
                String eventtime;
                int available_seats;
                Console.WriteLine("Enter the Event ID: ");
                eventid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Event name: ");
                eventname = Console.ReadLine();

                Console.WriteLine("Enter the Event date: ");
                eventdate = Console.ReadLine();

                Console.WriteLine("Enter the Event time: ");
                eventtime = Console.ReadLine();

                Console.WriteLine("Enter the available seats: ");
                available_seats = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("insert into Event_det (event_id, event_name, event_date, event_time, available_seats) values (@eventid, @eventname, @eventdate, @eventtime, @available_seats)", con);
                cmd.Parameters.AddWithValue("@eventid", eventid);
                cmd.Parameters.AddWithValue("@eventname", eventname);
                cmd.Parameters.AddWithValue("@eventdate", eventdate);
                cmd.Parameters.AddWithValue("@eventtime", eventtime);
                cmd.Parameters.AddWithValue("@available_seats", available_seats);

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
            else if (ch == 3)
            {
                int custid;
                String custname;
                String custmail;
                String custphone;
                int bookid;
                Console.WriteLine("Enter the Customer ID: ");
                custid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Customer name: ");
                custname = Console.ReadLine();

                Console.WriteLine("Enter the Customer email: ");
                custmail = Console.ReadLine();

                Console.WriteLine("Enter the Customer phone number: ");
                custphone = Console.ReadLine();

                Console.WriteLine("Enter the Booking ID: ");
                bookid = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("insert into Customer (customer_id, customer_name, email, phone_number, booking_id) values (@custid, @custname, @custmail, @custphone, @bookid)", con);
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

        public static void DeleteData()
        {

            Console.WriteLine("Select any one option");

            Console.WriteLine("1, Venue");
            Console.WriteLine("2, Event Details");
            Console.WriteLine("3, Customer");
            int ch = Convert.ToInt32(Console.ReadLine());


            if (ch == 1)
            {
                con = DBConnection.getConnection();
                int i;
                String n;
                String a;
                Console.WriteLine("Enter the Venue id to delete: ");
                i = Convert.ToInt32(Console.Read());
                Console.WriteLine("Enter the Venue name to delete: ");
                n = Console.ReadLine();
                Console.WriteLine("Enter the Address to delete: ");
                a = Console.ReadLine();
                cmd = new SqlCommand("delete from Venue where venue_id = @i, venue_name = @n, adress = @a", con);
                cmd.ExecuteNonQuery();
            }
            else if (ch == 2)
            {
                con = DBConnection.getConnection();
                int i;
                String n;
                String d;
                String t;
                int s;
                int ts;
                int avs;
                decimal tp;
                String type;
                int bid;
                String cat;
                Console.WriteLine("Enter the Event id to delete: ");
                i = Convert.ToInt32(Console.Read());

                Console.WriteLine("Enter the Event name to delete: ");
                n = Console.ReadLine();

                Console.WriteLine("Enter the Event date to delete: ");
                d = Console.ReadLine();

                Console.WriteLine("Enter the Event time to delete: ");
                t = Console.ReadLine();

                Console.WriteLine("Enter the available seats to delete: ");
                s = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the total seats to delete: ");
                ts = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the available seats to delete: ");
                avs = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the ticket price to delete: ");
                tp = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter the ticket type to delete: ");
                type = Console.ReadLine();

                Console.WriteLine("Enter the booking id to delete: ");
                bid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the category to delete: ");
                cat = Console.ReadLine();

                cmd = new SqlCommand("delete from Event_det where event_id = @i, event_name = @n, event_date = @d, event_time = @t, available_seats = @s, total_seats = @ts, available_seats = @avs, ticket_price = @tp, ticket_type = @type, booking_id = @bid, category = @cat", con);
                cmd.Parameters.AddWithValue("@i", i);
                cmd.Parameters.AddWithValue("@n", n);
                cmd.Parameters.AddWithValue("@d", d);
                cmd.Parameters.AddWithValue("@t", t);
                cmd.Parameters.AddWithValue("@s", s);
                cmd.Parameters.AddWithValue("@ts", ts);
                cmd.Parameters.AddWithValue("@avs", avs);
                cmd.Parameters.AddWithValue("@tp", tp);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@bid", bid);
                cmd.Parameters.AddWithValue("@cat", cat);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("-----------Deleted Successfully----------");
                }
                else
                {
                    Console.WriteLine("-----------Deletion Failed-----------");
                }

            }

            else
            {
                int cid;
                String cname;
                String cmail;
                String cphone;
                int cbid;
                Console.WriteLine("Enter the Customer ID to delete: ");
                cid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Customer name to delete: ");
                cname = Console.ReadLine();

                Console.WriteLine("Enter the Customer email to delete: ");
                cmail = Console.ReadLine();

                Console.WriteLine("Enter the Customer phone number to delete: ");
                cphone = Console.ReadLine();

                Console.WriteLine("Enter the Booking ID to delete: ");
                cbid = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("delete from Customer where customer_id = @cid, customer_name = @cname, email = @cmail, phone_number = @cphone, booking_id = @cbid", con);
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@cname", cname);
                cmd.Parameters.AddWithValue("@cmail", cmail);
                cmd.Parameters.AddWithValue("@cphone", cphone);
                cmd.Parameters.AddWithValue("@cbid", cbid);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("-----------Deleted Successfully----------");
                }
                else
                {
                    Console.WriteLine("-----------Deletion Failed-----------");
                }
            }
        }

        //Function to check the revenue generated   
        public static void Revenue()
        {
            con = DBConnection.getConnection();
            cmd = new SqlCommand("select sum(total_rev) from Booking");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("Total revenue generated is : ", con);
            }
        }

        //Function to check the total tickets booked
        public static void Total()
        {
            con = DBConnection.getConnection();
            cmd = new SqlCommand("select event_id, booked_tickets from Booking", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int totalTickets = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                Console.WriteLine("Total tickets booked : "+ totalTickets);
            }
        }

        //Fuction to delete all the datas from the table

        public static void Refresh()
        {
            con = DBConnection.getConnection();
            cmd = new SqlCommand("delete from Venue", con);
            cmd = new SqlCommand("delete from Event_det", con);
            cmd = new SqlCommand("delete from Customer", con);
            cmd = new SqlCommand("delete from Bookning", con);

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                Console.WriteLine("-----------Deleted Successfully----------");
            }
            else
            {
                Console.WriteLine("-----------Deletion Failed-----------");
            }
        }
    }
}
