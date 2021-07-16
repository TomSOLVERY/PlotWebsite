using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueOfPlots.Models.Configurations
{
    public class RegistrationEntityConfiguration : IEntityTypeConfiguration<RegistrationModel>
    {
        public void Configure(EntityTypeBuilder<RegistrationModel> builder)
        {
            builder.ToTable("REGISTRATION");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Key).HasColumnName("KEY").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("FIRSTNAME").IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LASTNAME").IsRequired();
            builder.Property(x => x.IsRegister).HasColumnName("IS_REGISTER").IsRequired();
        }
    }
}
