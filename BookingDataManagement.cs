using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PA5
{
    public static class BookingDataManagement
    {
        private static List<Booking> bookings = new List<Booking>();
        private static string bookingsFilePath = "transactions.txt";
        private static List<Trainer> trainers;

        public static void ManageBookings(){
            LoadBookingsFromFile();
            int choice;
            do{
                Console.Clear();
                Console.WriteLine("Booking Data Management");
                Console.WriteLine("1. View Available Sessions");
                Console.WriteLine("2. Book a Session");
                Console.WriteLine("3. Update Session Status");
                Console.WriteLine("4. Return to Main Menu");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        ViewAvailableSessions();
                        break;
                    case 2:
                        BookSession();
                        break;
                    case 3:
                        UpdateSessionStatus();
                        break;
                    case 4:
                        Console.WriteLine("Returning to the main menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }
            } while (choice != 4);

            SaveBookingsToFile();
        }

            private static void LoadBookingsFromFile(){
                if (File.Exists(bookingsFilePath)){
                    using (StreamReader reader = new StreamReader(bookingsFilePath)){
                        string line;
                        while ((line = reader.ReadLine()) != null){
                            string[] data = line.Split('#');
                            int sessionId = int.Parse(data[0]);
                            string customerName = data[1];
                            string customerEmail = data[2];
                            DateTime trainingDate = DateTime.Parse(data[3]);
                            int trainerId = int.Parse(data[4]);
                            string trainerName = data[5];
                            BookingStatus status = (BookingStatus)Enum.Parse(typeof(BookingStatus), data[6]);
                            decimal sessionCost = decimal.Parse(data[7]);
                            int bookingId = int.Parse(data[8]);
                            Booking booking = new Booking(sessionId, customerName, customerEmail, trainingDate, trainerId, trainerName, status, sessionCost, bookingId);
                            bookings.Add(booking);
                        }
                    }
                }
            }

        private static void SaveBookingsToFile(){
            using (StreamWriter writer = new StreamWriter(bookingsFilePath)){
                foreach (Booking booking in bookings){
                    string line = $"{booking.SessionId}#{booking.CustomerName}#{booking.CustomerEmail}#{booking.TrainingDate}#{booking.TrainerId}#{booking.TrainerName}#{booking.Status}";
                    writer.WriteLine(line);
                }
            }
        }

        private static void ViewAvailableSessions(){
            Console.WriteLine("Session ID\tCustomer Name\tCustomer Email\tTraining Date\tTrainer ID\tTrainer Name\tStatus");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

            foreach (Booking booking in bookings.Where(b => b.Status == BookingStatus.Booked)){
                Console.WriteLine($"{booking.SessionId}\t{booking.CustomerName}\t{booking.CustomerEmail}\t{booking.TrainingDate:yyyy-MM-dd}\t{booking.TrainerId}\t{booking.TrainerName}\t{booking.Status}");
            }

            Console.WriteLine("\nPress any key to return to the Booking Data Management menu.");
            Console.ReadKey();
        }

        private static void BookSession(){
            Console.Write("Enter Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine());
            Console.Write("Enter Session ID: ");
            int sessionId = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Customer Email: ");
            string customerEmail = Console.ReadLine();
            Console.Write("Enter Training Date (yyyy-MM-dd): ");
            DateTime trainingDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Trainer ID: ");
            int trainerId = int.Parse(Console.ReadLine());
            Console.Write("Enter Trainer Name: ");
            string trainerName = Console.ReadLine();
            Console.Write("Enter Session Cost: ");
            decimal sessionCost = decimal.Parse(Console.ReadLine());

            Booking newBooking = new Booking(sessionId, customerName, customerEmail, trainingDate, trainerId, trainerName, BookingStatus.Booked, sessionCost, bookingId);
            bookings.Add(newBooking);

            Console.WriteLine("Session booked successfully.");
            Console.ReadKey();
        }


        private static void UpdateSessionStatus(){
            Console.Write("Enter Session ID to update: ");
            int sessionId = int.Parse(Console.ReadLine());
            Booking booking = bookings.FirstOrDefault(b => b.SessionId == sessionId);

            if (booking != null){
                Console.WriteLine($"Current status: {booking.Status}");
                Console.Write("Enter new status (Booked, Completed, or Cancelled): ");
                BookingStatus newStatus = (BookingStatus)Enum.Parse(typeof(BookingStatus), Console.ReadLine(), true);
                booking.Status = newStatus;

                Console.WriteLine("Session status updated successfully.");
            }
            else{
                Console.WriteLine("Session not found.");
            }

            Console.ReadKey();
        }
        public static void SetTrainerList(List<Trainer> trainerList){
            trainers = trainerList;
        }
        public static List<Booking> GetBookings(){
            return bookings;
        }



    }
}
