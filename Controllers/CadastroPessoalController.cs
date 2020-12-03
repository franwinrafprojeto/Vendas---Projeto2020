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
    public class CadastroPessoalController : Controller
    {
        private readonly VendasContext _context;

        public CadastroPessoalController(VendasContext context)
        {
            _context = context;
        }

        // GET: CadastroPessoal
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroPessoal.ToListAsync());
        }

        // GET: CadastroPessoal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPessoal = await _context.CadastroPessoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroPessoal == null)
            {
                return NotFound();
            }

            return View(cadastroPessoal);
        }

        // GET: CadastroPessoal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroPessoal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome_Sobrenome,CPF,RG,Data_Nascimento")] CadastroPessoal cadastroPessoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPessoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroPessoal);
        }

        // GET: CadastroPessoal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPessoal = await _context.CadastroPessoal.FindAsync(id);
            if (cadastroPessoal == null)
            {
                return NotFound();
            }
            return View(cadastroPessoal);
        }

        // POST: CadastroPessoal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome_Sobrenome,CPF,RG,Data_Nascimento")] CadastroPessoal cadastroPessoal)
        {
            if (id != cadastroPessoal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPessoal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroPessoalExists(cadastroPessoal.Id))
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
            return View(cadastroPessoal);
        }

        // GET: CadastroPessoal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPessoal = await _context.CadastroPessoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroPessoal == null)
            {
                return NotFound();
            }

            return View(cadastroPessoal);
        }

        // POST: CadastroPessoal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroPessoal = await _context.CadastroPessoal.FindAsync(id);
            _context.CadastroPessoal.Remove(cadastroPessoal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroPessoalExists(int id)
        {
            return _context.CadastroPessoal.Any(e => e.Id == id);
        }
    }
}
