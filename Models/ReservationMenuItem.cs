using System;

namespace RestoranRezervasyonSistemi.Models
{
    public class ReservationMenuItem
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
