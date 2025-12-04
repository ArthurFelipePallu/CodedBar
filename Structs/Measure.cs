using CodedBar.Enums;

namespace CodedBar.Structs;

public struct Measure : IComparable
{
    public UnitOfMeasure Unit;
    public float Quantity;
    
    public int CompareTo(object? obj)
    {
        if(obj is not Measure objMeasure)
            throw new ArgumentException("Object is not of type Measure");
        if(objMeasure.Unit != Unit )
            throw new ArgumentException("Units of Measure are different");
        
        return Quantity.CompareTo(objMeasure.Quantity);
    }
}