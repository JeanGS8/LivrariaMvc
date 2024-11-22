using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LivrariaMvc.Models;

namespace LivrariaMvc.Data
{
    public class LivrariaMvcContext : DbContext
    {
        public LivrariaMvcContext (DbContextOptions<LivrariaMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Autor> Autor { get; set; } = default!;
        public DbSet<Livro> Livro { get; set; } = default!;
    }
}
