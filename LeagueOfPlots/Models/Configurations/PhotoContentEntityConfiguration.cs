using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueOfPlots.Models.Configurations
{
    public class PhotoContentEntityConfiguration : IEntityTypeConfiguration<PhotoContent>
    {
        public void Configure(EntityTypeBuilder<PhotoContent> builder)
        {
            builder.ToTable("Photo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PHT_ID").IsRequired();
            builder.Property(x => x.Content).HasColumnName("PHT_CONTENT").IsRequired();
        }
    }
}
