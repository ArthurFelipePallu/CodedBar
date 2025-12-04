using CodedBar.Classes.ProductClasses;
using CodedBar.Extensions;

namespace CodedBar.Services;

public static class FileService
{
    public static List<string> ReadLinesFromFile(string filePath)
    {
        try
        {
            using var reader = new StreamReader(filePath);
            List<string> lines = [];
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null) lines.Add(line);
            }

            return lines;
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void WriteObjectToFile<T>( List<T> objects,string filePath) where T: BaseProduct
    {
        try
        {
            using var writer = new StreamWriter(filePath);
            foreach (var obj in objects)
            {
                writer.WriteLine(obj.ProductToSaveFormat());
            }
            
            Console.WriteLine($"Lista de produtos salva em {filePath}");
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }



    
}