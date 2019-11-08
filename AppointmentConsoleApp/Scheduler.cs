using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentConsoleApp
{
    static class Scheduler
    {
        private static AppointmentContext db = new AppointmentContext();
        
        //public static void UserList_Initializer()
        //{
        //    db.Users.Add(new UserInfo() {FirstName = "Richa", LastName = "Goel", EmailID = "richa.goyal90@gmail.com", PhoneNumber = 4254432538, UserName = "RichaGoel", Password = "richa" });
        //    db.Users.Add(new UserInfo() {FirstName = "Arpit", LastName = "Gupta", EmailID = "arpit.gupta@gmail.com", PhoneNumber = 4254432222, UserName = "ArpitGupta", Password = "arpit" });
        //    db.Users.Add(new UserInfo() {FirstName = "Deepak", LastName = "Goel", EmailID = "deepak.goel@gmail.com", PhoneNumber = 4254432333, UserName = "DeepakGoel", Password = "deepak" });
        //    db.Users.Add(new UserInfo() {FirstName = "Saurabh", LastName = "Goel", EmailID = "saurabh.goel@gmail.com", PhoneNumber = 4254434444, UserName = "SaurabhGoel", Password = "saurabh" });
        //    db.Users.Add(new UserInfo() {FirstName = "Bhawna", LastName = "Goel", EmailID = "bhawna.goel@gmail.com", PhoneNumber = 4254435555, UserName = "BhawnaGoel", Password = "bhawna" });
        //    db.Users.Add(new UserInfo() {FirstName = "Jyoti", LastName = "Goel", EmailID = "jyoti.goel@gmail.com", PhoneNumber = 4254435556, UserName = "JyotiGoel", Password = "jyoti" });
        //    db.SaveChanges();
        //}
        public static IEnumerable<UserInfo> getGuestUserList( int UserId)
        {
            return db.Users.Where(a => a.UserId != UserId);
        }
        public static UserInfo getUserDetails(string UserName,string Password)
        {
            return db.Users.SingleOrDefault(a => a.UserName == UserName && a.Password == Password);
        }
        public static UserInfo getUserInfo(int UserId)
        {
            return db.Users.SingleOrDefault(a => a.UserId == UserId);
        }
        public static void Book_Appointment(int HostUserID,string HostUser,string GuestUser,DateTime datetime,string Subject)
        {

            AppointmentInfo appointment = new AppointmentInfo()
            {
                HostUserID=HostUserID,
                HostUser = HostUser,
                GuestUser=GuestUser,
                DatenTime=datetime,
                Subject=Subject
            };
            db.Appointments.Add(appointment);
            db.SaveChanges();
        }
        public static IEnumerable<AppointmentInfo> getAllAppointments(int UserId)
        {
            var user = getUserInfo(UserId);
            return db.Appointments.Where(a=>a.HostUser==user.FirstName || a.GuestUser==user.FirstName);
        }
    }
}
