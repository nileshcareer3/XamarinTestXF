using System;
using System.Threading.Tasks;
using XFTest.Models;

namespace XFTest.Services.IServices
{
    public interface ICarWashListService
    {
        Task<Carwashvisit> ProcessToGetCarWashList();
    }
}
