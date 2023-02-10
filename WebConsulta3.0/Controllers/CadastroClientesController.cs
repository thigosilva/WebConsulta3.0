using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebConsulta3._0.Data;
using WebConsultaCliente2._0.Poco;

namespace WebConsulta3._0.Controllers
{
    public class CadastroClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastroClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CadastroClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroCliente.ToListAsync());
        }

        // GET: CadastroClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCliente = await _context.CadastroCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroCliente == null)
            {
                return NotFound();
            }

            return View(cadastroCliente);
        }

        // GET: CadastroClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Idade")] CadastroCliente cadastroCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroCliente);
        }

        // GET: CadastroClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCliente = await _context.CadastroCliente.FindAsync(id);
            if (cadastroCliente == null)
            {
                return NotFound();
            }
            return View(cadastroCliente);
        }

        // POST: CadastroClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Idade")] CadastroCliente cadastroCliente)
        {
            if (id != cadastroCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroClienteExists(cadastroCliente.Id))
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
            return View(cadastroCliente);
        }

        // GET: CadastroClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCliente = await _context.CadastroCliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroCliente == null)
            {
                return NotFound();
            }

            return View(cadastroCliente);
        }

        // POST: CadastroClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroCliente = await _context.CadastroCliente.FindAsync(id);
            _context.CadastroCliente.Remove(cadastroCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroClienteExists(int id)
        {
            return _context.CadastroCliente.Any(e => e.Id == id);
        }
    }
}
