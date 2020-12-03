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
    public class CadastroEnderecoController : Controller
    {
        private readonly VendasContext _context;

        public CadastroEnderecoController(VendasContext context)
        {
            _context = context;
        }

        // GET: CadastroEndereco
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroEndereco.ToListAsync());
        }

        // GET: CadastroEndereco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEndereco = await _context.CadastroEndereco
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroEndereco == null)
            {
                return NotFound();
            }

            return View(cadastroEndereco);
        }

        // GET: CadastroEndereco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroEndereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Cep,Estado,Complemento,NumeroCasa,StatusEntrega")] CadastroEndereco cadastroEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroEndereco);
        }

        // GET: CadastroEndereco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEndereco = await _context.CadastroEndereco.FindAsync(id);
            if (cadastroEndereco == null)
            {
                return NotFound();
            }
            return View(cadastroEndereco);
        }

        // POST: CadastroEndereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Cep,Estado,Complemento,NumeroCasa,StatusEntrega")] CadastroEndereco cadastroEndereco)
        {
            if (id != cadastroEndereco.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroEnderecoExists(cadastroEndereco.ID))
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
            return View(cadastroEndereco);
        }

        // GET: CadastroEndereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEndereco = await _context.CadastroEndereco
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cadastroEndereco == null)
            {
                return NotFound();
            }

            return View(cadastroEndereco);
        }

        // POST: CadastroEndereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroEndereco = await _context.CadastroEndereco.FindAsync(id);
            _context.CadastroEndereco.Remove(cadastroEndereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroEnderecoExists(int id)
        {
            return _context.CadastroEndereco.Any(e => e.ID == id);
        }
    }
}
