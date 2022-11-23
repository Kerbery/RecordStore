using Microsoft.AspNetCore.Mvc;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetailsController : Controller
    {
        // GET: DetailsController
        public ActionResult Index()
        {
            return View();
        }
    }
}
