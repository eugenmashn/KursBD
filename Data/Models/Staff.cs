using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class StaffPerson
    {
        [Key]
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirstDay { get; set; }
        public string stat { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public string Phone { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public Guid ShipId { get; set; }
        public Ship Ship { get; set; }

    }
}
