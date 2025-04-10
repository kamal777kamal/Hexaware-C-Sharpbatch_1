﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace VirtualArtGallery
{
    internal class User
    {


        static SqlConnection con = null;
        static SqlCommand cmd;
        static SqlDataReader dr;

        public static void user()
        {

            Console.WriteLine("Welcome to the User section of the Virtual Art Gallery!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add to favourite");
            Console.WriteLine("2. Remove from favaourite");
            Console.WriteLine("3. Get favourite");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    addFavourite();
                    break;
                case "2":
                    removeFavourite();
                    break;
                case "3":
                    getFavourite();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

        //Fuction to add artwork to favourites
        public static void addFavourite()
        {
            Console.WriteLine("Enter the artwork ID to add to favourites:");
            int Art_id = Convert.ToInt32(Console.ReadLine());

            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Favourites (Art_id) VALUES (@Art_id)", con);

            cmd.Parameters.AddWithValue("@Art_id", Art_id);
            cmd.ExecuteNonQuery();

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Artwork added to favourites successfully.");
                return;
            }
            else
            {
                Console.WriteLine("Artwork already exists in favourites.");
            }
        }

        //Function to remove an artwork from favourites
        public static void removeFavourite()
        {
            Console.WriteLine("Enter the artwork ID to remove from favourites:");
            int Art_id = Convert.ToInt32(Console.ReadLine());

            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Favourites WHERE Art_id = @Art_id", con);

            cmd.Parameters.AddWithValue("@Art_id", Art_id);
            cmd.ExecuteNonQuery();

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine("Artwork removed from favourites successfully.");
            }
            else
            {
                Console.WriteLine("Artwork not found in favourites.");
            }
        }

        //Function to get all favourite artworks
        public static ArrayList getFavourite()
        {
            SqlConnection con = DBConnection.getConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Favourites", con);
            SqlDataReader dr = cmd.ExecuteReader();

            Console.WriteLine("Your favourite artworks are:");

            ArrayList favArt = new ArrayList();

            while (dr.Read())
            {
                Console.WriteLine("Art_id: " + dr["Art_id"]);
                favArt.Add(dr["Art_id"]);
            }
            return favArt;
        }


    }
}
