using System;

namespace PA5{
    public class Booking{
        // Properties
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime TrainingDate { get; set; }
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public BookingStatus Status { get; set; }
        public decimal SessionCost { get; set; }
        public int SessionId { get; set; }

        // Constructor
        public Booking(int bookingId, string customerName, string customerEmail, DateTime trainingDate, int trainerId, string trainerName, BookingStatus status, decimal sessionCost, int SessionId){
            BookingId = bookingId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            TrainingDate = trainingDate;
            TrainerId = trainerId;
            TrainerName = trainerName;
            Status = status;
            SessionCost = sessionCost;
        }
    }

    public enum BookingStatus{
        Booked,
        Cancelled,
        Completed

    }
}
