using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Domain.Notifications
{
   public class NotificationEntity 
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public NotificationEntity(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
