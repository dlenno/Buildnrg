using SensorApi.DAL;
using SensorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SensorApi.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo = new Repository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetReadings()
        {
            var readings = repo.GetReadings().Where(a => a.Time > DateTime.Today.AddDays(-1)).OrderBy(b => b.Time).ToList();
            List<TempVM> vm = new List<TempVM>();
            foreach (var item in readings)
            {
                vm.Add(new TempVM { Time = item.Time.ToShortTimeString(), Temp = item.Bmp180_Temp });
            }
            return Json(vm);
            
        }

        [HttpPost]
        public ActionResult GetPressureReadings()
        {
            var readings = repo.GetReadings().Where(a => a.Time > DateTime.Today.AddDays(-1)).OrderBy(b => b.Time).ToList();
            List<PressureVM> vm = new List<PressureVM>();
            foreach (var item in readings)
            {
                vm.Add(new PressureVM { Time = item.Time.ToShortTimeString(), Pressure = item.Bmp180_Pressure });
            }
            return Json(vm);

        }

        public ActionResult Get()        // IEnumerable<Reading>
        {
            var readings = repo.GetReadings();
            return Json(readings);
        }
    }
}
