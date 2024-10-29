using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.SOLID
{
    internal class DependencyInversionPrinciple
    {
        public static void Example()
        {
            // Envoi d'une notification par e-mail
            INotificationService emailService = new EmailService();
            NotificationSender emailSender = new NotificationSender(emailService);
            emailSender.SendNotification("Bonjour via Email!");

            // Envoi d'une notification par SMS
            INotificationService smsService = new SMSService();
            NotificationSender smsSender = new NotificationSender(smsService);
            smsSender.SendNotification("Bonjour via SMS!");
        }
    }
    // Interface abstraite pour les services de notification
    public interface INotificationService
    {
        void Send(string message);
    }

    // Implémentation du service de notification par e-mail
    public class EmailService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("Envoi de l'email : " + message);
        }
    }

    // Implémentation du service de notification par SMS
    public class SMSService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("Envoi du SMS : " + message);
        }
    }

    // Classe principale NotificationSender, qui dépend de l'interface abstraite INotificationService
    public class NotificationSender
    {
        private readonly INotificationService _notificationService;

        // Injection de dépendance par le constructeur
        public NotificationSender(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void SendNotification(string message)
        {
            _notificationService.Send(message);
        }
    }


    //public class EmailService
    //{
    //    public void SendEmail(string message)
    //    {
    //        Console.WriteLine("Envoi de l'email : " + message);
    //    }
    //}

    //public class SMSService
    //{
    //    public void SendSMS(string message)
    //    {
    //        Console.WriteLine("Envoi du SMS : " + message);
    //    }
    //}

    //public class NotificationSender
    //{
    //    private readonly EmailService _emailService;
    //    private readonly SMSService _smsService;

    //    public NotificationSender()
    //    {
    //        _emailService = new EmailService();
    //        _smsService = new SMSService();
    //    }

    //    public void SendEmailNotification(string message)
    //    {
    //        _emailService.SendEmail(message);
    //    }

    //    public void SendSMSNotification(string message)
    //    {
    //        _smsService.SendSMS(message);
    //    }
    //}


}
