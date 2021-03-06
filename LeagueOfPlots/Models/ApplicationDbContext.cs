﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueOfPlots.Models.Configurations;
using LeagueOfPlots.Models.Gallery;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfPlots.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Int32>,Int32>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<PhotoContent> PhotoContents { get; set; }
        public DbSet<RegistrationModel> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AlbumEntityConfiguration());
            builder.ApplyConfiguration(new PhotoEntityConfiguration());
            builder.ApplyConfiguration(new PhotoContentEntityConfiguration());
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new RegistrationEntityConfiguration());
        }
    }
}
