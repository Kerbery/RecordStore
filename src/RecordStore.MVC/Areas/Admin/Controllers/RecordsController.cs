using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.Extensions;
using RecordStore.Core.ViewModels.Record;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecordsController : Controller
    {
        private readonly IRecordServices _recordServices;

        public RecordsController(IRecordServices recordServices)
        {
            _recordServices = recordServices;
        }

        // GET: Admin/Records
        public async Task<IActionResult> Index()
        {
            var records = (await _recordServices.GetAllAsync())
                .Select(r => r.AsViewModel());

            return View(records);
        }

        // GET: Admin/Records/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var record = await _recordServices.GetAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            var recordViewModel = record.AsViewModel();

            return View(recordViewModel);
        }

        // GET: Admin/Records/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRecordViewModel @record)
        {
            if (ModelState.IsValid)
            {
                await _recordServices.CreateAsync(@record);
                return RedirectToAction(nameof(Index));
            }
            return View(@record);
        }

        // GET: Admin/Records/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _recordServices.GetAsync(id.Value);
            if (record == null)
            {
                return NotFound();
            }

            var recordViewModel = new EditRecordViewModel
            {
                Title = record.Title,
                Year = record.Year,
                Price = record.Price,
                Description = record.Description,
                //Format= u.Format,
                //Release = u.Release,
                //RecordCondition = u.RecordCondition,
                //Genres = u.Genres,
                //Styles = u.Styles,
                //Categories = u.Categories
            };
            return View(recordViewModel);
        }

        // POST: Admin/Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditRecordViewModel editRecordViewModel)
        {
            if (ModelState.IsValid)
            {
                await _recordServices.UpdateAsync(editRecordViewModel);
                //try
                //{
                //    _context.Update(@record);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!RecordExists(@record.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            return View(editRecordViewModel);
        }

        // GET: Admin/Records/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @record = await _recordServices.GetAsync(id.Value);
            if (@record == null)
            {
                return NotFound();
            }

            return View(@record);
        }

        // POST: Admin/Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @record = await _recordServices.GetAsync(id);
            if (@record != null)
            {
                await _recordServices.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
