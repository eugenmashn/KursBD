using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Weather
    {
        [Key]
        public Guid WeatherId { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public int HeightWave { get; set; }
        public int WindSpeed { get; set; }
        public Guid PortId { get; set; }
        public Port Port { get; set; }
    }
}
