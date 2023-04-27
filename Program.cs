using System;

namespace PA5{
    class Program{
        static void Main(string[] args){
            int choice;
            do{
                Console.Clear();
                Console.WriteLine("Train Like A Champion - Personal Fitness");
                Console.WriteLine("1. Manage trainer data");
                Console.WriteLine("2. Manage listing data");
                Console.WriteLine("3. Manage customer booking data");
                Console.WriteLine("4. Run reports");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        TrainerDataManagement.ManageTrainers();
                        break;
                    case 2:
                        ListingDataManagement.ManageListings();
                        break;
                    case 3:
                        List<Trainer> trainerList = TrainerDataManagement.LoadTrainers(); 
                        BookingDataManagement.SetTrainerList(trainerList); 
                        BookingDataManagement.ManageBookings();
                        break;
                    case 4:
                        ReportManagement.ManageReports();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 5);
        }
    }
}
