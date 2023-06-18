using AutoMapper;
using DataBase.Models;
using DataBase.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACarAPI.Models;

namespace RentACarAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("cars")]
    public class CarsController : ControllerBase
    {

        private readonly ICarService _carService;
        private readonly ILogger<CarsController> _logger;
        private readonly IMapper _mapper;

        public CarsController(ILogger<CarsController> logger, ICarService carService, IMapper mapper)
        {
            _logger = logger;
            _carService = carService;
            _mapper = mapper;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<VehicleDTO>>> Get([FromBody] SearchModel searchModel)
        //{
        //    Period period = new Period()
        //    {
        //        From = searchModel.FromDate,
        //        To = searchModel.ToDate,
        //        Location = new Location { Id = searchModel.LocationId }
        //    };
        //    var result = await _carService.GetCarsByPeriodAndType(period, searchModel.Type);

        //    if (result == null || result.Count() == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<IEnumerable<VehicleDTO>>(result));
        //}

        [AllowAnonymous]
        [HttpGet(Name = "GetCars")]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return Ok(await _carService.GetCars());
        }

        [HttpPost("{location}")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<VehicleDTO>> AddVehicle(string location, VehicleCreateDTO vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Car car = _mapper.Map<Car>(vehicle);

            var result = await _carService.AddNewCar(car, new Location { Name = location });

            if (result != null)
            {
                return CreatedAtRoute("GetCars", _mapper.Map<VehicleDTO>(car));
            }
            return Conflict();
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> UpdateVehicle(Car vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if (!carService.IsCarExist(vehicle))
            //{
            //    return NotFound();
            //}

            //var result = carService.UpdateCar(vehicle);

            if (true)
            {
                return NoContent();
            }
            return Conflict();
        }

        [HttpDelete("{vehicleID}")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> DeleteVehicle(int vehicleID)
        {
            //if (!carService.Exists(vehicleID))
            //{
            //    return NotFound();
            //}

            //var result = carService.Remove(vehicleID));

            if(true)
            {
                return NoContent();
            }
            return Conflict();
        }
    }
}
