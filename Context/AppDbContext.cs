using Microsoft.EntityFrameworkCore;
using TO_DO_LIST.Model;

namespace TO_DO_LIST.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Lista> Listas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lista>(tb =>
            {

                tb.HasKey(col => col.id);
                tb.Property(col => col.id).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.titulo).HasMaxLength(50);
                tb.Property(col => col.tarea).HasMaxLength(200);
                tb.Property(col => col.tareaC).HasDefaultValue(false);


                tb.ToTable("TO-DO-LIST");


            });

        }

    }



    
}
