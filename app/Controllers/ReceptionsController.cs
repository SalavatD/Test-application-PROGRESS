using System.Dynamic;
using app.Models;
using app.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace app.Controllers
{
    public class ReceptionsController : Controller
    {
        private ReceptionsModel _receptionsModel;
        private DiagnosesModel _diagnosesModel;
        private PatientsModel _patientsModel;

        public ReceptionsController(IConfiguration configuration)
        {
            _receptionsModel = new ReceptionsModel(configuration);
            _diagnosesModel = new DiagnosesModel(configuration);
            _patientsModel = new PatientsModel(configuration);
        }

        [HttpGet]
        public IActionResult Index()
        {
            dynamic models = new ExpandoObject();
            models.Patients = _patientsModel;
            models.Receptions = _receptionsModel;
            return View(models);
        }

        [HttpGet]
        public JsonResult DiagnosesList()
        {
            return Json(_diagnosesModel.GetDiagnoses());
        }

        [HttpGet]
        public IActionResult New()
        {
            dynamic models = new ExpandoObject();
            models.Patients = _patientsModel;
            models.Diagnoses = _diagnosesModel;
            return View(models);
        }

        [HttpPost]
        public IActionResult Create(ReceptionHttp reception)
        {
            _receptionsModel.AppendReception(new Reception(reception));
            return RedirectToAction("Index");
        }
    }
}