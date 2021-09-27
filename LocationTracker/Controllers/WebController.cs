using System.Web.Mvc;
using LocationTracker.Providers;

namespace LocationTracker.Controllers
{
    public class WebController : Controller
    {
        public ActionResult Map()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Location(string username)
        {
            return Json(UserProvider.GetLastLocationForUser(username), JsonRequestBehavior.AllowGet);
        }
    }
}