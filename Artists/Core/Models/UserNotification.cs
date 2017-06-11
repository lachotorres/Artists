using System;

namespace Artists.Core.Models
{
    public class UserNotification
    {
      
        public string UserId { get; private set; }
              
        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }

        public Notification Notification { get; private set; }

        public bool IsRead { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// this is for EF, EF needs a default constructor
        /// </remarks>
        protected UserNotification()
        {
               
        }

        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (user == null)
                throw new ArgumentNullException("notification");

            Notification = notification;
            User = user;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}