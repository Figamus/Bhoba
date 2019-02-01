using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bhoba.Data;
using Bhoba.Models;
using Bhoba.Models.FelonBountyViewModel;
using Microsoft.AspNetCore.Identity;

namespace Bhoba.Controllers
{
    public class FelonBountiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FelonBountiesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: FelonBounties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FelonBounties.Include(f => f.BailBondsman).Include(f => f.Felon);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FelonBounties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var felonBounty = await _context.FelonBounties
                .Include(f => f.BailBondsman)
                .Include(f => f.Felon)
                .FirstOrDefaultAsync(m => m.FelonBountyId == id);
            if (felonBounty == null)
            {
                return NotFound();
            }

            return View(felonBounty);
        }

        // GET: FelonBounties/Create
        public async Task<IActionResult> Create(int? id)
        {
            var user = await GetCurrentUserAsync();
            if (user.ApplicationUserRoleId == 2)
            {
                return RedirectToAction("Index", "Felons");
            }
            List<SelectListItem> bailbondsmans = _context.BailBondsmans.Select(bb => new SelectListItem(bb.Name, bb.BailBondsmanId.ToString())).ToList();

            FelonBountyCreateViewModel createViewModel = new FelonBountyCreateViewModel();

            bailbondsmans.Insert(0, new SelectListItem
            {
                Text = "Choose a Bail Bond Agency",
                Value = "0"
            });
            createViewModel.BailBondsmans = bailbondsmans;
            return View(createViewModel);
        }

        // POST: FelonBounties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, FelonBountyCreateViewModel fb)
        {
            var user = await GetCurrentUserAsync();
            if (user.ApplicationUserRoleId == 2)
            {
                return RedirectToAction("Index", "Felons");
            }

            fb.FelonBounty.BondClosed = false;
            fb.FelonBounty.FelonId = id;
            fb.FelonBounty.BailBondsmanId = fb.BailBondsmansId;
            if (fb.BailBondsmansId == 0)
            {
                List<SelectListItem> bailbondsmans = _context.BailBondsmans.Select(bb => new SelectListItem(bb.Name, bb.BailBondsmanId.ToString())).ToList();

                FelonBountyCreateViewModel createViewModel = new FelonBountyCreateViewModel();

                bailbondsmans.Insert(0, new SelectListItem
                {
                    Text = "Choose a Bail Bond Agency",
                    Value = "0"
                });
                createViewModel.BailBondsmans = bailbondsmans;
                if (fb.ErrorMsg == null)
                {
                    createViewModel.ErrorMsg = "Please select a Bail Bondsman";
                    return View(createViewModel);
                }
                return View(createViewModel);
            }
            if (ModelState.IsValid)
            {
                _context.Add(fb.FelonBounty);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Felons", new { id });
            }
            return View(fb);
        }

        // GET: FelonBounties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await GetCurrentUserAsync();
            if (user.ApplicationUserRoleId == 2)
            {
                return RedirectToAction("Index", "Felons");
            }

            FelonBountyEditViewModel createview = new FelonBountyEditViewModel();
            if (id == null)
            {
                return NotFound();
            }

            FelonBounty thing = await _context.FelonBounties
                                            .Where(fb => fb.FelonBountyId == id)
                                            .Include(fb => fb.BailBondsman)
                                            .Include(fb => fb.Felon)
                                            .FirstOrDefaultAsync();

            if (thing == null)
            {
                return NotFound();
            }

            return View(thing);
        }

        // POST: FelonBounties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FelonBounty returnView)
        {
            var user = await GetCurrentUserAsync();
            if (user.ApplicationUserRoleId == 2)
            {
                return RedirectToAction("Index", "Felons");
            }

            if (id != returnView.FelonBountyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                FelonBounty editFelon = new FelonBounty();

                editFelon = await _context.FelonBounties
                                                .Where(fb => fb.FelonBountyId == id)
                                                .Include(fb => fb.BailBondsman)
                                                .Include(fb => fb.Felon)
                                                .FirstOrDefaultAsync();

                editFelon.Description = returnView.Description;
                editFelon.CrimeType = returnView.CrimeType;
                editFelon.PoliceReportNumber = returnView.PoliceReportNumber;
                editFelon.BondClosed = returnView.BondClosed;
                editFelon.BountyAmount = returnView.BountyAmount;

                try
                {
                    _context.Update(editFelon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FelonBountyExists(returnView.FelonBountyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Felons", new { id = editFelon.FelonId});
            }
            return View(returnView);
        }

        // GET: FelonBounties/Delete/5
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

            var felonBounty = await _context.FelonBounties
                .Include(f => f.BailBondsman)
                .Include(f => f.Felon)
                .FirstOrDefaultAsync(m => m.FelonBountyId == id);
            if (felonBounty == null)
            {
                return NotFound();
            }

            return View(felonBounty);
        }

        // POST: FelonBounties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var felonBounty = await _context.FelonBounties.FindAsync(id);
            _context.FelonBounties.Remove(felonBounty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FelonBountyExists(int id)
        {
            return _context.FelonBounties.Any(e => e.FelonBountyId == id);
        }
    }
}
