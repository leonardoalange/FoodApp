using FoodApp.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Application.Services.Notification
{
   public interface INotificationService
    {
        void AddNotification(string key, string message);

        void AddEntityNotification(FluentValidation.Results.ValidationResult validationResult);

        bool HasNotifications();

        IReadOnlyCollection<NotificationEntity> GetNotifications();
    }
}
