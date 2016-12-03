using CITR.UZBookingProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TicketViewModel
    {
        [Required(ErrorMessage = "required field")]
        public int StartingPointId { get; set; }

        [Required(ErrorMessage = "required field")]
        public int DestinationPointId { get; set; }

        [Required(ErrorMessage = "required field")]
        [Display(Name = "from")]
        public string StartingPointName { get; set; }

        [Required(ErrorMessage = "required field")]
        [Display(Name = "to")]
        public string DestinationPointName { get; set; }

        [Required(ErrorMessage = "required field")]
        [DataType(DataType.Date)]
        [Display(Name = "dep date")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "required field")]
        [DataType(DataType.Time)]
        [Display(Name = "dep time")]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "firstname")]
        public string FirstName { get; set; }

        [Display(Name = "lastname")]
        public string LastName { get; set; }

        public TicketViewModel() {
            DepartureTime = DateTime.Today;
            FirstName = "Иван";
            LastName = "Говнов";
        }

        public Ticket GetTicket() {
             return new Ticket {
                StartingPointId = StartingPointId.ToString(),
                DestinationPointId = DestinationPointId.ToString(),
                StartingPointName = StartingPointName,
                DestinationPointName = DestinationPointName,
                DepartureDate = DepartureDate.ToString("dd.MM.yyy"),
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}