using CodedBar.Classes.ProductClasses;
using CodedBar.Enums;

namespace CodedBar.Repositories;

public class BottleRepository
{
    private readonly List<Bottle> _bottles;


    public BottleRepository()
    {
        _bottles = new List<Bottle>();
        AddBottle(new Bottle("Bulleit"   ,BottleType.Whisky,150,750,UnitOfMeasure.Mililiter));
        AddBottle(new Bottle("Singleton" ,BottleType.Whisky,230,750,UnitOfMeasure.Mililiter));
        AddBottle(new Bottle("Glenfidich",BottleType.Whisky,340,750,UnitOfMeasure.Mililiter));
        AddBottle(new Bottle("The Chita" ,BottleType.Whisky,350,700,UnitOfMeasure.Mililiter));
    }
    
    public void AddBottle(Bottle bottle)
    {
        _bottles.Add(bottle);
    }

    public List<Bottle> GetBottles()
    {
        return _bottles;
    }

    // public Bottle GetBottleById(int bottleId)
    // {
    //     return (_bottles.FirstOrDefault( x => x.Id == bottleId) ?? null) ?? throw new InvalidOperationException();
    // }
}