using LivrariaMvc.Data;
using LivrariaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaMvc.Services
{
    public class AutorService
    {
        private readonly LivrariaMvcContext _context;

        public AutorService(LivrariaMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Autor>?> FindAllAsync()
        {
            return await _context.Autor
                .Include(x => x.Livros)
                .ToListAsync();
        }

        public async Task<Autor?> FindByIdAsync(int? id)
        {
            return await _context.Autor
                .Include(x => x.Livros)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Autor autor)
        {
            try
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
}

        public async Task UpdateAsync(Autor autor)
        {
            try
            {
                _context.Update(autor);
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
                var autor = await _context.Autor.FindAsync(id);
                _context.Remove(autor);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
