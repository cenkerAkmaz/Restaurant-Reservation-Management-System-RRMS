using RestoranRezervasyonSistemi.Data;
using RestoranRezervasyonSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoranRezervasyonSistemi.Controllers
{
    public sealed class MenuController
    {
        private readonly MenuRepository _menuRepository = new MenuRepository();

        public List<MenuItem> GetAllMenuItems() => _menuRepository.GetAllMenuItems();

        public List<MenuItem> GetAllMenuItemsIncludingUnavailable() => _menuRepository.GetAllMenuItemsIncludingUnavailable();

        public List<MenuItem> GetMenuItemsByCategory(string category) => _menuRepository.GetMenuItemsByCategory(category);

        public MenuItem GetMenuItemById(int id) => _menuRepository.GetMenuItemById(id);

        public List<string> GetCategories() => _menuRepository.GetCategories();

        public void AddMenuItem(MenuItem item) => _menuRepository.AddMenuItem(item);

        public void UpdateMenuItem(MenuItem item) => _menuRepository.UpdateMenuItem(item);

        public bool DeleteMenuItem(int id) => _menuRepository.DeleteMenuItem(id);

        public void AddReservationMenuItem(ReservationMenuItem rmi) => _menuRepository.AddReservationMenuItem(rmi);

        public List<ReservationMenuItem> GetReservationMenuItems(int reservationId) => _menuRepository.GetReservationMenuItems(reservationId);

        public decimal GetReservationTotalPrice(int reservationId) => _menuRepository.GetReservationTotalPrice(reservationId);

        public bool DeleteReservationMenuItems(int reservationId) => _menuRepository.DeleteReservationMenuItems(reservationId);

        public void AddReservationMenuItems(int reservationId, List<(int MenuItemId, int Quantity)> selectedItems)
        {
            foreach (var (menuItemId, quantity) in selectedItems)
            {
                var menuItem = GetMenuItemById(menuItemId);
                if (menuItem != null)
                {
                    var rmi = new ReservationMenuItem
                    {
                        ReservationId = reservationId,
                        MenuItemId = menuItemId,
                        Quantity = quantity,
                        UnitPrice = menuItem.Price,
                        TotalPrice = menuItem.Price * quantity
                    };
                    AddReservationMenuItem(rmi);
                }
            }
        }

        public Dictionary<string, List<MenuItem>> GetMenuItemsByCategories()
        {
            var result = new Dictionary<string, List<MenuItem>>();
            var categories = GetCategories();
            
            foreach (var category in categories)
            {
                result[category] = GetMenuItemsByCategory(category);
            }
            
            return result;
        }
    }
}
