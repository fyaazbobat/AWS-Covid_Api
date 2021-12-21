using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Api.Model
{
    public class CovidModel
    {

        
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public DateTime Last_Update { get; set; }
        public string Lat { get; set; }
        public string Long_ { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public string Recovered { get; set; }
        public double Active { get; set; }
        public double FIPS { get; set; }
        public string Incident_Rate { get; set; }
        public string Total_Test_Results { get; set; }
        public string People_Hospitalized { get; set; }
        public string Case_Fatality_Ratio { get; set; }
        public double UID { get; set; }
        public string ISO3 { get; set; }
        public string Testing_Rate { get; set; }
        public string Hospitalization_Rate { get; set; }
       
    }
}
