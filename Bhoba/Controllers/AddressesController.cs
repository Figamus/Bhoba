using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bhoba.Data;
using Bhoba.Models;
using Bhoba.Models.AddressViewModel;

namespace Bhoba.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Addresses.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AddressDetailsViewModel createview = new AddressDetailsViewModel();

            var address = await _context.Addresses
                .Include(f => f.FelonAddresses)
                .FirstOrDefaultAsync(m => m.AddressId == id);

            createview.Address = address;


            createview.Felons = await _context.Addresses
                                                .Where(ad => ad.StreetAddress.ToUpper().Trim() == address.StreetAddress.ToUpper().Trim()
                                                    && ad.City.ToUpper().Trim() == address.City.ToUpper().Trim()
                                                    && ad.State.ToUpper().Trim() == address.State.ToUpper().Trim()
                                                    && ad.ZipCode.ToUpper().Trim() == address.ZipCode.ToUpper().Trim())
                                                .Include(ad => ad.FelonAddresses)
                                                    .ThenInclude(fa => fa.Felon)
                                                .SelectMany(ad => ad.FelonAddresses)
                                                .Select(fa => fa.Felon)
                                                .ToListAsync();

            if (address == null)
            {
                return NotFound();
            }

            return View(createview);
        }

        // GET: Addresses/Create
        public IActionResult Create(int? id)
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);

                var newFelonAddress = new FelonAddress
                {
                    FelonId = id,
                    AddressId = address.AddressId
                };
                _context.Add(newFelonAddress);
                await _context.SaveChangesAsync();

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Felons", new { id });
            }
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,StreetAddress,City,State,ZipCode")] Address address)
        {
            if (id != address.AddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var felonaddresses = await _context.FelonAddresses.Where(fa => fa.AddressId == address.AddressId).FirstOrDefaultAsync();
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Felons", new { id = felonaddresses.FelonId });
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var felonaddresses = await _context.FelonAddresses.Where(fa => fa.AddressId == id).FirstOrDefaultAsync();

            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Felons", new { id = felonaddresses.FelonId });
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressId == id);
        }
    }
}
