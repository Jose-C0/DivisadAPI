using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DivisasAPI.Models;

namespace DivisasAPI.Controllers
{
    public class DivisaModelsController : Controller
    {
        private readonly DivisasDbContext _context;

        public DivisaModelsController(DivisasDbContext context)
        {
            _context = context;
        }

        // GET: DivisaModels
        public async Task<IActionResult> Index()
        {
              return _context.Divisas != null ? 
                          View(await _context.Divisas.ToListAsync()) :
                          Problem("Entity set 'DivisasDbContext.Divisas'  is null.");
        }

        public IActionResult CalcularCambio(int fromDivisa, int toDivisa, decimal amount)
        {
            // Retrieve Divisas based on their IDs
            var fromDivisaModel = _context.Divisas.FirstOrDefault(d => d.DivisaId == fromDivisa);
            var toDivisaModel = _context.Divisas.FirstOrDefault(d => d.DivisaId == toDivisa);

            if (fromDivisaModel != null && toDivisaModel != null)
            {
                // Calculate the exchange rate
                decimal exchangeRate = (decimal)fromDivisaModel.valorDivisa / (decimal)toDivisaModel.valorDivisa;

                // Calculate the converted amount
                decimal convertedAmount = amount * exchangeRate;

                // Store the result in ViewBag
                ViewBag.result = $"{amount} {fromDivisaModel.NombreDivisa} = {convertedAmount} {toDivisaModel.NombreDivisa}";
            }
            else
            {
                ViewBag.result = "Invalid Divisas selected.";
            }

            // Retrieve the list of Divisas for the dropdowns
            var divisas = _context.Divisas.ToList();

            // Pass the list of divisas to the view
            return View(divisas);
        }

        // GET: DivisaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Divisas == null)
            {
                return NotFound();
            }

            var divisaModel = await _context.Divisas
                .FirstOrDefaultAsync(m => m.DivisaId == id);
            if (divisaModel == null)
            {
                return NotFound();
            }

            return View(divisaModel);
        }

        // GET: DivisaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DivisaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DivisaId,NombreDivisa,valorDivisa")] DivisaModel divisaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divisaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divisaModel);
        }

        // GET: DivisaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Divisas == null)
            {
                return NotFound();
            }

            var divisaModel = await _context.Divisas.FindAsync(id);
            if (divisaModel == null)
            {
                return NotFound();
            }
            return View(divisaModel);
        }

        // POST: DivisaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DivisaId,NombreDivisa,valorDivisa")] DivisaModel divisaModel)
        {
            if (id != divisaModel.DivisaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divisaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisaModelExists(divisaModel.DivisaId))
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
            return View(divisaModel);
        }

        // GET: DivisaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Divisas == null)
            {
                return NotFound();
            }

            var divisaModel = await _context.Divisas
                .FirstOrDefaultAsync(m => m.DivisaId == id);
            if (divisaModel == null)
            {
                return NotFound();
            }

            return View(divisaModel);
        }

        // POST: DivisaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Divisas == null)
            {
                return Problem("Entity set 'DivisasDbContext.Divisas'  is null.");
            }
            var divisaModel = await _context.Divisas.FindAsync(id);
            if (divisaModel != null)
            {
                _context.Divisas.Remove(divisaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisaModelExists(int id)
        {
          return (_context.Divisas?.Any(e => e.DivisaId == id)).GetValueOrDefault();
        }
    }
}
