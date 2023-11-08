using Microsoft.EntityFrameworkCore;
using TaskAPI.Entities;

namespace TaskAPI.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base (options) { }

        public DbSet<TaskModel> Tasks { get; set;}
    }
}
