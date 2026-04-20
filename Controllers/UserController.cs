using RestoranRezervasyonSistemi.Models;
using RestoranRezervasyonSistemi.Data;
using System;
using System.Collections.Generic;

namespace RestoranRezervasyonSistemi.Controllers
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository = null)
        {
            _userRepository = userRepository ?? new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _userRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcılar yüklenirken hata oluştu: {ex.Message}", ex);
            }
        }

        public bool BanUser(int userId, string userName)
        {
            if (userId <= 0)
                throw new ArgumentException("Geçersiz kullanıcı ID");

            try
            {
                return _userRepository.BanUser(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"{userName} kullanıcısı banlanırken hata oluştu: {ex.Message}", ex);
            }
        }

        public bool UnbanUser(int userId, string userName)
        {
            if (userId <= 0)
                throw new ArgumentException("Geçersiz kullanıcı ID");

            try
            {
                return _userRepository.UnbanUser(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"{userName} kullanıcısının banı kaldırılırken hata oluştu: {ex.Message}", ex);
            }
        }
    }
}
