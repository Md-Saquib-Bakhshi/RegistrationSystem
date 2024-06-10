using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationSystem
{
    internal class Registration
    {
        private string firstName;
        private string lastName;
        private string email;
        private string userName;
        private string password;

        public string  FirstName 
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public Registration(string firstName, string lastName, string email, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
        }

        public void AddUser()
        {
            DataStorage.AddUser(this);
        }

        public void GetUser()
        {
            foreach(var user in DataStorage.GetUsers())
            {
                Console.WriteLine($"\nFull Name: {user.Value.FirstName} {user.Value.LastName}\nEmail: {user.Value.Email}\nUsername: {user.Value.UserName}");
            }
        }
    }
}
