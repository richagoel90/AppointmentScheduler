using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentConsoleApp
{
    static class Scheduler
    {
        private static AppointmentContext db = new AppointmentContext();
        
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
