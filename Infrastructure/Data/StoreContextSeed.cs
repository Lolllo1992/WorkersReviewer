//classe utilizzate per riempire il DB, i file sono dentro WorkersReviewer\Infrastructure\Data\SeedData\*.json
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed 
    {
        public static async Task SeedAsync(StoreContext context){
            //si verifica se tabella dei brand sia vuota, in tal caso si riempie. Stessa cosa per prodotti e tipo.
            if (!context.ProductBrands.Any()){
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any()){
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
            if (!context.Products.Any()){
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }
            

            //ci occupiamo del caricamento vero e proprio
            if (context.ChangeTracker.HasChanges()){
                await context.SaveChangesAsync();
            }
        }  
    }
}