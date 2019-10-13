using System;

namespace AppointmentConsoleApp
{
    public class AppointmentInfo
    {
        private static int lastAppointmentId = 0;
        #region Properties
        public int AppointmentID { get; set; }
        /// <summary>
        /// User who is requested the appointment
        /// </summary>
        public string HostUser { get; set; }
        /// <summary>
        /// User who is invited for an appointment
        /// </summary>
        public string GuestUser { get; set; }
        /// <summary>
        /// Date and Time of the appointment
        /// </summary>
        public DateTime DatenTime { get; set; }
        /// <summary>
        /// Subject of the requested appointment
        /// </summary>
        public string Subject { get; set; }
        public string Status { get; private set; }
        #endregion

        #region Constructor
        public AppointmentInfo()
        {
            AppointmentID = ++lastAppointmentId;
            Status = "Waiting";
        }
        #endregion
    }
}
