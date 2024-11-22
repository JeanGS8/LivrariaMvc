using System.ComponentModel.DataAnnotations;

namespace LivrariaMvc.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        [Required]
        public int AutorId { get; set; }

        public Autor? Autor { get; set; }
    }
}
