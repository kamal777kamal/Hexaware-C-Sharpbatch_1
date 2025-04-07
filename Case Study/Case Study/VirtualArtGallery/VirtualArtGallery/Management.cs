using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery
{
    internal class Management
    {
        public static void Admin()
        {
            Console.WriteLine("Welcome to the Management section of the Virtual Art Gallery!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add Artwork");
            Console.WriteLine("2. Remove Artwork");
            Console.WriteLine("3. Update Artwork");
            Console.WriteLine("4. View ArtWork by ID");
            Console.WriteLine("5, Search Artwork");
            Console.WriteLine("6, Exit");   
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Code to add artwork

                    break;
                case "2":
                    // Code to remove artwork
                    break;
                case "3":
                    // Code to update artwork details
                    break;
                case "4":
                    // Code to view all artworks
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
