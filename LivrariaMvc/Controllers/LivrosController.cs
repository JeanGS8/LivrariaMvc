using LivrariaMvc.Models;
using LivrariaMvc.Models.ViewModels;
using LivrariaMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace LivrariaMvc.Controllers
{
    public class LivrosController : Controller
    {
        private readonly LivroService _livroService;
        private readonly AutorService _autorService;

        public LivrosController (LivroService livroService, AutorService autorService)
        {
            _livroService = livroService;
            _autorService = autorService;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _livroService.FindAllAsync();
            return View(livros);
        }

        public async Task<IActionResult> Create()
        {
            var autores = await _autorService.FindAllAsync();
            var viewModel = new LivroViewModel() { Autores = autores };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                var autores = await _autorService.FindAllAsync();
                var viewModel = new LivroViewModel() { Autores = autores };
                return View(viewModel);
            }

            await _livroService.InsertAsync(livro);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id is null)
            {
                return RedirectToAction("Error", new { Message = "É necessário passar o ID" });
            }

            var livro = await _livroService.FindByIdAsync(id);

            if (livro is null)
            {
                return RedirectToAction("Error", new { Message = "Livro não encontrado" });
            }

            var autores = await _autorService.FindAllAsync();
            var viewModel = new LivroViewModel() { Livro = livro, Autores = autores };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                var autores = await _autorService.FindAllAsync();
                var viewModel = new LivroViewModel() { Livro = livro, Autores = autores };
                return View(viewModel);
            }

            await _livroService.UpdateAsync(livro);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var viewModel = await _livroService.FindByIdAsync(id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _livroService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            var viewModel = await _livroService.FindByIdAsync(id);
            return View(viewModel);
        }
    }
}
