using CodedBar.Enums;

namespace CodedBar.Classes.ProductClasses;

public class ComplexProduct : BaseProduct
{
    List<Ingredient> ingredients = new List<Ingredient>();
    
    public ComplexProduct(string name, float cost, UnitOfMeasure unit,float quantityOfMeasure,string description = "")  : base( name, cost, unit, quantityOfMeasure, description)
    {
        
    }
    
    public override float Cost()
    {
        return ingredients.Sum(ingredient => ingredient.Product.CostPerUnitOfMeasure() * ingredient.Quantity);
    }

    public override float CostPerUnitOfMeasure()
    {
        return Cost() / Measure.Quantity;
    }

    public override string ToString()
    {
        return (from ing in ingredients let product = ing.Product select ("-" + product.Name + "-" + ing.Quantity + "-" + product.Cost())).Aggregate("", (current, ingredientsString) => current + ingredientsString);
    }
}