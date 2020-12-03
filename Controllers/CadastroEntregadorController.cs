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
    public class CadastroEntregadorController : Controller
    {
        private readonly VendasContext _context;

        public CadastroEntregadorController(VendasContext context)
        {
            _context = context;
        }

        // GET: CadastroEntregador
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroEntregador.ToListAsync());
        }

        // GET: CadastroEntregador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEntregador = await _context.CadastroEntregador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroEntregador == null)
            {
                return NotFound();
            }

            return View(cadastroEntregador);
        }

        // GET: CadastroEntregador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroEntregador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome_Entregador,Telefone_Entregador,GetRG_Entregador,Habilitação_Entregador")] CadastroEntregador cadastroEntregador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroEntregador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroEntregador);
        }

        // GET: CadastroEntregador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEntregador = await _context.CadastroEntregador.FindAsync(id);
            if (cadastroEntregador == null)
            {
                return NotFound();
            }
            return View(cadastroEntregador);
        }

        // POST: CadastroEntregador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome_Entregador,Telefone_Entregador,GetRG_Entregador,Habilitação_Entregador")] CadastroEntregador cadastroEntregador)
        {
            if (id != cadastroEntregador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroEntregador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroEntregadorExists(cadastroEntregador.Id))
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
            return View(cadastroEntregador);
        }

        // GET: CadastroEntregador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEntregador = await _context.CadastroEntregador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroEntregador == null)
            {
                return NotFound();
            }

            return View(cadastroEntregador);
        }

        // POST: CadastroEntregador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroEntregador = await _context.CadastroEntregador.FindAsync(id);
            _context.CadastroEntregador.Remove(cadastroEntregador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroEntregadorExists(int id)
        {
            return _context.CadastroEntregador.Any(e => e.Id == id);
        }
    }
}
