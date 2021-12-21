using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Api.Dto
{
    public class CovidDto
    {


        public int Id { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public string Confirmed { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
    }
    public class CovidDtoDynamo
    {
        [DynamoDBProperty("Id")]
        [DynamoDBHashKey]

        public int Id { get; set; }
        [DynamoDBProperty("Province_State")]
        public string Province_State { get; set; }
        [DynamoDBProperty("Country_Region")]
        public string Country_Region { get; set; }
        [DynamoDBProperty("Confirmed")]
        public string Confirmed { get; set; }
        [DynamoDBProperty("Deaths")]
        public string Deaths { get; set; }
        [DynamoDBProperty("Recovered")]
        public string Recovered { get; set; }
    }




}
