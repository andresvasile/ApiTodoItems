using ApiTodoItems.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTodoItems.Persistence
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) :base(options)
        {
             
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}