using CarApiAiskinimas.Models;
using CarApiAiskinimas.Models.Dto;
using CarApiAiskinimas.Repositories;
using CarApiAiskinimas.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

/*
aplikacija automobiliu registas
issukiai:
+ 1. kazkas kas viska kontroliuoja. Tai bus Controller
+ 2. mums reikia kuo greiciau atiduoti darbus front-end. Ty. reikalinga Swagger dokumentacija ir sukurti DTO kontrakta
+ 3. nuspresti kokia yra biznio logika. Biznio modelius
+ 4. Duomenu baze. EF, migracijos
+ 5. programa turi buti gera ir testuojama. Repository
6. programa atvira modifikacijoms. DI
7. programa turi tureti diagnostika produkcineje erdveje. Logger
8. Validacijos. Attribute validations
9. Autentifikacija. JWT 
10. Automatinis testavimas. Unit testai
*/

namespace CarApiAiskinimas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly ICarRepository _repository;
        private readonly ICarAdapter _adapter;

        public CarController(ILogger<CarController> logger,
            ICarRepository repository,
            ICarAdapter adapter)
        {
            _logger = logger;
            _repository = repository;
            _adapter = adapter;
        }

        /// <summary>
        /// Gaunamas duomenu bazeje esanciu automobiliu sarasas
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResult>))]
        //[Produces(MediaTypeNames.Application.Json)]
        //public IActionResult Get()
        //{
        //    var entities = _repository.All();
        //    var model = entities.Select(x => _adapter.Bind(x));

        //    return Ok(model);
        //}

        /// <summary>
        /// Gaunamas duomenu bazeje esanciu automobiliu sarasas
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCarResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get(int id)
        {
            if (!_repository.Exist(id))
            {
                _logger.LogInformation("Car with id {id} not found", id);
                return NotFound();
            }
            var entity = _repository.Get(id);
            var model = _adapter.Bind(entity);

            return Ok(model);
        }


        /// <summary>
        /// Gaunamas visas arba isfiltruotas duomenu bazeje esanciu automobiliu sarasas
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResult>))]
        [Produces(MediaTypeNames.Application.Json)]
        public IActionResult Get([FromQuery] FilterCarRequest req)
        {
            _logger.LogInformation("Getting car list with parameters {req}", JsonConvert.SerializeObject(req));

            IEnumerable<Car> entities = _repository.All().ToList();

            if (req.Mark != null)
                entities = entities.Where(x => x.Mark == req.Mark);

            if (req.Model != null)
                entities = entities.Where(x => x.Model == req.Model);

            if (req.GearBox != null)
                entities = entities.Where(x => x.GearBox == (ECarGearBox)Enum.Parse(typeof(ECarGearBox), req.GearBox));

            if (req.Fuel != null)
                entities = entities.Where(x => x.Fuel == (ECarFuel)Enum.Parse(typeof(ECarFuel), req.Fuel));

            var model = entities?.Select(x => _adapter.Bind(x));

            return Ok(model);
        }


        /// <summary>
        /// Irasomas automobilis i duomenu baze
        /// </summary>
        /// <returns></returns>
        /// <response code = "400">paduodomos informacijos kiekis per didelis</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post(PostCarRequest req)
        {
            if (!Enum.TryParse(typeof(ECarGearBox), req.GearBox, out _))
            {
                var validValues = Enum.GetNames(typeof(ECarGearBox));
                ModelState.AddModelError(nameof(req.GearBox), $"Not valid values. Valid values are: {string.Join(", ", validValues)}");
            }

            if (!Enum.TryParse(typeof(ECarFuel), req.Fuel, out _))
            {
                var validValues = Enum.GetNames(typeof(ECarFuel));
                ModelState.AddModelError(nameof(req.Fuel), $"Not valid values. Valid values are: {string.Join(", ", validValues)}");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }


            var entity = _adapter.Bind(req);
            var id = _repository.Create(entity);

            return Created("PostCar", new { Id = id});


        }









        /// <summary>
        /// Modifikuojamas automobilis duomenu bazeje
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put(PutCarRequest req)
        {

            return NoContent();
        }

        /// <summary>
        /// Trinamas automobilis is duomenu bazes
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {

            return NoContent();
        }
    }
}