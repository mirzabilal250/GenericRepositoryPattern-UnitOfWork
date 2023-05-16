using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Context
{
    public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options) : base(options) { }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                    new Actor { Id = 1 , FirstName = "Muhammad Bilal" , LastName = "Shahid"},
                    new Actor { Id = 2, FirstName = "Aizaz", LastName = "Rafique" },
                    new Actor { Id = 3, FirstName = "Adeel", LastName = "Khan" }
                );
            modelBuilder.Entity<Movie>().HasData(
                    new Movie { Id = 1 , Name = "Fast Five" , Description = "Amazing movie of Bilal" , ActorId = 1 },
                    new Movie { Id = 2, Name = "Fast Five", Description = "Amazing movie of Aizaz", ActorId = 2 },
                    new Movie { Id = 3, Name = "Matrix", Description = "Amazing movie of Bilal", ActorId = 1 },
                    new Movie { Id = 4, Name = "Superman", Description = "Amazing movie of Adeel", ActorId = 3 }
                );
        }

    }
}
