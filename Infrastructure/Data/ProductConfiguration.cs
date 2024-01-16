//serve per dichiarare eventualzi eccezioni nel DB
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //impostiamo che il campo id è obbligatorio, non strettamente necessario perchè quando si crea campo Id viene definito automaticamente come primary + auto incremented
            builder.Property(p => p.Id).IsRequired();

            //si imposta name obbligatorio e massimo di 100 byte, stessa cosa per i campi successivi
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();

            //si imposta prezzo come numero di 18 interi e 2 decimali
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            //configuramo relazione, un brand può avere più prodotti associati. Stessa cosa per il tipo
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);

            
            /* builder.HasOne(p => p.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId); */




            //////////////////////////////    
            
            ///

        }
    }
}