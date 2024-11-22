using LivrariaMvc.Data;
using LivrariaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaMvc.Services
{
    public class LivroService
    {
        private readonly LivrariaMvcContext _context;

        public LivroService (LivrariaMvcContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Livro>> FindAllAsync()
        {
            return await _context.Livro
                .Include(x => x.Autor)
                .ToListAsync();
        }

        public async Task<Livro?> FindByIdAsync(int? id)
        {
            return await _context.Livro
                .Include(x => x.Autor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Livro livro)
        {
            try
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(Livro livro)
        {
            try
            {
                _context.Update(livro);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var livro = await _context.Livro.FindAsync(id);
                _context.Remove(livro);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
