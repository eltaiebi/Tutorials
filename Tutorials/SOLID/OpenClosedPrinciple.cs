using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.SOLID
{
    internal class OpenClosedPrinciple
    {
        public static void Examples()
        {
            Notification notification = new Notification
            {
                Message = "Votre commande a été expédiée",
                Recipient = "user@example.com"
            };

            INotificationSender emailSender = new EmailNotificationSender();
            INotificationSender smsSender = new SmsNotificationSender();
            INotificationSender pushSender = new PushNotificationSender();

            NotificationService emailService = new NotificationService(emailSender);
            emailService.SendNotification(notification);

            NotificationService smsService = new NotificationService(smsSender);
            smsService.SendNotification(notification);
            
            NotificationService pushService = new NotificationService(pushSender);
            pushService.SendNotification(notification);
        }
    }
    public class Notification
    {
        public string Message { get; set; }
        public string Recipient { get; set; }
    }
    // Interface qui définit le contrat de notification
    public interface INotificationSender
    {
        void Send(Notification notification);
    }

    // Classe de notification par e-mail
    public class EmailNotificationSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"Envoi d'un e-mail à {notification.Recipient}: {notification.Message}");
        }
    }

    // Classe de notification par SMS
    public class SmsNotificationSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"Envoi d'un SMS à {notification.Recipient}: {notification.Message}");
        }
    }

    // Classe de notification Push
    public class PushNotificationSender : INotificationSender
    {
        public void Send(Notification notification)
        {
            Console.WriteLine($"Envoi d'une notification Push à {notification.Recipient}: {notification.Message}");
        }
    }

    // Service de notification qui dépend de l'interface INotificationSender
    public class NotificationService
    {
        private readonly INotificationSender _notificationSender;

        // Injection de dépendance pour permettre l'utilisation de n'importe quel type de notification
        public NotificationService(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public void SendNotification(Notification notification)
        {
            _notificationSender.Send(notification);
        }
    }

}
