namespace Tutorials.DesignPattern
{
    internal class Factory
    {
        public static void Examples()
        {
            FileProcessorFactory factory = new FileProcessorFactory();

            // Traitement d'un fichier CSV
            IFileProcessor processor = factory.CreateFileProcessor("csv");
            processor.OpenFile("data.csv");

            // Traitement d'un fichier XML
            processor = factory.CreateFileProcessor("xml");
            processor.OpenFile("data.xml");

            // Traitement d'un fichier JSON
            processor = factory.CreateFileProcessor("json");
            processor.OpenFile("data.json");
        }
    }

    public interface IFileProcessor
    {
        void OpenFile(string filePath);
    }
    public class CsvFileProcessor : IFileProcessor
    {
        public void OpenFile(string filePath)
        {
            Console.WriteLine($"Traitement du fichier CSV : {filePath}");
        }
    }

    public class XmlFileProcessor : IFileProcessor
    {
        public void OpenFile(string filePath)
        {
            Console.WriteLine($"Traitement du fichier XML : {filePath}");
        }
    }
    public class JsonFileProcessor : IFileProcessor
    {
        public void OpenFile(string filePath)
        {
            Console.WriteLine($"Traitement du fichier JSON : {filePath}");
        }
    }
    public class FileProcessorFactory
    {
        public IFileProcessor CreateFileProcessor(string fileType)
        {
            switch (fileType.ToLower())
            {
                case "csv":
                    return new CsvFileProcessor();
                case "xml":
                    return new XmlFileProcessor();
                case "json":
                    return new JsonFileProcessor();
                default:
                    throw new ArgumentException("Type de fichier inconnu");
            }
        }
    }

}
