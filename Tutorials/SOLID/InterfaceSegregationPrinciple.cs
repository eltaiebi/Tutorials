using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.SOLID
{
    internal class InterfaceSegregationPrinciple
    {
        public static void Examples()
        {
            // Création d'instances pour chaque type de document
            DocumentPdf pdfDocument = new DocumentPdf();
            DocumentCSV csvDocument = new DocumentCSV();
            DocumentXML xmlDocument = new DocumentXML();

            // Importation de chaque document
            Console.WriteLine("Importation des documents:");
            pdfDocument.ImportDocument("document.pdf");
            csvDocument.ImportDocument("document.csv");
            xmlDocument.ImportDocument("document.xml");

            // Parsing du PDF (seulement les documents qui implémentent IDocumentParser)
            Console.WriteLine("\nAnalyse des documents:");
            if (pdfDocument is IDocumentParser pdfParser)
            {
                Console.WriteLine(pdfParser.ParseDocument());
            }

            // Impression des documents (seulement les documents qui implémentent IDocumentPrint)
            Console.WriteLine("\nImpression des documents:");
            if (csvDocument is IDocumentPrint csvPrinter)
            {
                csvPrinter.PrintDocument();
            }

            // XML ne supporte ni l'impression ni le parsing, donc aucune méthode inutile n'est appelée.
        }
    }
    // Interface dédiée à l'importation de documents
    public interface IDocumentImporter
    {
        void ImportDocument(string filePath);
    }

    public interface IDocumentParser
    {
        string ParseDocument();
    }

    public interface IDocumentPrint
    {
        bool PrintDocument();
    }
    public class DocumentPdf : IDocumentImporter, IDocumentParser
    {
        public void ImportDocument(string filePath)
        {
            Console.WriteLine("PDF importé depuis " + filePath);
        }

        public string ParseDocument()
        {
            Console.WriteLine("Parsing du PDF en cours...");
            return "Contenu du PDF analysé";
        }
    }

    public class DocumentCSV : IDocumentImporter, IDocumentPrint
    {
        public void ImportDocument(string filePath)
        {
            Console.WriteLine("CSV importé depuis " + filePath);
        }

        public bool PrintDocument()
        {
            Console.WriteLine("Impression du CSV en cours...");
            return true;
        }
    }

    public class DocumentXML : IDocumentImporter
    {
        public void ImportDocument(string filePath)
        {
            Console.WriteLine("XML importé depuis " + filePath);
        }
    }


}
