namespace LivrariaMvc.Models.ViewModels
{
    public class LivroViewModel
    {
        public Livro Livro { get; set; }
        public IEnumerable<Autor> Autores { get; set; }
    }
}
