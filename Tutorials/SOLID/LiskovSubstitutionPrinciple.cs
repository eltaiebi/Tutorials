using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.SOLID
{
    internal class LiskovSubstitutionPrinciple
    {
        public static void Examples()
        {
            Document doc1 = new TextDocument { Content = "Contenu du document texte" };
            Document doc2 = new ReadOnlyDocument { Content = "Contenu en lecture seule" };
            Document doc3 = new EncryptedDocument { Content = "Contenu chiffré" };

            PrintDocument(doc1);
            PrintDocument(doc2);
            PrintDocument(doc3);

            DecryptDocument(doc1);
            DecryptDocument(doc2);
            DecryptDocument(doc3);
        }

        // Méthode qui gère uniquement l'impression
        public static void PrintDocument(Document doc)
        {
            if (doc is IPrintable printable)
            {
                printable.Print();
            }
            else
            {
                Console.WriteLine("Ce document ne peut pas être imprimé.");
            }
        }

        // Méthode qui gère uniquement le déchiffrement
        public static void DecryptDocument(Document doc)
        {
            if (doc is IDecryptable decryptable)
            {
                decryptable.Decrypt();
                Console.WriteLine("Contenu après déchiffrement : " + doc.Content);
            }
            else
            {
                Console.WriteLine("Ce document n'est pas chiffré.");
            }
        }
    }
    // Classe de base pour les documents
    public class Document
    {
        public string Content { get; set; }
    }

    // Interface pour les documents imprimables
    public interface IPrintable
    {
        void Print();
    }

    // Interface pour les documents déchiffrables
    public interface IDecryptable
    {
        void Decrypt();
    }

    // Classe pour les documents texte, qui peut être imprimée
    public class TextDocument : Document, IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Impression du document texte : " + Content);
        }
    }

    // Classe pour les documents en lecture seule, non imprimable
    public class ReadOnlyDocument : Document
    {
        // Pas de méthode Print() ni Decrypt(), car il est en lecture seule
    }

    // Classe pour les documents chiffrés, qui ont une méthode spéciale Decrypt()
    public class EncryptedDocument : Document, IDecryptable
    {
        public void Decrypt()
        {
            Console.WriteLine("Déchiffrement du document...");
            Content = "Contenu déchiffré";
        }
    }
}
