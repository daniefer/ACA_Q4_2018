using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Models
{
    public class Appointment
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt")]
        public DateTime appDate { get; set; }
        public int id { get; set; }
    }
}
