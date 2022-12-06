using CarApiAiskinimas.Models;
using CarApiAiskinimas.Models.Dto;

namespace CarApiAiskinimas.Services
{
    public interface ICarAdapter
    {
        GetCarResult Bind(Car car);
        Car Bind(PostCarRequest car);
    }
}
