using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CITR.UZBookingProvider.Gateway;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index(){
            return View(new TicketViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TicketViewModel model) {
            return View();
        }

        public async Task<ActionResult> GetStations(string term) {
            using(IUZDataGatewaySlim gateway = new UZDataGatewaySlim(new UZAPIConfig())) {
                var stationSet = await gateway.GetStations(term);
                return Json(stationSet.Stations, JsonRequestBehavior.AllowGet);
            }
        }
    }
}