using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueOfPlots.Models.Configurations
{
    public class PhotoEntityConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PHT_ID").ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(x => x.Content).WithOne().HasForeignKey<PhotoContent>(x => x.Id);
            builder.Property(x => x.AlbumId).HasColumnName("ALB_ID").IsRequired();
            builder.Property(x => x.Name).HasColumnName("PHT_NAME").IsRequired();
            builder.Property(x => x.Extension).HasColumnName("PHT_EXTENSION").IsRequired();
            builder.Ignore(x => x.Thumbnail);
        }
    }
}
