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
    public class CadastroPagamentoController : Controller
    {
        private readonly VendasContext _context;

        public CadastroPagamentoController(VendasContext context)
        {
            _context = context;
        }

        // GET: CadastroPagamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroPagamento.ToListAsync());
        }

        // GET: CadastroPagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPagamento = await _context.CadastroPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroPagamento == null)
            {
                return NotFound();
            }

            return View(cadastroPagamento);
        }

        // GET: CadastroPagamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroPagamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Opcao_Pagamento")] CadastroPagamento cadastroPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroPagamento);
        }

        // GET: CadastroPagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPagamento = await _context.CadastroPagamento.FindAsync(id);
            if (cadastroPagamento == null)
            {
                return NotFound();
            }
            return View(cadastroPagamento);
        }

        // POST: CadastroPagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Opcao_Pagamento")] CadastroPagamento cadastroPagamento)
        {
            if (id != cadastroPagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroPagamentoExists(cadastroPagamento.Id))
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
            return View(cadastroPagamento);
        }

        // GET: CadastroPagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPagamento = await _context.CadastroPagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroPagamento == null)
            {
                return NotFound();
            }

            return View(cadastroPagamento);
        }

        // POST: CadastroPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroPagamento = await _context.CadastroPagamento.FindAsync(id);
            _context.CadastroPagamento.Remove(cadastroPagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroPagamentoExists(int id)
        {
            return _context.CadastroPagamento.Any(e => e.Id == id);
        }
    }
}
