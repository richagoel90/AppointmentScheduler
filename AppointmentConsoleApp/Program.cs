using System;
using System.Collections.Generic;

namespace AppointmentConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfo LoggedInUser =null;
            UserInfo GuestUser =null;

            while (true)
            {
                Console.WriteLine("Select the option");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: User Login");
                Console.WriteLine("2: Book Appointment");
                Console.WriteLine("3: Print All Appointments");

                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 0: Console.WriteLine("Thank you for visiting us!!!");
                        return;
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Enter the User Name:");
                            string UserName = Console.ReadLine();
                            Console.WriteLine("Enter the Password:");
                            string Password = Console.ReadLine();
                            LoggedInUser = Scheduler.getUserDetails(UserName, Password);
                            if (LoggedInUser != null)
                            {
                                Console.WriteLine("User is loggedin successfully");
                                break;
                            }
                            Console.WriteLine("UserName or password is incorrect!! Please login again");
                        }
                        break;
                    case 2:
                        if(LoggedInUser==null)
                        {
                            Console.WriteLine("Please login ");
                            break;
                        }
                        while(true)
                        {
                            Console.WriteLine("Here is the Guest User List:");
                            var GuerstUsers = Scheduler.getGuestUserList(LoggedInUser.UserId);
                            foreach (var guest in GuerstUsers)
                            {
                                Console.WriteLine($"UserId:{guest.UserId} Name:{guest.FirstName},{guest.LastName}");
                            }
                            Console.Write("Select the Guest User ID:");
                            var GuestUserId = int.Parse(Console.ReadLine());
                            GuestUser = Scheduler.getUserInfo(GuestUserId);
                            if (GuestUser == null)
                            {
                                Console.WriteLine("Select valid user");
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.Write("Enter the Date and Time of Appointment:");
                        var DatenTime = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter the Subject of Appointment:");
                        var Subject = Console.ReadLine();
                        Scheduler.Book_Appointment(LoggedInUser.UserId,LoggedInUser.FirstName,GuestUser.FirstName, DatenTime, Subject);
                        break;
                    case 3:
                        if (LoggedInUser == null)
                        {
                            Console.WriteLine("Please login ");
                            break;
                        }
                        var appointments = Scheduler.getAllAppointments(LoggedInUser.UserId);
                        foreach(var myAppointment in appointments)
                        {
                            Console.WriteLine($"Appointment ID:{myAppointment.AppointmentID}, " +
                                $" HostUser:{myAppointment.HostUser}, " +
                                $" GuestUser:{myAppointment.GuestUser}, " +
                                $" Subject:{myAppointment.Subject}, " +
                                $" Status:{myAppointment.Status}," +
                                $"Date:{myAppointment.DatenTime} ");
                        }
                        break;
                }
            }
        }
    }
}
