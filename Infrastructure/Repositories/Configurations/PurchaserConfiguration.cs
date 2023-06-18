using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Configurations
{
    internal sealed class PurchaserConfiguration : IEntityTypeConfiguration<Purchaser>
    {
        public void Configure(EntityTypeBuilder<Purchaser> builder)
        {
            builder.ToTable(nameof(Purchaser));
            builder.HasKey(purchaser => purchaser.Id);
            builder.Property(purchaser => purchaser.Id).ValueGeneratedOnAdd();
            builder.Property(product => product.Name).IsRequired();

            builder.HasMany(purchaser => purchaser.Orders)
                .WithOne(order => order.Purchaser)
                .HasForeignKey(order => order.PurchaserId);
        }
    }
}
