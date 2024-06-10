using System;
using System.Collections.Generic;

namespace RegistrationSystem
{
    internal class Menu
    {
        private Registration currUser = null;
        public void MainMenu()
        {
            while (true)
            {
                try
                {
                    Console.Write("\nEnter\n 1 for Signup\n 2 for Login\n 3 for ViewUserList\n 4 for Logout\n 5 for Exit: ");
                    //int choice = int.Parse(Console.ReadLine());
                    if (!int.TryParse(Console.ReadLine(), out int choice)){
                        throw new FormatException("Invalid input format, please select integer value");
                    }
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter FirstName: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Enter LastName: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter UserName: ");
                            string userName = Console.ReadLine();
                            Console.Write("Enter Password: ");
                            string password = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password)){
                                throw new ArgumentException("All fields are required.");
                            }
                            EmailValidator.EmailValidate(email);
                            Registration signup = new Registration(firstName, lastName, email, userName, password);
                            signup.AddUser();
                            break;
                        case 2:
                            Console.Write("Enter UserName: ");
                            userName = Console.ReadLine();
                            Console.Write("Enter Password: ");
                            password = Console.ReadLine();
                            if( string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                            {
                                throw new ArgumentException("All fields are required.");
                            }
                            Registration user = DataStorage.ValidateUser(userName, password);
                            if (user != null)
                            {
                                currUser = user;
                                Console.WriteLine($"Login successfull {currUser.UserName}.");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect username and password.");
                            }
                            break;
                        case 3:
                            if (currUser == null)
                            {
                                Console.WriteLine("Please login to view list of users.");
                            }
                            else
                            {
                                var userList = DataStorage.GetUsers();
                                foreach (var users in userList)
                                {
                                    Console.WriteLine($"\nFullName: {users.Value.FirstName} {users.Value.LastName}\nEmail: {users.Value.Email}\nUsername: {users.Value.UserName}");
                                }
                            }
                            break;
                        case 4:
                            if (currUser != null)
                            {
                                Console.WriteLine($"{currUser.UserName} logout successful.");
                                currUser = null;
                            }
                            else
                            {
                                Console.WriteLine("Already not login.");
                            }
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("!!!Invalid Choice!!!");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Format Error: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Argument Error: {ex.Message}");
                }
                catch (Exception ex)
                { 
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }
            }
        }

    }
}
