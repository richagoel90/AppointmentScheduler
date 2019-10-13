namespace AppointmentConsoleApp
{
    public class UserInfo
    {
        private static int lastUserId=0;
        #region Properties
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public long PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        #endregion
        #region Constructor
        public UserInfo()
        {
            UserId = ++lastUserId;
        }
        #endregion
    }
}
