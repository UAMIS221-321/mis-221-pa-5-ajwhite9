using System;
using System.Collections.Generic;
using System.Linq;

namespace PA5{
    public static class ReportManagement{
public static void ManageReports(){
    List<Booking> bookings = BookingDataManagement.GetBookings();
    int choice;
    do{
        Console.Clear();
        Console.WriteLine("Report Management");
        Console.WriteLine("1. Individual Customer Sessions");
        Console.WriteLine("2. Historical Customer Sessions");
        Console.WriteLine("3. Historical Revenue Report");
        Console.WriteLine("4. Booking Status Report");
        Console.WriteLine("5. Return to Main Menu");
        Console.Write("Enter your choice: ");
        choice = int.Parse(Console.ReadLine());

        switch (choice){
            case 1:
                IndividualCustomerSessions(bookings);
                break;
            case 2:
                HistoricalCustomerSessions(bookings);
                break;
            case 3:
                HistoricalRevenueReport(bookings);
                break;
            case 4:
                GenerateBookingStatusReport(bookings);
                break;
            case 5:
                Console.WriteLine("Returning to the main menu...");
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a valid option.");
                break;
        }
    } while (choice != 5);
}

        private static void IndividualCustomerSessions(List<Booking> bookings){
            Console.Write("Enter Customer Email: ");
            string customerEmail = Console.ReadLine();

            var sessions = bookings.Where(b => b.CustomerEmail == customerEmail).OrderBy(b => b.TrainingDate);

            Console.WriteLine("Session ID\tTraining Date\tTrainer ID\tTrainer Name\tStatus");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var session in sessions){
                Console.WriteLine($"{session.SessionId}\t{session.TrainingDate:yyyy-MM-dd}\t{session.TrainerId}\t{session.TrainerName}\t{session.Status}");
            }

            Console.WriteLine("\nPress any key to return to the Report Management menu.");
            Console.ReadKey();
        }

        private static void HistoricalCustomerSessions(List<Booking> bookings){
            var sessions = bookings.OrderBy(b => b.CustomerEmail).ThenBy(b => b.TrainingDate);

            Console.WriteLine("Customer Email\t\tSession ID\tTraining Date\tTrainer ID\tTrainer Name\tStatus");
            Console.WriteLine("------------------------------------------------------------------------------------------------");

            foreach (var session in sessions)
            {
                Console.WriteLine($"{session.CustomerEmail}\t\t{session.SessionId}\t{session.TrainingDate:yyyy-MM-dd}\t{session.TrainerId}\t{session.TrainerName}\t{session.Status}");
            }

            Console.WriteLine("\nPress any key to return to the Report Management menu.");
            Console.ReadKey();
        }

        private static void HistoricalRevenueReport(List<Booking> bookings){
            var revenueByMonth = bookings
                .Where(b => b.Status == BookingStatus.Completed)
                .GroupBy(b => new { b.TrainingDate.Year, b.TrainingDate.Month })
                .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Revenue = g.Sum(b => b.SessionCost) })
                .OrderBy(g => g.Year).ThenBy(g => g.Month);

            Console.WriteLine("Year\tMonth\tRevenue");
            Console.WriteLine("-----------------------");

            foreach (var item in revenueByMonth){
                Console.WriteLine($"{item.Year}\t{item.Month}\t{item.Revenue}");
            }

            Console.WriteLine("\nPress any key to return to the Report Management menu.");
            Console.ReadKey();
        }

                private static void GenerateBookingStatusReport(List<Booking> bookings){
            Console.WriteLine("Booking Status Report");
            Console.WriteLine("=====================");

            var groupedBookings = bookings.GroupBy(b => b.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);

            foreach (var group in groupedBookings){
                Console.WriteLine($"{group.Status}: {group.Count}");
            }

            Console.WriteLine("=====================");
            Console.WriteLine("\nPress any key to return to the Report Management menu.");
            Console.ReadKey();
            }

    }
}
