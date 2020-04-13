using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; }
        public string Name{ get; set; }
        public bool IsPort { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
