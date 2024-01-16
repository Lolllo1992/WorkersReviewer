namespace Core.Entities
{
    public class Product : BaseEntity
    {
/* 
        tolta perchè è stata crata BaseEntity quindi non serve più in quanto la classe padre ne possiede già il metodo
        public int Id { get; set; } */        //impostando Id viene automaticamente riconosciuto come primary Id, se lo avessi chiamato MyId non sarebbe stato possibile avrei dovuto utilizzarre il parametro [key] come sotto
        /* [key]
        public int MyID { get; set; } */

        public string Name { get; set; }

        public string Description { get; set; } //Descrizione del prodotto

        public decimal Price { get; set; } //Prezzo 

        public string PictureUrl { get; set; } //percorso dell'immagine

        public ProductType ProductType { get; set; } //tipo proddotto, è una "related entity" (un'altra classe). 

        public int ProductTypeId  { get; set; }

        public ProductBrand ProductBrand { get; set; } //marca proddotto, simile a ProductType

        public int ProductBrandId  { get; set; }

    }
}
