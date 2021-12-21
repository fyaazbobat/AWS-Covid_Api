using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using Covid_Api.Dto;
using Covid_Api.Model;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Document = Amazon.DynamoDBv2.DocumentModel.Document;

namespace Covid_Api.BLL
{
    public class CovidService : ICovidService
    {

        private readonly DynamoDBContext _context;
        AmazonDynamoDBClient _client;
        public CovidService()
        {


            var set = "lcq4afLHsY/Sd7wFIIqIWU4jwUIIbOwWXkw5wVRk";
            var credentials = new BasicAWSCredentials("AKIA5XJASXFF2N36DLLP", set);
            _client = new AmazonDynamoDBClient(credentials, Amazon.RegionEndpoint.USEast2);

            _context = new DynamoDBContext(_client);
        }



        public List<CovidModel> getAllData()
        {
            using (var reader = new StreamReader(@".\data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<CovidModel>().ToList();
            }

        }
        public async Task<IEnumerable<CovidDtoDynamo>> getAllAsync()
        {
            var table = _context.GetTargetTable<CovidDtoDynamo>();
            var scanOps = new ScanOperationConfig();
            var results = table.Scan(scanOps);
            List<Document> data = await results.GetNextSetAsync();

            // transform the generic Document objects
            // into our Entity Model


            IEnumerable<CovidDtoDynamo> readers = _context.FromDocuments<CovidDtoDynamo>((IEnumerable<Amazon.DynamoDBv2.DocumentModel.Document>)data);
            return readers;
        }


        public async Task<bool> AddDataAsync(CovidDto data)
        {
            var dataToAdd = new CovidDtoDynamo
            {

                Id = data.Id,
                Confirmed = data.Confirmed.ToString(),
                Country_Region = data.Country_Region,
                Deaths = data.Deaths.ToString(),
                Province_State = data.Province_State,
                Recovered = data.Recovered

            };
            try
            {
                await _context.SaveAsync<CovidDtoDynamo>(dataToAdd);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public async Task<bool> DeleteDataAsync(int Id)
        {
            await _context.DeleteAsync<CovidDtoDynamo>(Id);
            return true;
        }



        public async Task<CovidDtoDynamo> getByIdAsync(int id)
        {
            return await _context.LoadAsync<CovidDtoDynamo>(id);
        }





        public async Task<bool> UpdateDataAsync(CovidDto data)
        {
            var dataFromDatabase=await getByIdAsync(data.Id);
             var dataToAdd = new CovidDtoDynamo
            {

                Id = data.Id,
                Confirmed = data.Confirmed.ToString(),
                Country_Region = data.Country_Region,
                Deaths = data.Deaths.ToString(),
                Province_State = data.Province_State,
                Recovered = data.Recovered

            };


            dataFromDatabase.Confirmed= dataToAdd.Confirmed;
            dataFromDatabase.Country_Region = dataToAdd.Country_Region;
            dataFromDatabase.Deaths = dataToAdd.Deaths;
            dataFromDatabase.Province_State = dataToAdd.Province_State;
            dataFromDatabase.Province_State = dataToAdd.Recovered;

            try
            {
                await _context.SaveAsync(dataFromDatabase);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
