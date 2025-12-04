using System.Reflection.Emit;
using System.Text;
using CodedBar.Enums;
using CodedBar.Extensions;
using CodedBar.Interfaces;
using CodedBar.Structs;

namespace CodedBar.Classes.ProductClasses;

public class BaseProduct : ISavable
{
    public ProductType ProductType { get; set; }
    
    protected float _cost;
    
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


    public virtual string ToCsvFormat()
    {
        var builder = new StringBuilder() // INDEX
            .Append(ProductType)                         //  0
            .Append(" - ").Append(Name)                  //  1
            .Append(" - ").Append(_cost)                 //  2
            .Append(" - ").Append(Measure.Unit)          //  3
            .Append(" - ").Append(Measure.Quantity)      //  4
            .Append(" - ").Append(Description);          //  5

        return builder.ToString();
    }

    public virtual BaseProduct FromCsvFormat(string csvFormat)
    {
       var csvData = csvFormat.Split(',');

       return new BaseProduct()
       {
           ProductType = (ProductType)Enum.Parse(typeof(ProductType), csvData[0]),
           Name = csvData[1],
           _cost = float.Parse(csvData[2]),
           Measure = new Measure
           {
               Unit = (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), csvData[0]),
               Quantity = float.Parse(csvData[4])
           },
           Description = csvData[5]
       };

    }
}