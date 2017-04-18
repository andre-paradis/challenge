using common;
using System.Web.Mvc;

namespace challenge.Controllers
{
    public class HomeController : Controller
    {
        private static ILogger _logger;

        public HomeController(ILogProvider logProvider)
        {
            if(_logger == null)
            {
                _logger = logProvider.GetLogger(typeof(HomeController).FullName);
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            _logger.Info("Index action called on home controller");

            return View();
        }
    }
}