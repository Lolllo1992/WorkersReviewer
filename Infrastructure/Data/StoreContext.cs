using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        //tra i parametri Options viene passata anche la stringa di connessione, è dichiarata dentro  apsettinge.develpment.json (se siamo in test...) /apsettinge.json (se siamo in prod...) 
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
    
        //creaiamo una classe Products (di tipo DBset) associata all'entità Product (corrisponde alla tabella) -> necessario importare using API.Entities;
        public DbSet<Product> Products { get; set; }
        
        //creaiamo una classe ProductBrand per consentire creazione tabella
        public DbSet<ProductBrand> ProductBrands { get; set; }

        //creaiamo una classe ProductType per consentire creazione tabella
        public DbSet<ProductType> ProductTypes { get; set; }

        //sovrascriviamo metodo per poter passare le configurazioni personalizzate dentro Data/Config/ProductConfiguration.cs
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}