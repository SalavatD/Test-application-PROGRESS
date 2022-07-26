using System;
using System.Dynamic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using app.Models;
using app.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace app.Controllers
{
    public class PatientsController : Controller
    {
        private PatientsModel _patientsModel;
        private ReceptionsModel _receptionsModel;

        public PatientsController(IConfiguration configuration)
        {
            _patientsModel = new PatientsModel(configuration);
            _receptionsModel = new ReceptionsModel(configuration);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_patientsModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatientHttp patient)
        {
            _patientsModel.AppendPatient(new Patient(patient));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Patient(string patientId)
        {
            ViewBag.patientId = patientId;
            dynamic models = new ExpandoObject();
            models.Patients = _patientsModel;
            models.Receptions = _receptionsModel;
            return View(models);
        }

        [HttpGet]
        public ContentResult Xml(string patientId)
        {
            PatientXml patient = new PatientXml(
                _patientsModel.GetPatientInfo(patientId),
                _receptionsModel.GetReceptionsByPatientId(patientId)
            );
            string xml;
            using (var stringWriter = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(patient.GetType());
                xmlSerializer.Serialize(stringWriter, patient);
                xml = stringWriter.ToString();
            }

            return new ContentResult
            {
                Content = xml,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }
    }
}