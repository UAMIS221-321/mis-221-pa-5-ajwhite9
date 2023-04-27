using System;
using System.Collections.Generic;

namespace PA5{
    public class Trainer{
        // Properties
        public int TrainerId { get; set; }
        public string Name { get; set; }
        public string MailingAddress { get; set; }
        public string Email { get; set; }
        public List<Listing> Listings { get; set; }

        // Constructor
        public Trainer(int trainerId, string name, string mailingAddress, string email){
            TrainerId = trainerId;
            Name = name;
            MailingAddress = mailingAddress;
            Email = email;
            Listings = new List<Listing>();
        }

        // Methods

        
        public void AddListing(Listing newListing){
            Listings.Add(newListing);
        }

        public void RemoveListing(Listing listingToRemove){
            Listings.Remove(listingToRemove);
        }
    }
}
