using FoodApp.Application.Services.Notification;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Application.Services
{
   public abstract class AbstractService
    {
        public bool VerifyEntityExistence<T>(object entity, INotificationService notificationService)
           where T : BaseEntity
        {
            if (entity is null)
            {
                notificationService.AddNotification($"{typeof(T).Name}NotFound",
                    $"{typeof(T).Name} Não encontrado");
                return true;
            }
            return false;
        }
    }
}
