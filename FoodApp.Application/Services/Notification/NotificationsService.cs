using FluentValidation.Results;
using FoodApp.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Application.Services.Notification
{
    public class NotificationService : INotificationService
    {

        private readonly NotificationContext _notificationContext;
        public NotificationService(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void AddEntityNotification(ValidationResult validationResult)
        {
            _notificationContext.AddNotifications(validationResult);
        }

        public void AddNotification(string key, string message)
        {
            _notificationContext.AddNotification(key, message);
        }

        public IReadOnlyCollection<NotificationEntity> GetNotifications()
        {
            return _notificationContext.Notifications;
        }

        public bool HasNotifications()
        {
            return _notificationContext.HasNotifications;
        }
    }
}
