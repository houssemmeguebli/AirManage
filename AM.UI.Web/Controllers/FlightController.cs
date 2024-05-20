using AM.Core.Domain;
using AM.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        readonly IFlightService flightService;
         readonly IPlaneService planeService;
        public FlightController(IFlightService flightService, 
            IPlaneService planeService)
        {
            this.flightService = flightService;
            this.planeService = planeService;

        }
        // GET: FlightController
        public ActionResult Index(string filtre)
        {
            if (string.IsNullOrEmpty(filtre))
            {
                return View(flightService.GetALL());

            }
            else
            {
                return View(flightService.GetALL().Where(f => f.FlightDate.ToString() == filtre));
            }
        }
        public ActionResult sortFlights()
        {
            return View("Index",flightService.SortFlights());
        }


        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]// GET: FlightController/Create
        public ActionResult Create()
        {
            var planes = planeService.GetALL(); 
            ViewBag.Planes = new SelectList(planes, "PlaneId", "PlaneId"); 
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Flight f)
        {
            try
            {
                flightService.Add(f);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
