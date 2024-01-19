namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; } //Descrizione del prodotto

        public decimal Price { get; set; } //Prezzo 

        public string PictureUrl { get; set; } //percorso dell'immagine

        public string ProductType { get; set; } //tipo proddotto, è una "related entity" (un'altra classe). 

        public string ProductBrand { get; set; } //marca proddotto, simile a ProductType


    }
}