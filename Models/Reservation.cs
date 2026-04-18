using System;

namespace RestoranRezervasyonSistemi.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int GuestCount { get; set; }
    }
}

