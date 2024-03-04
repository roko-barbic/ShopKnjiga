﻿using Microsoft.EntityFrameworkCore;
using ShopKnjiga.Models;

namespace ShopKnjiga.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
         
    }

    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new
            {
                Id = 1,
                Name = "SciFi",
                DisplayOrder = 1
            },
            new 
            {
                Id = 2,
                Name = "Novel",
                DisplayOrder = 2
            },
            new 
            {
                Id = 3,
                Name = "Thriller",
                DisplayOrder = 3
            }
            );
    }
}
