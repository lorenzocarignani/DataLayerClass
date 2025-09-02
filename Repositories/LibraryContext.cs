using CapaDatos.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos.Repositories
{
    public class LibraryContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        // Confingurar las reglas, relaciones y retricciones

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author)          //Un libro tiene un autor
                .WithMany(a => a.Books)         //un autor tiene muchos libros
                .HasForeignKey(book => book.AuthorId)       //La fk authorId
                .OnDelete(DeleteBehavior.Cascade);          //Si borro el autor, se borran todos los libros

            //Datos de prueba

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name ="Jorge Luis" , LastName= "Borges"},
                new Author { Id = 2, Name ="Julio" , LastName= "Cortazar"}
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "El aleph" , PublishYear = 1949, AuthorId = 1}
                
                );

        }
    }
}
