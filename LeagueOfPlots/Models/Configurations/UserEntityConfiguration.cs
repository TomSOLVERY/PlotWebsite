using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeagueOfPlots.Models.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("ID").IsRequired();
            builder.Property(x => x.UserName).HasColumnName("USERNAME");
            builder.Property(x => x.FirstName).HasColumnName("FIRSTNAME").IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LASTNAME").IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnName("PASSWORD_HASH");
            builder.Property(x => x.Email).HasColumnName("EMAIL");
            builder.Property(x => x.Avatar).HasColumnName("AVATAR");
            builder.Property(x => x.NormalizedUserName).HasColumnName("NORMALIZED_USERNAME");
            builder.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            builder.Property(x => x.SecurityStamp).HasColumnName("SECURITY_STAMP");
            builder.Property(x => x.Instagram).HasColumnName("INSTAGRAM");
            builder.Property(x => x.Facebook).HasColumnName("FACEBOOK");
            builder.Property(x => x.Twitter).HasColumnName("TWITTER");
            builder.Property(x => x.FauxFrerotPoints).HasColumnName("FAUX_FREROT_POINTS").IsRequired().HasDefaultValue(0);
            builder.Property(x => x.BirthDate).HasColumnName("BIRTHDATE").IsRequired().HasDefaultValue(new DateTime());
            builder.Ignore(x => x.AccessFailedCount);
            builder.Ignore(x => x.EmailConfirmed);
            builder.Ignore(x => x.NormalizedEmail);
            builder.Ignore(x => x.LockoutEnabled);
            builder.Ignore(x => x.LockoutEnd);
            builder.Ignore(x => x.PhoneNumber);
            builder.Ignore(x => x.PhoneNumberConfirmed);
            builder.Ignore(x => x.TwoFactorEnabled);
            
        }
    }
}
