using Microsoft.EntityFrameworkCore;
using ShopKnjiga.Models;

namespace ShopKnjiga.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
         
    }

    public DbSet<Category> Categories { get; set; }  
}
