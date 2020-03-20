using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodApp.Domain.Notifications
{
   public class NotificationContext
    {
        private readonly List<NotificationEntity> _notifications;
        public IReadOnlyCollection<NotificationEntity> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<NotificationEntity>();
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new NotificationEntity(key, message));
        }

        public void AddNotification(NotificationEntity notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<NotificationEntity> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<NotificationEntity> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<NotificationEntity> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
