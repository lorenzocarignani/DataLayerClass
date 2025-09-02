using System.ComponentModel.DataAnnotations;

namespace CapaDatos.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();

        public string FullName => $"{Name} {LastName}";
    }
}
