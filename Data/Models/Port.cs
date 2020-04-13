using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Port
    {
        [Key]
        public Guid PortId { get; set; }
        public string Name { get; set; }
        public string TypePort { get; set; }
        public int Area { get; set; }
        public int Depth { get; set; }
        public int CountPrichal { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public ICollection<Weather> Weathers{get;set;}
    }
}
