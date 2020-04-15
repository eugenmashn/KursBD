using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
   public class Visits
    {
        [Key]
        public Guid VisitsId { get; set; }
        public DateTime DateArrival { get; set; }
        public DateTime DateDeparture { get; set; }
        public Guid ShipId { get; set; }
        public Ship Ship { get; set; }
        public int NumberPrich { get; set; }
        public string Purpose { get; set; }

    }
}
