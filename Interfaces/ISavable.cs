using CodedBar.Classes.ProductClasses;

namespace CodedBar.Interfaces;

public interface ISavable
{
    string ToCsvFormat();
    //string ToXmlFormat();
    //string ToJsonFormat();
    
    BaseProduct FromCsvFormat(string csvFormat);
}