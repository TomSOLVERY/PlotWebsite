using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Gallery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueOfPlots.Models.Configurations
{
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ALB_ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Name).HasColumnName("ALB_NAME").IsRequired();
            builder.Property(x => x.AuthorUsername).HasColumnName("ALB_AUTHOR_USERNAME").IsRequired();
            builder.HasMany(x => x.Photos).WithOne(x => x.Album).HasForeignKey(x => x.AlbumId);
        }
    }
}
