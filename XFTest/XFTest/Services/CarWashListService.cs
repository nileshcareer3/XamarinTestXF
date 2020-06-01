using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using RestSharp.Portable;
using XFTest.Comman;
using XFTest.Models;
using XFTest.Services.IServices;
using XFTest.Utility;

namespace XFTest.Services
{
    public class CarWashListService
    {

        private ICarWashListService repository;

        public CarWashListService(ICarWashListService iRepo)
        {
            repository = iRepo;
        }

        public async Task<Carwashvisit> ProcessToGetCarWashList()
        {
            return await repository.ProcessToGetCarWashList();
        }

    }
}
