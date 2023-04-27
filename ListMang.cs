using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PA5{
    public static class ListingDataManagement{
        private static List<Listing> listings = new List<Listing>();
        private static string listingsFilePath = "listings.txt";

        public static void ManageListings(){
            LoadListingsFromFile();

            int choice;
            do{
                Console.Clear();
                Console.WriteLine("Listing Data Management");
                Console.WriteLine("1. Add Listing");
                Console.WriteLine("2. Edit Listing");
                Console.WriteLine("3. Delete Listing");
                Console.WriteLine("4. List Listings");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        AddListing();
                        break;
                    case 2:
                        EditListing();
                        break;
                    case 3:
                        DeleteListing();
                        break;
                    case 4:
                        ListListings();
                        break;
                    case 5:
                        Console.WriteLine("Returning to the main menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }
            } while (choice != 5);

            SaveListingsToFile();
        }

        private static void LoadListingsFromFile(){
            if (File.Exists(listingsFilePath)){
                using (StreamReader reader = new StreamReader(listingsFilePath)){
                    string line;
                    while ((line = reader.ReadLine()) != null){
                        string[] data = line.Split('#');
                        int id = int.Parse(data[0]);
                        string trainerName = data[1];
                        DateTime sessionDate = DateTime.Parse(data[2]);
                        TimeSpan sessionTime = TimeSpan.Parse(data[3]);
                        decimal cost = decimal.Parse(data[4]);
                        bool isTaken = bool.Parse(data[5]);
                        Listing listing = new Listing(id, trainerName, sessionDate, sessionTime, cost, isTaken);
                        listings.Add(listing);
                    }
                }
            }
        }

        private static void SaveListingsToFile(){
            using (StreamWriter writer = new StreamWriter(listingsFilePath)){
                foreach (Listing listing in listings){
                    string line = $"{listing.ListingId}#{listing.TrainerName}#{listing.SessionDate}#{listing.SessionTime}#{listing.Cost}#{listing.IsTaken}";
                    writer.WriteLine(line);
                }
            }
        }

        private static void AddListing(){
            Console.Write("Enter Listing ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Trainer Name: ");
            string trainerName = Console.ReadLine();
            Console.Write("Enter Date of the Session (yyyy-MM-dd): ");
            DateTime sessionDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Time of the Session (HH:mm): ");
            TimeSpan sessionTime = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Enter Cost of the Session: ");
            decimal cost = decimal.Parse(Console.ReadLine());
            Console.Write("Is the listing taken? (true/false): ");
            bool isTaken = bool.Parse(Console.ReadLine());

            Listing newListing = new Listing(id, trainerName, sessionDate, sessionTime, cost, isTaken);
            listings.Add(newListing);

            Console.WriteLine("Listing added successfully.");
            Console.ReadKey();
        }

        private static void EditListing(){
            Console.Write("Enter Listing ID to edit: ");
            int id = int.Parse(Console.ReadLine());
            Listing listing = listings.FirstOrDefault(l => l.ListingId == id);

            if (listing != null){
                Console.Write("Enter Trainer Name: ");
                listing.TrainerName = Console.ReadLine();
                Console.Write("Enter Date of the Session (yyyy-MM-dd): ");
                listing.SessionDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Time of the Session (HH:mm): ");
                listing.SessionTime = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Enter Cost of the Session: ");
                listing.Cost = decimal.Parse(Console.ReadLine());
                Console.Write("Is the listing taken? (true/false): ");
                listing.IsTaken = bool.Parse(Console.ReadLine());

                Console.WriteLine("Listing updated successfully.");
            }
            else{
                Console.WriteLine("Listing not found.");
            }

            Console.ReadKey();
        }

        private static void DeleteListing(){
            Console.Write("Enter Listing ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Listing listing = listings.FirstOrDefault(l => l.ListingId == id);

            if (listing != null){
                listings.Remove(listing);
                Console.WriteLine("Listing deleted successfully.");
            }
            else{
                Console.WriteLine("Listing not found.");
            }

            Console.ReadKey();
        }

        private static void ListListings(){
            Console.WriteLine("Listing ID\tTrainer Name\tSession Date\tSession Time\tCost\tIs Taken");
            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (Listing listing in listings){
                Console.WriteLine($"{listing.ListingId}\t{listing.TrainerName}\t{listing.SessionDate:yyyy-MM-dd}\t{listing.SessionTime:hh\\:mm}\t{listing.Cost}\t{listing.IsTaken}");
            }

            Console.WriteLine("\nPress any key to return to the Listing Data Management menu.");
            Console.ReadKey();
        }

    }
}
