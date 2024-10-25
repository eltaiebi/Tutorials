using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    public static class Polymorphisme
    {
        public static void Examples()
        {
            Console.WriteLine("=== Polymorphisme Statique : Surcharge de Méthodes ===");
            MethodOverloadingExample();

            Console.WriteLine("\n=== Polymorphisme Statique : Surcharge d'Opérateurs ===");
            OperatorOverloadingExample();

            Console.WriteLine("\n=== Polymorphisme Dynamique : Remplacement de Méthodes ===");
            MethodOverridingExample();

            Console.WriteLine("\n=== Polymorphisme Dynamique : Interface ===");
            InterfacePolymorphismExample();
        }

        private static void MethodOverloadingExample()
        {
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Add(5, 10));       // Utilise la méthode qui prend deux entiers
            Console.WriteLine(calc.Add(5.5, 10.3));   // Utilise la méthode qui prend deux doubles
            Console.WriteLine(calc.Add(1, 2, 3));     // Utilise la méthode qui prend trois entiers
        }

        private static void OperatorOverloadingExample()
        {
            Product product1 = new Product("Chaise", 5, 49.99m);
            Product product2 = new Product("Chaise", 10, 49.99m);

            Product combinedProduct = product1 + product2;
            Console.WriteLine(combinedProduct); // Affiche : Chaise: 15 unités, Prix: 49,99 €
        }

        private static void MethodOverridingExample()
        {
            Animal myDog = new Dog();
            Animal myCat = new Cat();

            myDog.MakeSound();  // Affiche : Le chien aboie
            myCat.MakeSound();  // Affiche : Le chat miaule
        }

        private static void InterfacePolymorphismExample()
        {
            IVehicle car = new Car();
            IVehicle motorbike = new Motorbike();
            Garage garage = new Garage();

            garage.StartVehicle(car);        // Affiche : La voiture démarre
            garage.StartVehicle(motorbike);  // Affiche : La moto démarre
        }
    }

    #region Polymorphisme à la compilation (statique)    
    /*** Surcharge de méthodes(Method Overloading) ***/
    public class Calculator
    {
        // Surcharge de méthode : plusieurs méthodes "Add" avec différents types de paramètres.

        public int Add(int a, int b)
        {
            return a + b; // Addition de deux entiers
        }

        public double Add(double a, double b)
        {
            return a + b; // Addition de deux nombres à virgule flottante
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c; // Addition de trois entiers
        }
    }

    /*** Surcharge des opérateurs (Operator Overloading) ***/
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        // Surcharge de l'opérateur +
        public static Product operator +(Product p1, Product p2)
        {
            // On combine les quantités mais on garde le prix du premier produit
            return new Product(p1.Name, p1.Quantity + p2.Quantity, p1.Price);
        }

        public override string ToString()
        {
            return $"{Name}: {Quantity} unités, Prix: {Price:C}";
        }
    }
    #endregion

    #region Polymorphisme à l'exécution (dynamique)  
    /*** Remplacement de méthode (Method Overriding) via l'héritage ***/
    public class Animal
    {
        // Méthode virtuelle qui peut être redéfinie dans les classes dérivées
        public virtual void MakeSound()
        {
            Console.WriteLine("L'animal fait un bruit.");
        }
    }
    public class Dog : Animal
    {
        // Remplacement de la méthode MakeSound pour le chien
        public override void MakeSound()
        {
            Console.WriteLine("Le chien aboie.");
        }
    }
    public class Cat : Animal
    {
        // Remplacement de la méthode MakeSound pour le chat
        public override void MakeSound()
        {
            Console.WriteLine("Le chat miaule.");
        }
    }

    /*** Polymorphisme via les interfaces ***/
    public interface IVehicle
    {
        void StartEngine(); // Méthode à implémenter
    }
    public class Car : IVehicle
    {
        // Implémentation de l'interface dans la classe Car
        public void StartEngine()
        {
            Console.WriteLine("La voiture démarre.");
        }
    }
    public class Motorbike : IVehicle
    {
        // Implémentation de l'interface dans la classe Motorbike
        public void StartEngine()
        {
            Console.WriteLine("La moto démarre.");
        }
    }
    public class Garage
    {
        // Méthode qui accepte n'importe quel objet implémentant IVehicle
        public void StartVehicle(IVehicle vehicle)
        {
            vehicle.StartEngine(); // Appel de la méthode polymorphe
        }
    }
    #endregion
    
}
