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
    }
}