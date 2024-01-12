using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] // serve per indicare che è un controller API -> consente di ottimizzare il codice (sarà uno standrad per i nostri controlli)
    [Route("api/[controller]")] //serve per dire dove andare a prendere il controller di partenza (CotnrollerBase)
    public class ProductsController : ControllerBase
    {
        //stringhe rapide:
        // - prop -> crea proprietà
        // - ctor -> crea constructor

        //il costruttore viene chiamato dentro Program.cs tramite builder.Services.AddDbContext<StoreContext>(opt =>...), quello tra parentesi è il context passato
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
            
        }

        [HttpGet] // indica il tipo di chiamata, potranno essere HttpDelete, HttpPut,...
       /* è questa sarebbe la chiamata senza utilizzo di task asincroni che nel caso di elaborazioni molto lunghe sono necessari, quindi è consigliato utilizzare sempre async tasks     
       public ActionResult<List<Product>> GetProducts()
       {
            var prodotti = _context.Products.ToList();
            return prodotti;
        } */
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var prodotti = await _context.Products.ToListAsync();
            return prodotti;
        }

        [HttpGet("{id}")] // indica che nella chiamata deve essere passato un valora che verrà assegnato alla variabile id. Api controller si occupa della validazione dei dati passati... se apassata una stringa da errore ad esempio
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return  await _context.Products.FindAsync(id);
        }
    }
}