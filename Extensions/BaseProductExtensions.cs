using System.Runtime.CompilerServices;
using System.Text;
using CodedBar.Classes.ProductClasses;
using CodedBar.Enums;
using CodedBar.Exceptions;

namespace CodedBar.Extensions;

static class BaseProductExtensions
{
    public static string CreateIdFromName(this BaseProduct baseProduct)
    {
        if(baseProduct.Name is null)
            throw new ProductException("[Base Product Extensions] Name cannot be null.");
            
        if(baseProduct.Name.Length <= 2)
            throw new ProductException("[Base Product Extensions] Name cannot have less than 3 characters.");
            
        if( !char.IsUpper(baseProduct.Name[0]) )
            throw new ProductException("[Base Product Extensions] Name needs to start with UpperCase.");
        
        return ShortenName3CharPerWord(baseProduct.Name);
        
    }

    private static string ShortenName3CharPerWord(string name)
    {
        //Split name into words
        var words = name.Split(" ");
        
        //StringBuilder to help build shortened Name
        var shortName = new StringBuilder();

        foreach (var word in words)
        {
            if (!string.IsNullOrWhiteSpace(word) && char.IsUpper(word[0]))
            {
                var shortWord = word.Length >=3 ? word.Substring(0, 3) : word;
                
                shortName.Append(shortWord);
            }
            
            if(char.IsNumber(word[0]))
                shortName.Append(word);
                
            
        }
        
        return shortName.ToString();
    }
    

    public static string ProductToSaveFormat(this BaseProduct baseProduct)
    {
        return baseProduct.ToCsvFormat();
    }
    
    
}