using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Models.BoatClub
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Start Date Time is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("From")]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "End Date Time is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("To")]
        public DateTime EndDateTime { get; set; }

        [ForeignKey("User")]
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Boat")]
        public int BoatId { get; set; }

        [DisplayName("Boat Name")]
        public Boat Boat { get; set; }
    }
}
