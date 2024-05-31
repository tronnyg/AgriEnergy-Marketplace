using AgriEnergy_WebApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AgriEnergy_WebApp.Utilities
{
    public static class UserHelper
    {
        public static ApplicationDbContext context = new ApplicationDbContext();
        private static User _currentUser;
        private static Farmer _farmer;
        private static Employee _employee;

        public static Farmer Farmer { get => _farmer; set => _farmer = value; }
        public static Employee Employee { get => _employee; set => _employee = value; }

        public static void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        public static User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}