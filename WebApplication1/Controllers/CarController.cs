using Data.Enums;
using Data.Models;
using Data.Service;
using Data.Service.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {

        private ICarService carService;
        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
            carService = new CarService();
        }
        [Route("~/controller/get/{dateFrom}/{dateTo}/{location}")]
        [HttpGet]
        public IEnumerable<Car> Get(DateTime dateFrom, DateTime dateTo, Locations location)
        {
            Period period = new Period()
            {
                From = dateFrom,
                To = dateTo,
                Location = location
            };
            return carService.GetCarsByPeriodAndType(period, TypeVehicle.Car);
        }
    }
}
