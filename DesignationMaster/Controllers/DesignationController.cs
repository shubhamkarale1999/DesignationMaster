using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesignationMaster.Data;
using DesignationMaster.Models;

namespace DesignationMaster.Controllers
{
    public class DesignationController : Controller
    {
        private readonly AppDbContext _context;

        public DesignationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Designation
        public async Task<IActionResult> Index()
        {
            ViewBag.CollegeList = _context.CollegeViewMode
        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CollegeName })
        .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult GetDesignations()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            var designations = _context.DesignationMasterViewModel.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
            {
                designations = designations.Where(d =>
                    d.DesignationName.Contains(searchValue) ||
                    d.DesignationAcronym.Contains(searchValue));
                //||
                // d.StaffType.Contains(searchValue));
            }

            var totalRecords = designations.Count();

            var data = designations
                .Skip(skip)
                .Take(pageSize)
                .ToList()
                .Select((d, index) => new
                {
                    rowIndex = skip + index + 1,
                    d.DesignationAcronym,
                    d.DesignationName,
                    //  d.StaffType,
                    //  d.Priority,
                    d.RolesAndResponsibilities
                });

            return Json(new
            {
                draw = draw,
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords,
                data = data
            });
        }

        public IActionResult AddDesignation()
        {
            ViewBag.CollegeList = new SelectList(_context.CollegeViewMode.ToList(), "Id", "CollegeName");
            ViewBag.StreamList = new List<SelectListItem>
    {
        new SelectListItem { Value = "All", Text = "All" },
        new SelectListItem { Value = "Science", Text = "Science" },
        new SelectListItem { Value = "Arts", Text = "Arts" },
        new SelectListItem { Value = "Commerce", Text = "Commerce" }
    };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDesignation(DesignationMasterViewModel designationMasterViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.DesignationMasterViewModel.Add(designationMasterViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            ViewBag.CollegeList = new SelectList(_context.CollegeViewMode.ToList(), "Id", "CollegeName", designationMasterViewModel.CollegeId);
            ViewBag.StreamList = new List<SelectListItem>
    {
        new SelectListItem { Value = "All", Text = "All" },
        new SelectListItem { Value = "Science", Text = "Science" },
        new SelectListItem { Value = "Arts", Text = "Arts" },
        new SelectListItem { Value = "Commerce", Text = "Commerce" }
    };
            return View();


        }

        // GET: Designation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designationMasterViewModel = await _context.DesignationMasterViewModel
                .Include(d => d.College)
                .Include(d => d.Stream)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designationMasterViewModel == null)
            {
                return NotFound();
            }

            return View(designationMasterViewModel);
        }

        // GET: Designation/Create
        public IActionResult Create()
        {
            ViewData["CollegeId"] = new SelectList(_context.CollegeViewMode, "Id", "CollegeName");
            ViewData["StreamId"] = new SelectList(_context.StreamViewModel, "Id", "StreamName");
            return View();
        }

        // POST: Designation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CollegeId,DesignationCode,DesignationAcronym,DesignationName,StreamId,RolesAndResponsibilities,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Status")] DesignationMasterViewModel designationMasterViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designationMasterViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollegeId"] = new SelectList(_context.CollegeViewMode, "Id", "CollegeName", designationMasterViewModel.CollegeId);
            ViewData["StreamId"] = new SelectList(_context.StreamViewModel, "Id", "StreamName", designationMasterViewModel.StreamId);
            return View(designationMasterViewModel);
        }

        // GET: Designation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designationMasterViewModel = await _context.DesignationMasterViewModel.FindAsync(id);
            if (designationMasterViewModel == null)
            {
                return NotFound();
            }
            ViewData["CollegeId"] = new SelectList(_context.CollegeViewMode, "Id", "CollegeName", designationMasterViewModel.CollegeId);
            ViewData["StreamId"] = new SelectList(_context.StreamViewModel, "Id", "StreamName", designationMasterViewModel.StreamId);
            return View(designationMasterViewModel);
        }

        // POST: Designation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CollegeId,DesignationCode,DesignationAcronym,DesignationName,StreamId,RolesAndResponsibilities,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Status")] DesignationMasterViewModel designationMasterViewModel)
        {
            if (id != designationMasterViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designationMasterViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationMasterViewModelExists(designationMasterViewModel.Id))
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
            ViewData["CollegeId"] = new SelectList(_context.CollegeViewMode, "Id", "CollegeName", designationMasterViewModel.CollegeId);
            ViewData["StreamId"] = new SelectList(_context.StreamViewModel, "Id", "StreamName", designationMasterViewModel.StreamId);
            return View(designationMasterViewModel);
        }

        // GET: Designation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designationMasterViewModel = await _context.DesignationMasterViewModel
                .Include(d => d.College)
                .Include(d => d.Stream)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designationMasterViewModel == null)
            {
                return NotFound();
            }

            return View(designationMasterViewModel);
        }

        // POST: Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designationMasterViewModel = await _context.DesignationMasterViewModel.FindAsync(id);
            if (designationMasterViewModel != null)
            {
                _context.DesignationMasterViewModel.Remove(designationMasterViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationMasterViewModelExists(int id)
        {
            return _context.DesignationMasterViewModel.Any(e => e.Id == id);
        }
    }
}
