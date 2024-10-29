using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    internal static class Encapsulation
    {
        public static void Examples()
        {
            EncapsulationExample example = new EncapsulationExample();

            // Accès aux membres depuis une instance
            // Console.WriteLine(example.privateField); // Erreur : `private` est accessible uniquement dans la classe
            Console.WriteLine(example.PublicField); // Accessible partout
                                                    // Console.WriteLine(example.ProtectedField); // Erreur : `protected` est accessible uniquement dans la classe et ses dérivées
            Console.WriteLine(example.InternalField); // Accessible car dans le même assembly
            Console.WriteLine(example.ProtectedInternalField); // Accessible car dans le même assembly
                                                               // Console.WriteLine(example.PrivateProtectedField); // Erreur : `private protected` est accessible uniquement dans le même assembly et les dérivées

            // Appel de la méthode qui affiche les champs privés
            example.ShowFields();

            // Utilisation de la classe dérivée pour tester l'accès
            DerivedExample derivedExample = new DerivedExample();
            derivedExample.ShowInheritedFields();
        }
    }

    public class EncapsulationExample
    {
        // 1. Modificateur `private` :
        // Ce champ est accessible uniquement dans cette classe. Il n'est pas accessible depuis une classe dérivée ou une instance.
        private string privateField = "Je suis privé";

        // 2. Modificateur `public` :
        // Ce champ est accessible partout où l'instance de la classe est accessible.
        public string PublicField = "Je suis public";

        // 3. Modificateur `protected` :
        // Ce champ est accessible dans cette classe et dans les classes qui en héritent.
        protected string ProtectedField = "Je suis protégé";

        // 4. Modificateur `internal` :
        // Ce champ est accessible partout dans le même assembly, mais pas en dehors.
        internal string InternalField = "Je suis interne";

        // 5. Modificateur `protected internal` :
        // Ce champ est accessible dans le même assembly et dans les classes dérivées (même dans un autre assembly).
        protected internal string ProtectedInternalField = "Je suis protégé et interne";

        // 6. Modificateur `private protected` :
        // Ce champ est accessible dans cette classe et dans les classes dérivées, mais uniquement dans le même assembly.
        private protected string PrivateProtectedField = "Je suis privé et protégé";

        // Exemple d'une méthode pour accéder aux champs privés depuis l'intérieur de la classe
        public void ShowFields()
        {
            Console.WriteLine(privateField); // Accessible ici
            Console.WriteLine(PublicField);  // Accessible ici
            Console.WriteLine(ProtectedField); // Accessible ici
            Console.WriteLine(InternalField); // Accessible ici
            Console.WriteLine(ProtectedInternalField); // Accessible ici
            Console.WriteLine(PrivateProtectedField); // Accessible ici
        }
    }

    // Classe dérivée pour illustrer les modificateurs `protected`, `protected internal`, et `private protected`
    public class DerivedExample : EncapsulationExample
    {
        public void ShowInheritedFields()
        {
            // Console.WriteLine(privateField); // Erreur : `private` n'est pas accessible dans une classe dérivée
            Console.WriteLine(PublicField); // Accessible partout
            Console.WriteLine(ProtectedField); // Accessible car `protected` est hérité
            Console.WriteLine(InternalField); // Accessible car dans le même assembly
            Console.WriteLine(ProtectedInternalField); // Accessible car `protected internal` est accessible ici
                                                       // Console.WriteLine(PrivateProtectedField); // Erreur : `private protected` n'est pas accessible en dehors de l'assembly même dans une classe dérivée
        }
    }

}
