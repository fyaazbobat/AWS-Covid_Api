using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_Core.Models
{
    public class Covid_Dto
    {
        public int Id { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public string Confirmed { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
    }
}
