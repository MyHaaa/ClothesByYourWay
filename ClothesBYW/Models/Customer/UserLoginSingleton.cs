using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesBYW.Models.Customer
{
    public sealed class UserLoginSingleton
    {
        static volatile UserLoginSingleton Instance;
        static ProfieModel account { get; set; } = null;
        private UserLoginSingleton() { }
        public static void Init(string id, string name, string username, DateTime? dob, string phone, string address, string email)
        {
            account = new ProfieModel()
            {
                ID = id,
                Name = name,
                Username = username,
                DOB = dob,
                Phone = phone,
                Address = address,
                Email = email
            };
        }
        public static UserLoginSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UserLoginSingleton();
            }
            return Instance;
        }
        public ProfieModel GetAccount() => account;
        public void Logout() => account = null;
    }
}