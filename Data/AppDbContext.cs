using jwt.Models;
using Microsoft.EntityFrameworkCore;

namespace jwt.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users { get; set; }
    
}