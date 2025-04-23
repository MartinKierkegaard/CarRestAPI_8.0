using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCar.Model;

namespace WebApiCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarRepo repo;
        public CarsController(CarRepo carRepo)
        {
            repo = carRepo;
        }
        /// <summary>
        /// Method for get all the cars from the static list
        /// </summary>
        /// <returns>List of cars</returns>
        // GET: api/Cars
        [HttpGet]
        public IActionResult Get()
        {
            List<Car> cars = repo.GetAll();

            if (cars.Count != 0)
            {
                return Ok(cars);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Car c = repo.GetById(id);

            if (c != null)
            {
                return Ok(c);
            }
            else
            {
                return NotFound(c);
            }
        }

        /// <summary>
        /// Post a new car to the static list
        /// </summary>
        /// <param name="value"></param>
        // POST: api/Cars
        [HttpPost]
        public IActionResult Post([FromBody] CarDTO value)
        {
            Car c = repo.Add(ModelConverter.CarConvert(value));

            if (c != null)
            {
                return Created("api/" + c.Id, c);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/Cars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car c = repo.Remove(id);

            if (c != null)
            {
                return Ok(c);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
