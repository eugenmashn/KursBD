using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Country
    {
        [Key]
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public int CountPort {get;set;}
        public string Capital { get; set; }
    }
}
