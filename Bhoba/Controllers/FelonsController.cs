using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bhoba.Data;
using Bhoba.Models;
using Microsoft.AspNetCore.Authorization;
using Bhoba.Models.FelonViewModel;

namespace Bhoba.Controllers
{
    public class FelonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FelonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Felons
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var felons = await _context.Felons.Include(f => f.FelonAddresses).Include(f => f.FelonBounties).ToListAsync();
            return View(felons);
        }

        // GET: Felons/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var felon = await _context.Felons
                .FirstOrDefaultAsync(m => m.FelonId == id);
            if (felon == null)
            {
                return NotFound();
            }

            return View(felon);
        }

        // GET: Felons/Create
        [Authorize]
        public IActionResult Create()
        {
            List<SelectListItem> bailbondsmans = _context.BailBondsmans.Select(bb => new SelectListItem(bb.Name, bb.BailBondsmanId.ToString())).ToList();

            FelonCreateViewModel createViewModel = new FelonCreateViewModel();

            bailbondsmans.Insert(0, new SelectListItem
            {
                Text = "Choose a Bail Bond Agency",
                Value = "0"
            });
            createViewModel.BailBondsmans = bailbondsmans;
            return View(createViewModel);
        }

        // POST: Felons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FelonCreateViewModel newFelon)
        {
            if (ModelState.IsValid)
            {
                var newAddress = new Address
                {
                    StreetAddress = newFelon.Address.StreetAddress,
                    City = newFelon.Address.City,
                    State = newFelon.Address.State,
                    ZipCode = newFelon.Address.ZipCode
                };
                _context.Add(newAddress);
                await _context.SaveChangesAsync();

                _context.Add(newFelon.Felon);
                await _context.SaveChangesAsync();

                var newFelonAddress = new FelonAddress
                {
                    FelonId = newFelon.Felon.FelonId,
                    AddressId = newAddress.AddressId
                };
                _context.Add(newFelonAddress);
                await _context.SaveChangesAsync();

                var newFelonBounty = new FelonBounty
                {
                    FelonId = newFelon.Felon.FelonId,
                    BailBondsmanId = newFelon.BailBondsmansId
                };
                _context.Add(newFelonBounty);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Felons", new { id = newFelon.Felon.FelonId });
            }
            return View(newFelon);
        }

        // GET: Felons/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var felon = await _context.Felons.FindAsync(id);
            if (felon == null)
            {
                return NotFound();
            }
            return View(felon);
        }

        // POST: Felons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FelonId,FirstName,LastName,DateOfBirth,Alias")] Felon felon)
        {
            if (id != felon.FelonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(felon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FelonExists(felon.FelonId))
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
            return View(felon);
        }

        // GET: Felons/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var felon = await _context.Felons
                .FirstOrDefaultAsync(m => m.FelonId == id);
            if (felon == null)
            {
                return NotFound();
            }

            return View(felon);
        }

        // POST: Felons/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var felon = await _context.Felons.FindAsync(id);
            _context.Felons.Remove(felon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FelonExists(int id)
        {
            return _context.Felons.Any(e => e.FelonId == id);
        }
    }
}
