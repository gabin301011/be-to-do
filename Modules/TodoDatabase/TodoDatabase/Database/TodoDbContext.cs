using Microsoft.EntityFrameworkCore;

namespace TodoDatabase.Database {
    public class TodoDbContext : DbContext {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public virtual DbSet<Models.Assignment> Assignments => Set<Models.Assignment>();
        public virtual DbSet<Models.HistoryAssignment> HistoryAssignments => Set<Models.HistoryAssignment>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
