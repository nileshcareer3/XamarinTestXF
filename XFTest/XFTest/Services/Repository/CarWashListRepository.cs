using System;
using System.Threading.Tasks;
using RestSharp.Portable;
using XFTest.Models;
using XFTest.Services.IServices;
using XFTest.Utility;

namespace XFTest.Services.Repository
{
    public class CarWashListRepository : BaseWebService, ICarWashListService
    {
      
        public async Task<Carwashvisit> ProcessToGetCarWashList()
        {
            try
            {
                var request = new RestRequest(Constants.RestApi.GetCarWashList);
                return await ExecuteGet<Carwashvisit>(request, false, true);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
