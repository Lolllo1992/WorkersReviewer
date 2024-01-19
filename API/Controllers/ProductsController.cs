using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
       
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo , IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;
                    
        }

        [HttpGet] // indica il tipo di chiamata, potranno essere HttpDelete, HttpPut,...
       /* è questa sarebbe la chiamata senza utilizzo di task asincroni che nel caso di elaborazioni molto lunghe sono necessari, quindi è consigliato utilizzare sempre async tasks     
       public ActionResult<List<Product>> GetProducts()
       {
            var prodotti = _context.Products.ToList();
            return prodotti;
        } */
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {

            var spec = new ProductsWithTypesAndBrandsSpecification();

            var prodotti = await _productRepo.ListAsync(spec);
            return Ok( _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(prodotti));
        }

        [HttpGet("{id}")] // indica che nella chiamata deve essere passato un valora che verrà assegnato alla variabile id. Api controller si occupa della validazione dei dati passati... se apassata una stringa da errore ad esempio
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var products = await _productRepo.GetEntityWithSpec(spec);

            /* return  new ProductToReturnDto{
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                PictureUrl = products.PictureUrl,
                ProductType = products.ProductType.Name,
                ProductBrand = products.ProductBrand.Name

            }; sarebbe la sintassi da scrivere senza automapper */

            return _mapper.Map<Product, ProductToReturnDto>(products);
            
        }
        
        [HttpGet("brands")] //senza parentesi graffe indicare il valore dell'indidirizzo e non il nome della variabile
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return  Ok(await _productBrandRepo.ListAllAsync());
        }
        
        [HttpGet("types")] //senza parentesi graffe indicare il valore dell'indidirizzo e non il nome della variabile
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return  Ok(await _productTypeRepo.ListAllAsync());
        }

    }
}