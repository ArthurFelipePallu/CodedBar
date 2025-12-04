using CodedBar.Classes.ProductClasses;
using CodedBar.Enums;
using CodedBar.Services;

namespace CodedBar.Repositories;

public class HortiRepository : GenericRepository<BaseProduct>
{
    
    private string _hortiFilePath ="Horti.txt";
    public HortiRepository()
    {
        _products = new List<BaseProduct>();
        
        var fileProducts = FileService.ReadLinesFromFile(_hortiFilePath);
        foreach (var product in fileProducts)
        {
            Console.WriteLine(product);
        }
        // AddHortiProduct(new BaseProduct( "Laranja Bahia"  , 15.0f, UnitOfMeasure.Grams,1000));
        // AddHortiProduct(new BaseProduct( "Laranja Pera"   ,  4.0f, UnitOfMeasure.Grams,1000));
        // AddHortiProduct(new BaseProduct( "Limão Tahiti"   ,  6.0f, UnitOfMeasure.Grams,1000));
        // AddHortiProduct(new BaseProduct( "Limão Siciliano",  9.0f, UnitOfMeasure.Grams,1000));
        // AddHortiProduct(new BaseProduct( "Maçã"           ,  7.0f, UnitOfMeasure.Grams,1000));
        // AddHortiProduct(new BaseProduct( "Pera"           ,  5.0f, UnitOfMeasure.Grams,1000));
        //
        // SaveHortiToFile();
    }

    public void AddHortiProduct(BaseProduct hortiProd)
    {
        _products.Add(hortiProd);
    }

    public List<BaseProduct> GetHortiProducts()
    {
        return _products;
    }

    public void SaveHortiToFile()
    {
        FileService.WriteObjectToFile(GetHortiProducts(), _hortiFilePath);
    }

}
