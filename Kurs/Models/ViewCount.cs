using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs.Models
{
    public class ViewCount
    {
        public Guid CountId { get; set; }
        public string Name { get; set; }
        public string typeOfPort { get; set; }
        public int Coun { get; set; }
        public Guid ContryId { get; set; }
    }
}
