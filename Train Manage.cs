using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PA5{
    public static class TrainerDataManagement{
        private static List<Trainer> trainers = new List<Trainer>();
        private static string trainersFilePath = "trainers.txt";

        public static void ManageTrainers(){
            LoadTrainersFromFile();

            int choice;
            do{
                Console.Clear();
                Console.WriteLine("Trainer Data Management");
                Console.WriteLine("1. Add Trainer");
                Console.WriteLine("2. Edit Trainer");
                Console.WriteLine("3. Delete Trainer");
                Console.WriteLine("4. List Trainers");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice){
                    case 1:
                        AddTrainer();
                        break;
                    case 2:
                        EditTrainer();
                        break;
                    case 3:
                        DeleteTrainer();
                        break;
                    case 4:
                        ListTrainers();
                        break;
                    case 5:
                        Console.WriteLine("Returning to the main menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }
            } while (choice != 5);

            SaveTrainersToFile();
        }

        private static void LoadTrainersFromFile(){
            if (File.Exists(trainersFilePath)){
                using (StreamReader reader = new StreamReader(trainersFilePath)){
                    string line;
                    while ((line = reader.ReadLine()) != null){
                        string[] data = line.Split('#');
                        int id = int.Parse(data[0]);
                        string name = data[1];
                        string mailingAddress = data[2];
                        string email = data[3];
                        Trainer trainer = new Trainer(id, name, mailingAddress, email);
                        trainers.Add(trainer);
                    }
                }
            }
        }

        private static void SaveTrainersToFile(){
            using (StreamWriter writer = new StreamWriter(trainersFilePath)){
                foreach (Trainer trainer in trainers){
                    string line = $"{trainer.TrainerId}#{trainer.Name}#{trainer.MailingAddress}#{trainer.Email}";
                    writer.WriteLine(line);
                }
            }
        }

    private static void AddTrainer(){
        Console.Write("Enter Trainer ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Trainer Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Mailing Address: ");
        string mailingAddress = Console.ReadLine();
        Console.Write("Enter Trainer Email: ");
        string email = Console.ReadLine();

        Trainer newTrainer = new Trainer(id, name, mailingAddress, email);
        trainers.Add(newTrainer);

        Console.WriteLine("Trainer added successfully.");
        Console.ReadKey();
    }

    private static void EditTrainer(){
        Console.Write("Enter Trainer ID to edit: ");
        int id = int.Parse(Console.ReadLine());
        Trainer trainer = trainers.FirstOrDefault(t => t.TrainerId == id);

        if (trainer != null){
            Console.Write("Enter Trainer Name: ");
            trainer.Name = Console.ReadLine();
            Console.Write("Enter Mailing Address: ");
            trainer.MailingAddress = Console.ReadLine();
            Console.Write("Enter Trainer Email: ");
            trainer.Email = Console.ReadLine();

            Console.WriteLine("Trainer updated successfully.");
        }
        else{
            Console.WriteLine("Trainer not found.");
        }

        Console.ReadKey();
        }

    private static void DeleteTrainer(){
        Console.Write("Enter Trainer ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        Trainer trainer = trainers.FirstOrDefault(t => t.TrainerId == id);

        if (trainer != null){
            trainers.Remove(trainer);
            Console.WriteLine("Trainer deleted successfully.");
        }
        else{
            Console.WriteLine("Trainer not found.");
        }

            Console.ReadKey();
        }

        private static void ListTrainers(){
            Console.WriteLine("Trainer ID\tName\tMailing Address\tEmail");
            Console.WriteLine("----------------------------------------------------");

            foreach (Trainer trainer in trainers){
                Console.WriteLine($"{trainer.TrainerId}\t{trainer.Name}\t{trainer.MailingAddress}\t{trainer.Email}");
            }

            Console.WriteLine("\nPress any key to return to the Trainer Data Management menu.");
            Console.ReadKey();
        }
        public static List<Trainer> GetTrainers(){
                return trainers;
            }
        public static List<Trainer> LoadTrainers(){
            string trainersFilePath = "trainers.txt";
            trainers = new List<Trainer>();

            if (File.Exists(trainersFilePath)){
                using (StreamReader reader = new StreamReader(trainersFilePath)){
                    string line;
                    while ((line = reader.ReadLine()) != null){
                        string[] data = line.Split('#');
                        int trainerId = int.Parse(data[0]);
                        string trainerName = data[1];
                        string mailingAddress = data[2];
                        string email = data[3];
                        
                        Trainer trainer = new Trainer(trainerId, trainerName, mailingAddress, email);
                        trainers.Add(trainer);
                    }
                }
            }
            return trainers;
        }
    }
}
