using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Ship
    {
        [Key]
        public Guid ShipId { get; set; }
        public string Name { get; set; }
        public string TypeShip { get; set; }
        public int Lenght { get; set; }
        public int Witch { get; set; }
        public Guid PortId { get; set; }
        public Port Port { get; set; }
        public string color { get; set; }
    }
}
