using System.Text;
using CodedBar.Enums;

namespace CodedBar.Classes.ProductClasses;

public class Bottle : BaseProduct 
{
    public BottleType BottleType { get; set; }

    public Bottle( string name, BottleType type, float cost, float quantityOfMeasure , UnitOfMeasure unit, string description = "") : base( name, cost, unit, quantityOfMeasure, description)
    {
        BottleType = type;
        
    }

    public override string ToCsvString()
    {
        var sb = new StringBuilder();
        sb.AppendJoin(",",Name,BottleType.ToString(),Cost(),Measure.Quantity,Measure.Unit,Description);
        return sb.ToString();
    }


    public Bottle FromSavableString(string savableString)
    {
        var split = savableString.Split(',');
        Enum.TryParse(split[1], out BottleType type);
        Enum.TryParse(split[4], out UnitOfMeasure unit);
        var cost = float.Parse(split[2]);
        var quantity = float.Parse(split[3]);
        return new Bottle(     
                      split[0],
                              type,
                              cost,
                             quantity,
                               unit, 
                     split[5]);
    }
}