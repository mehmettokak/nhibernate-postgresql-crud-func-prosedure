using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHFPOSTGRSQL.Models;
using NHFPOSTGRSQL.Models.EntityModel;
using NHFPOSTGRSQL.Models.NHFHelper.NHFData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NHFPOSTGRSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPersonList()
        {
            var aa = PersonProfilFactory.GetPersonProfil();
            return Json(PersonProfilFactory.GetPersonProfil());

        }
        [HttpGet]
        public JsonResult F_GetPersonList()
        {
            var aa = PersonProfilFactory.F_GetPersonProfil();
            return Json(PersonProfilFactory.F_GetPersonProfil());
        }
        
        [HttpGet]
        public JsonResult AddPerson()
        {
            var time = DateTime.Now.Millisecond;
            var model = new personprofil()
            {
                firstname = "FirstName_" + time,
                lastname = "LastName_" + time
            };
            return Json(PersonProfilFactory.AddPerson(model) ? $"({model.firstname} {model.lastname}) Başarılı bir şekilde eklendi." : "Ekleme başarısız!!!");
        }

        [HttpGet]
        public JsonResult F_AddPerson()
        {
            var time = DateTime.Now.Millisecond;
            var model = new personprofil()
            {   personprofilid = 0,
                firstname = "F_FirstName_" + time,
                lastname = "F_LastName_" + time
            };
            return Json(PersonProfilFactory.F_AddPerson(model) != null ? $"({model.firstname} {model.lastname}) Başarılı bir şekilde eklendi." : "Ekleme başarısız!!!");
        }
      
        [HttpGet]
        public JsonResult P_AddPerson()
        {
            var time = DateTime.Now.Millisecond;
            var model = new personprofil()
            {
                firstname = "P_FirstName_" + time,
                lastname = "P_LastName_" + time
            };
            return Json(PersonProfilFactory.P_AddPerson(model) != null ? $"({model.firstname} {model.lastname}) Başarılı bir şekilde eklendi." : "Ekleme başarısız!!!");
        }
        [HttpGet]
        public JsonResult UpdatePerson(int id)
        {
            var result = PersonProfilFactory.UpdatePerson(id);
            return Json(result != null ? result : "Güncelleme başarısız!!!");
        }
        [HttpGet]
        public JsonResult F_UpdatePerson(int id)
        {
            var result = PersonProfilFactory.F_UpdatePerson(id);
            return Json(result != null ? result : "Güncelleme başarısız!!!");
        }
        [HttpGet]
        public JsonResult P_UpdatePerson(int id)
        {
            var result = PersonProfilFactory.P_UpdatePerson(id);
            return Json(result != null ? result : "Güncelleme başarısız!!!");
        }
        [HttpGet]
        public JsonResult DeletePerson(int id)
        {
            var result = PersonProfilFactory.DeletePerson(id);
            return Json(result != null ? result : "Silme işlemi başarısız!!!");
        }
        [HttpGet]
        public JsonResult F_DeletePerson(int id)
        {
            var result = PersonProfilFactory.F_DeletePerson(id);
            return Json(result != null ? result : "Silme işlemi başarısız!!!");
        }
        [HttpGet]
        public JsonResult P_DeletePerson(int id)
        {
            var result = PersonProfilFactory.P_DeletePerson(id);
            return Json(result != null ? result : "Silme işlemi başarısız!!!");
        }




















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
