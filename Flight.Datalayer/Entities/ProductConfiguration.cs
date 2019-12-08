using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flight.DataLayer.Entities
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title);
            builder.Property(c => c.Price);
            builder.Property(c => c.ImageUrl);
            builder.HasOne(x => x.Category);
        }
    }
}