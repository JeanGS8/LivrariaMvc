using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LivrariaMvc.Data;
using LivrariaMvc.Models;
using LivrariaMvc.Services;

namespace LivrariaMvc.Controllers
{
    public class AutoresController : Controller
    {
        private readonly AutorService _autorService;

        public AutoresController(AutorService autorService)
        {
            _autorService = autorService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _autorService.FindAllAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new Autor();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }
            
            await _autorService.InsertAsync(autor);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Error", new { Message = "É necessário passar o ID" });
            }

            var viewModel = await _autorService.FindByIdAsync(id);

            if (viewModel is null)
            {
                return RedirectToAction("Error", new { Message = "Autor não encontrado" });
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }

            await _autorService.UpdateAsync(autor);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Error", new { Message = "É necessário passar o ID" });
            }

            var viewModel = await _autorService.FindByIdAsync(id);

            if (viewModel is null)
            {
                return RedirectToAction("Error", new { Message = "Autor não encontrado" });
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _autorService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await _autorService.FindByIdAsync(id);
            return View(viewModel);
        }
    }
}
