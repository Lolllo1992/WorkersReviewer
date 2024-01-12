namespace Core.Entities
{
    public class Product
    {

        public int Id { get; set; }        //impostando Id viene automaticamente riconosciuto come primary Id, se lo avessi chiamato MyId non sarebbe stato possibile avrei dovuto utilizzarre il parametro [key] come sotto
        /* [key]
        public int MyID { get; set; } */

        public string Name { get; set; }
    }
}
