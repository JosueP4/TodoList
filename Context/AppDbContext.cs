using Microsoft.EntityFrameworkCore;
using TO_DO_LIST.Model;

namespace TO_DO_LIST.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Lista> Listas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lista>(tb =>
            {

                tb.HasKey(col => col.id);
                tb.Property(col => col.id).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.titulo).HasMaxLength(50);
                tb.Property(col => col.tarea).HasMaxLength(200);
                tb.Property(col => col.tareaC).HasDefaultValue(false);


                tb.ToTable("Tareas");


            });

            modelBuilder.Entity<Usuario>(tb =>
            {

                tb.HasKey(col => col.IdUser);
                tb.Property(col => col.IdUser).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.User).HasMaxLength(40).IsRequired();
                tb.Property(col => col.Password).HasMaxLength(25).IsRequired();
                tb.Property(col => col.rol).HasMaxLength(20).IsRequired();




                tb.ToTable("Usuarios");
                tb.HasData(
                    new Usuario { IdUser = -1, User = "josue", Password = "josue1020", rol = "admin" },
                    new Usuario { IdUser = -2, User = "Ariel", Password = "ariel1020", rol = "empleado" }


                );


            });

        }

    }




}
