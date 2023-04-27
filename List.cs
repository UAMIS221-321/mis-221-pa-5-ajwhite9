using System;

namespace PA5{
    public class Listing{
        // Properties
        public int ListingId { get; set; }
        public string TrainerName { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan SessionTime { get; set; }
        public decimal Cost { get; set; }
        public bool IsTaken { get; set; }

        // Constructor
        public Listing(int listingId, string trainerName, DateTime sessionDate, TimeSpan sessionTime, decimal cost, bool isTaken){
            ListingId = listingId;
            TrainerName = trainerName;
            SessionDate = sessionDate;
            SessionTime = sessionTime;
            Cost = cost;
            IsTaken = isTaken;
        }
    }
}
