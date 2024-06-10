using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationSystem
{
    internal class DataStorage
    {
        private static Dictionary<string, Registration> Users = new Dictionary<string, Registration>();

        public static void AddUser(Registration user)
        {
            if (!Users.ContainsKey(user.UserName))
            {
                Users.Add(user.UserName, user);
                Console.WriteLine("User added successfully.");
            }
            else
            {
                Console.WriteLine("User already exists.");
            }
        }

        public static Dictionary<string, Registration> GetUsers()
        {
            return Users;
        }

        public static Registration ValidateUser(string userName, string password)
        {
            if (Users.ContainsKey(userName) && Users[userName].Password == password)
            {
                return Users[userName];
            }
            return null;
        }
    }
}
