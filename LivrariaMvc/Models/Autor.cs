using System.ComponentModel.DataAnnotations;

namespace LivrariaMvc.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public ICollection<Livro>? Livros { get; set; }
    }
}
