using CodedBar.Classes.ProductClasses;
using CodedBar.Enums;
using CodedBar.Extensions;

namespace CodedBar.Repositories;

public class GenericRepository<T>  where T : BaseProduct
{
    protected List<T> _products;


    public GenericRepository()
    {
        _products = new List<T>();
       
    }
    
    public void AddItem(T item)
    {
        _products.Add(item);
    }

    public List<T> GetProducts()
    {
        return _products;
    }

    public T GetItemById(string itemId)
    {
        return (_products.FirstOrDefault( x => x.CreateIdFromName() == itemId)) ?? throw new InvalidOperationException();
    }
}