using Covid_Api.Dto;
using Covid_Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Api.BLL
{
    public interface ICovidService
    {

        List<CovidModel> getAllData();
        Task<IEnumerable<CovidDtoDynamo>> getAllAsync();

        Task<CovidDtoDynamo> getByIdAsync(int id);

        Task<bool> AddDataAsync(CovidDto data);

        Task<bool> UpdateDataAsync(CovidDto dataToUpdate);
        Task<bool> DeleteDataAsync(int Id);

    }
}
