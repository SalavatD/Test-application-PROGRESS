using app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        private PatientsModel _patientsModel;

        public HomeController(IConfiguration configuration)
        {
            _patientsModel = new PatientsModel(configuration);
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_patientsModel);
        }
    }
}