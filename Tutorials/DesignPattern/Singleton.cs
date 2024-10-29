using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.DesignPattern
{
    internal class Singleton
    {
        public static void Examples()
        {
            Logger logger1 = Logger.GetInstance();
            logger1.Log("Message 1");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("Message 2");

            // Vérification que logger1 et logger2 sont la même instance
            Console.WriteLine(Object.ReferenceEquals(logger1, logger2)); // Affiche "True"
        }
    }
    public class Logger
    {
        // Lazy initialisation, crée l'instance au premier appel
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        private Logger() { }

        public static Logger GetInstance()
        {
            return _instance.Value; // Accès à l'instance unique
        }

        public void Log(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }

}
