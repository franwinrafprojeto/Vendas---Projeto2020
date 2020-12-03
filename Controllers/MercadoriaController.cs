using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vendas.Data;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class MercadoriaController : Controller
    {
        private readonly VendasContext _context;

        public MercadoriaController(VendasContext context)
        {
            _context = context;
        }

        // GET: Mercadoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mercadoria.ToListAsync());
        }

        // GET: Mercadoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercadoria == null)
            {
                return NotFound();
            }

            return View(mercadoria);
        }

        // GET: Mercadoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mercadoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Peso,Tipo_Mercadoria,Quantidade_Mercadoria,Nome_Mercadoria")] Mercadoria mercadoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercadoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mercadoria);
        }

        // GET: Mercadoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria.FindAsync(id);
            if (mercadoria == null)
            {
                return NotFound();
            }
            return View(mercadoria);
        }

        // POST: Mercadoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Peso,Tipo_Mercadoria,Quantidade_Mercadoria,Nome_Mercadoria")] Mercadoria mercadoria)
        {
            if (id != mercadoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercadoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MercadoriaExists(mercadoria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mercadoria);
        }

        // GET: Mercadoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercadoria == null)
            {
                return NotFound();
            }

            return View(mercadoria);
        }

        // POST: Mercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mercadoria = await _context.Mercadoria.FindAsync(id);
            _context.Mercadoria.Remove(mercadoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MercadoriaExists(int id)
        {
            return _context.Mercadoria.Any(e => e.Id == id);
        }
    }
}
