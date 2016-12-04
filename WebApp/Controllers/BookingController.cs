using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CITR.UZBookingProvider.Gateway;
using WebApp.Models;
using CITR.UZBookingProvider.DataAccess;
using CITR.UZBookingProvider;

namespace WebApp.Controllers
{
    public class BookingController : Controller
    {
        private UZAPIConfig _api;

        public BookingController() {
            _api = new UZAPIConfig();
            ViewBag.Places = new Dictionary<string, int>();
        }

        // GET: Booking
        public ActionResult Index(){
            return View(new TicketViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Places(TicketViewModel model) {
            if (model.StartingPointId == 0) {
                ModelState.AddModelError("StartingPointName", "required field");
            }
            if (model.DestinationPointId == 0) {
                ModelState.AddModelError("DestinationPointName", "required field");
            }
            if (ModelState.IsValid) {
                var ticket = model.GetTicket();
                using (UZBookingRepository repository = new UZBookingRepository(ticket, _api)) {
                    var places = await repository.GetAvaliablePlacesCount(CoachType.Any);
                    ViewBag.Places = places;
                }
            }
            return PartialView("_Places");
        }

        public async Task<ActionResult> Stations(string term) {
            using(IUZDataGatewaySlim gateway = new UZDataGatewaySlim(_api)) {
                var stationSet = await gateway.GetStations(term);
                return Json(stationSet.Stations, JsonRequestBehavior.AllowGet);
            }
        }
    }
}