using DbContextInEfMigrations.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextInEfMigrations;

public class MyDbContext : DbContext
{

    public DbSet<User> Users { get; private set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

}