using System.Reflection;
using CodedBar.Classes.ProductClasses;
using CodedBar.Enums;
using CodedBar.Exceptions;
using CodedBar.Extensions;

namespace CodedBar.Repositories;

public class GenericRepository<T>  where T : BaseProduct
{
    private string _csfFormatFilePath;
    private static Dictionary<Type, HashSet<T>> _itemsCollections = new Dictionary<Type, HashSet<T>>();

    static GenericRepository()
    {
       
    }

    
    public bool AddItem(T item)
    {
        var itemType = typeof(T);
        if (!HasTypeAsKey(itemType))
        {
            AddCollectionOfType(itemType);
        }
        return _itemsCollections[itemType].Add(item);
    }
    public bool RemoveItem(T item)
    {
        var itemType = typeof(T);
        if (!HasTypeAsKey(itemType))
        {
            AddCollectionOfType(itemType);
        }
        return _itemsCollections[itemType].Remove(item);
    }
    public IEnumerable<T> GetAllItems()
    {
        var itemType = typeof(T);
        if (!HasTypeAsKey(itemType)) yield break;
        foreach (var item in _itemsCollections[itemType])
        {
            yield return (T)item;
        }
    }

    // public T GetItemById(string itemId)
    // {
    //     var itemType = typeof(T);
    //     if (!HasTypeAsKey(itemType)) 
    //         throw new ProductException("[GENERIC REPOSITORY] Tried to retrieve an item by Id.But Type is not inserted into Dictionary.");
    //     return _itemsCollections[itemType].
    // }
    
    
    private bool HasTypeAsKey(Type type)
    {
        return _itemsCollections.ContainsKey(type);
    }

    private void AddCollectionOfType(Type type)
    {
        _itemsCollections[type] = [];
    }
}