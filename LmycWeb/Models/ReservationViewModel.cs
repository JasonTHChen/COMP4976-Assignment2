using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Models
{
    public class ReservationViewModel
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

        public string Username { get; set; }
        
        public string BoatName { get; set; }
    }
}
