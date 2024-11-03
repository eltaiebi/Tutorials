using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.DesignPattern
{
    internal class Builder
    {
        public static void Examples()
        {
            // Création d'un utilisateur avec seulement les informations obligatoires
            User user1 = new User.UserBuilder("John", "Doe", "john.doe@example.com", "password123")
                .Build();

            // Création d'un utilisateur avec des informations facultatives
            User user2 = new User.UserBuilder("Jane", "Smith", "jane.smith@example.com", "securepassword")
                .SetAddress("123 rue de la Paix")
                .SetPhoneNumber("+123456789")
                .Build();

            // Affichage des informations
            Console.WriteLine($"Utilisateur 1 : {user1.FirstName} {user1.LastName}, Email : {user1.Email}");
            Console.WriteLine($"Utilisateur 2 : {user2.FirstName} {user2.LastName}, Adresse : {user2.Address}, Téléphone : {user2.PhoneNumber}");
        }
    }
    public class User
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string? Address { get; }
        public string? PhoneNumber { get; }

        // Constructeur privé de la classe User
        private User(UserBuilder builder)
        {
            FirstName = builder.FirstName;
            LastName = builder.LastName;
            Email = builder.Email;
            Password = builder.Password;
            Address = builder.Address;
            PhoneNumber = builder.PhoneNumber;
        }

        // Classe interne UserBuilder
        public class UserBuilder
        {
            // Champs obligatoires
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Email { get; private set; }
            public string Password { get; private set; }

            // Champs facultatifs
            public string? Address { get; private set; }
            public string? PhoneNumber { get; private set; }

            // Constructeur du Builder pour les champs obligatoires
            public UserBuilder(string firstName, string lastName, string email, string password)
            {
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Password = password;
            }

            // Méthode pour ajouter l'adresse
            public UserBuilder SetAddress(string address)
            {
                Address = address;
                return this; // Retourne le Builder pour permettre l'enchaînement d'appels
            }

            // Méthode pour ajouter le numéro de téléphone
            public UserBuilder SetPhoneNumber(string phoneNumber)
            {
                PhoneNumber = phoneNumber;
                return this;
            }

            // Méthode pour construire l'objet final User
            public User Build()
            {
                return new User(this);
            }
        }
    }

}
