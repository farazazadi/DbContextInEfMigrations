using DbContextInEfMigrations.Models;
using DbContextInEfMigrations.Security;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextInEfMigrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordOfUsers : Migration
    {
        private readonly MyDbContext _context;

        
        public UpdatePasswordOfUsers(MyDbContext context)
        {
            _context = context;
        }


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            List<User> users = _context.Users.ToList();
        
            users.ForEach(user => user.SetPassword(user.FullName.GetHash()));

            _context.SaveChanges();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
