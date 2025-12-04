// See https://aka.ms/new-console-template for more information

using CodedBar;
using CodedBar.Services;
using CodedBar.Repositories;
using CodedBar.Classes.ProductClasses;

Console.WriteLine("Hello, World!");


HortiRepository HortiRep = new HortiRepository();
//BottleRepository bottleRep = new BottleRepository();


//FileService.WriteObjectToFile(HortiRep.GetHortiProducts(), "hortiProducts.txt");


// Ingredient ing1 = new Ingredient(){ Product = HortiRep.GetHortiProductById(0) , Quantity = 100 };
// Ingredient ing2 = new Ingredient(){ Product = HortiRep.GetHortiProductById(0) , Quantity = 30 };
// Ingredient ing3 = new Ingredient(){ Product = bottleRep.GetBottleById(1) , Quantity = 250 };
// Ingredient ing4 = new Ingredient(){ Product = bottleRep.GetBottleById(2) , Quantity = 100 };
// Ingredient ing5 = new Ingredient(){ Product = bottleRep.GetBottleById(3) , Quantity = 50 };
//
// List<Ingredient> ingList = new List<Ingredient>();
// ingList.Add(ing1);
// ingList.Add(ing3);
// ingList.Add(ing5);
// ComplexProduct complexProduct = new ComplexProduct("Produção de Laranja" , 200,"Produção feita com laranjas", ingList);
//
//
// Console.WriteLine(complexProduct.ToString());