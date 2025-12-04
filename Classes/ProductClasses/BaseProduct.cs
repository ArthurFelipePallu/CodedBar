using System.Reflection.Emit;
using System.Text;
using CodedBar.Enums;
using CodedBar.Extensions;
using CodedBar.Structs;

namespace CodedBar.Classes.ProductClasses;

public class BaseProduct
{

    public ProductType ProductType { get; set; }
    
    private float _cost;
    
    protected string  Id { get; set; }

    public string Name { get; set; }
    protected string Description { get; set; }

    protected Measure Measure { get; set; }
    

    protected BaseProduct()
    {
        throw new NotImplementedException();
    }
    public BaseProduct(ProductType type,string name, float cost, UnitOfMeasure unit,float quantityOfMeasure,string description = "") 
    {
        ProductType = type;
        Name = name;
        _cost = cost;
        Description = description;
        Measure = new Measure(){ Unit = unit , Quantity = quantityOfMeasure };
        Id = this.CreateIdFromName();
    }
    public virtual float Cost()
    {
        return _cost;
    }
    public virtual float CostPerUnitOfMeasure()
    {
        return _cost/Measure.Quantity;
    }

    public virtual string ToCsvString()
    {
        var builder = new StringBuilder()
            .Append(ProductType)
            .Append(",").Append(Name)
            .Append(",").Append(_cost)
            .Append(",").Append(Measure.Unit)
            .Append(",").Append(Measure.Quantity)
            .Append(",").Append(Description);
        return builder.ToString();
    }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .Append("Base Product: ").Append(ProductType)
            .Append(" - ").Append(Name)
            .Append(" - ").Append(_cost)
            .Append(" - ").Append(Measure.Unit)
            .Append(" - ").Append(Measure.Quantity)
            .Append(" - ").Append(Description)
            .Append(" - ").Append(Id);

        return builder.ToString();
    }
}