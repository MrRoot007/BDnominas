using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nomina2018.Core.Entities;

#nullable disable

namespace Nomina2018.Infrastructure.Data
{
    public partial class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");


            builder.HasKey(e => e.Id);

            builder.ToTable("Address");

            builder.Property(e => e.Id).HasColumnName("iIdAddress");

            builder.Property(e => e.IZipCode).HasColumnName("iZipCode");

            builder.Property(e => e.SCity)
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnName("sCity");

            builder.Property(e => e.SStreet)
                        .HasMaxLength(10)
                        .HasColumnName("sStreet")
                        .IsFixedLength(true);
        }
    }
}
