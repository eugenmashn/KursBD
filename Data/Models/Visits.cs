﻿using System;
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateArrival { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDeparture { get; set; }
        public Guid ShipId { get; set; }
        public Ship Ship { get; set; }
        public int NumberPrich { get; set; }
        public string Purpose { get; set; }
        public Guid PortId { get; set; }
        public Port Port { get; set; }

    }
}
