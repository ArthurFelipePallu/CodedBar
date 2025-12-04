using System.Text;
using CodedBar.Enums;
using CodedBar.Structs;

namespace CodedBar.Classes.ProductClasses;

public class Bottle : BaseProduct 
{
    public BottleType BottleType { get; set; }

    public Bottle(ProductType prodType, BottleType bottleType, string name, float cost, float quantityOfMeasure , UnitOfMeasure unit, string description = "") : base(prodType, name, cost, unit, quantityOfMeasure, description)
    {
        BottleType = bottleType;
    }

    private Bottle()
    {
        throw new NotImplementedException();
    }

    public override string ToCsvFormat()
    {
        var sb = new StringBuilder();
        sb.AppendJoin(",",ProductType.ToString(),BottleType.ToString(),Name,Cost(),Measure.Quantity,Measure.Unit,Description);
        return sb.ToString();
    }

    public override BaseProduct FromCsvFormat(string csvFormat)
    {
        var csvData = csvFormat.Split(',');
        return new Bottle()
        {
            ProductType = (ProductType)Enum.Parse(typeof(ProductType), csvData[0]),
            BottleType = (BottleType)Enum.Parse(typeof(BottleType), csvData[1]),
            Name = csvData[2],
            _cost = float.Parse(csvData[3]),
            Measure = new Measure
            {
                Unit = (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), csvData[4]),
                Quantity = float.Parse(csvData[5])
            },
            Description = csvData[6]
        };
        
    }
    
}