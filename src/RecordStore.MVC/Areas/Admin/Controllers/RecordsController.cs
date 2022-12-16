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
        private readonly IFormatServices _formatServices;
        private readonly IReleaseServices _releaseServices;
        private readonly IConditionServices _conditionServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IGenreServices _genreServices;
        private readonly IStyleServices _styleServices;

        public RecordsController(
            IRecordServices recordServices,
            IFormatServices formatServices,
            IReleaseServices releaseServices,
            IConditionServices conditionServices,
            ICategoryServices categoryServices,
            IGenreServices genreServices,
            IStyleServices styleServices)
        {
            _recordServices = recordServices;
            _formatServices = formatServices;
            _releaseServices = releaseServices;
            _conditionServices = conditionServices;
            _categoryServices = categoryServices;
            _genreServices = genreServices;
            _styleServices = styleServices;
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
        public async Task<IActionResult> Create()
        {
            ViewData["Formats"] = (await _formatServices.GetAllAsync()).Select(f => f.AsDTO());
            ViewData["Releases"] = (await _releaseServices.GetAllAsync()).Select(r => r.AsDTO());
            ViewData["Conditions"] = (await _conditionServices.GetAllAsync()).Select(c => c.AsDTO());
            var record = new CreateRecordViewModel
            {
                Genres = (await _genreServices.GetAllAsync()).Select(g => g.AsViewModel()).ToList(),
                Styles = (await _styleServices.GetAllAsync()).Select(s => s.AsViewModel()).ToList(),
                Categories = (await _categoryServices.GetAllAsync()).Select(g => g.AsViewModel()).ToList()
            };
            return View(record);
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

            ViewData["Formats"] = (await _formatServices.GetAllAsync()).Select(f => f.AsDTO());
            ViewData["Releases"] = (await _releaseServices.GetAllAsync()).Select(r => r.AsDTO());
            ViewData["Conditions"] = (await _conditionServices.GetAllAsync()).Select(c => c.AsDTO());
            ViewData["Categories"] = (await _categoryServices.GetAllAsync()).Select(c => c.AsDTO());
            ViewData["Styles"] = (await _styleServices.GetAllAsync()).Select(s => s.AsDTO());
            ViewData["Genres"] = (await _genreServices.GetAllAsync()).Select(s => s.AsDTO());
            ViewData["Id"] = id;

            var recordViewModel = new EditRecordViewModel
            {
                Title = record.Title,
                Year = record.Year,
                Price = record.Price,
                Description = record.Description,
                FormatId = record.FormatId,
                RecordConditionId = record.RecordConditionId,
                ReleaseId = record.ReleaseId,
                Genres = (await _genreServices.GetAllAsync()).Select(g => g.AsViewModel(record.Genres.Select(g => g.Id).Contains(g.Id))).ToList(),
                Styles = (await _styleServices.GetAllAsync()).Select(s => s.AsViewModel(record.Styles.Select(s => s.Id).Contains(s.Id))).ToList(),
                Categories = (await _categoryServices.GetAllAsync()).Select(c => c.AsViewModel(record.Categories.Select(c => c.Id).Contains(c.Id))).ToList(),
                Photos = record.Photos.OrderBy(p => p.Position).Select(p => p.Filename).ToList()
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
                await _recordServices.UpdateAsync(id, editRecordViewModel);
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

            return View(@record.AsViewModel());
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
