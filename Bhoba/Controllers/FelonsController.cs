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
using Bhoba.Models.AddressViewModel;
using Microsoft.AspNetCore.Identity;

namespace Bhoba.Controllers
{
    public class FelonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FelonsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Felons
        [Authorize]
        public async Task<IActionResult> Index()
        {
            FelonIndexViewModel createView = new FelonIndexViewModel();

            createView.Felons = await _context.Felons
                        .Include(f => f.FelonAddresses)
                        .Include(f => f.FelonBounties)
                        .ToListAsync();

            // Get the current user
            createView.User = await GetCurrentUserAsync();

            return View(createView);
        }

        // GET: Felons/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FelonDetailsViewModel createView = new FelonDetailsViewModel();

            createView.User = await GetCurrentUserAsync();

            createView.Felon = await _context.Felons
                                .Include(f => f.FelonAddresses)
                                .Include(f => f.FelonBounties)
                                    .ThenInclude(fb => fb.BailBondsman)
                                .FirstOrDefaultAsync(m => m.FelonId == id);

            foreach (var item in createView.Felon.FelonAddresses)
            {
                Address addresses = _context.Addresses
                                    .Where(ad => ad.AddressId == item.AddressId)
                                    .FirstOrDefault();
                createView.Addresses.Add(addresses);
            }

            foreach (var item in createView.Addresses)
            {
                AddressVM avm = new AddressVM();
                avm.AddressId = item.AddressId;
                avm.StreetAddress = item.StreetAddress;
                avm.City = item.City;
                avm.State = item.State;
                avm.ZipCode = item.ZipCode;
                avm.Latitude = item.Latitude;
                avm.Longitude = item.Longitude;

                createView.listOfAvm.Add(avm);
            }

            foreach (var item in createView.Felon.FelonBounties)
            {
                BailBondsman bonds = _context.BailBondsmans.Where(bb => bb.BailBondsmanId == item.BailBondsmanId).FirstOrDefault();
                createView.BailBondsmen.Add(bonds);
            }

            if (createView.Felon == null)
            {
                return NotFound();
            }

            return View(createView);
        }

        // GET: Search Felons
        public async Task<IActionResult> Search(string search)
        {
            FelonSearchViewModel createView = new FelonSearchViewModel();

            createView.Search = search;
            createView.User = await GetCurrentUserAsync();
            createView.Felons = await _context.Felons
                                        .Where(felon => felon.FirstName.Contains(search) || felon.LastName.Contains(search) || (felon.FirstName + " " + felon.LastName).Contains(search))
                                        .Include(f => f.FelonAddresses).Include(f => f.FelonBounties)
                                        .ToListAsync();

            return View(createView);
        }

        // GET: Felons/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            if(user.ApplicationUserRoleId == 2){
                return RedirectToAction("Index", "Felons");
            }
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
            newFelon.BondClosed = false;

            if (newFelon.BailBondsmansId == 0)
            {
                List<SelectListItem> bailbondsmans = _context.BailBondsmans.Select(bb => new SelectListItem(bb.Name, bb.BailBondsmanId.ToString())).ToList();

                FelonCreateViewModel createViewModel = new FelonCreateViewModel();

                bailbondsmans.Insert(0, new SelectListItem
                {
                    Text = "Choose a Bail Bond Agency",
                    Value = "0"
                });
                createViewModel.BailBondsmans = bailbondsmans;
                if (newFelon.ErrorMsg == null)
                {
                    createViewModel.ErrorMsg = "Please select a Bail Bondsman";
                    return View(createViewModel);
                }
                return View(createViewModel);
            }

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
                _context.Add(newFelon.Felon);

                var newFelonAddress = new FelonAddress
                {
                    FelonId = newFelon.Felon.FelonId,
                    AddressId = newAddress.AddressId
                };
                _context.Add(newFelonAddress);

                var newFelonBounty = new FelonBounty
                {
                    FelonId = newFelon.Felon.FelonId,
                    BailBondsmanId = newFelon.BailBondsmansId,
                    PoliceReportNumber = newFelon.PoliceReportNumber,
                    CrimeType = newFelon.CrimeType,
                    Description = newFelon.Description,
                    BountyAmount = newFelon.BondAmount,
                    BondClosed = newFelon.BondClosed
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
            var user = await GetCurrentUserAsync();
            if (user.ApplicationUserRoleId == 2)
            {
                return RedirectToAction("Index", "Felons");
            }

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
            var user = await GetCurrentUserAsync();
            if (user.ApplicationUserRoleId == 2)
            {
                return RedirectToAction("Index", "Felons");
            }

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
