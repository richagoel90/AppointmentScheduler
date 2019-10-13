using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentConsoleApp
{
    static class Scheduler
    {
        private static Dictionary<int,UserInfo> UserList;
        private static List<AppointmentInfo> AppointmentsList = new List<AppointmentInfo>();

        public static void UserList_Initializer()
        {
            UserList = new Dictionary<int,UserInfo>();
            UserList.Add(1,new UserInfo() {FirstName = "Richa", LastName = "Goel", EmailID = "richa.goyal90@gmail.com", PhoneNumber = 4254432538, UserName = "RichaGoel", Password = "richa" });
            UserList.Add(2,new UserInfo() {FirstName = "Arpit", LastName = "Gupta", EmailID = "arpit.gupta@gmail.com", PhoneNumber = 4254432222, UserName = "ArpitGupta", Password = "arpit" });
            UserList.Add(3,new UserInfo() {FirstName = "Deepak", LastName = "Goel", EmailID = "deepak.goel@gmail.com", PhoneNumber = 4254432333, UserName = "DeepakGoel", Password = "deepak" });
            UserList.Add(4,new UserInfo() {FirstName = "Saurabh", LastName = "Goel", EmailID = "saurabh.goel@gmail.com", PhoneNumber = 4254434444, UserName = "SaurabhGoel", Password = "saurabh" });
            UserList.Add(5,new UserInfo() {FirstName = "Bhawna", LastName = "Goel", EmailID = "bhawna.goel@gmail.com", PhoneNumber = 4254435555, UserName = "BhawnaGoel", Password = "bhawna" });
            UserList.Add(6,new UserInfo() {FirstName = "Jyoti", LastName = "Goel", EmailID = "jyoti.goel@gmail.com", PhoneNumber = 4254435556, UserName = "JyotiGoel", Password = "jyoti" });
        }
        public static IEnumerable<UserInfo> getGuestUserList( int UserId)
        {
            return UserList.Values.Where(a => a.UserId != UserId);
        }
        public static UserInfo getUserDetails(string UserName,string Password)
        {
            return UserList.Values.SingleOrDefault(a => a.UserName == UserName && a.Password == Password);
        }
        public static UserInfo getUserInfo(int UserId)
        {
            if(UserList.ContainsKey(UserId))
            {
                return UserList[UserId];
            }
            return null;
        }
        public static void Book_Appointment(string HostUser,string GuestUser,DateTime datetime,string Subject)
        {

            AppointmentInfo appointment = new AppointmentInfo()
            {
                HostUser = HostUser,
                GuestUser=GuestUser,
                DatenTime=datetime,
                Subject=Subject
            };
            AppointmentsList.Add(appointment);
        }
        public static IEnumerable<AppointmentInfo> getAllAppointments(int UserId)
        {
            var user = getUserInfo(UserId);
            return AppointmentsList.Where(a=>a.HostUser==user.FirstName || a.GuestUser==user.FirstName);
        }
    }
}
