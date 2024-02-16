using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizza_Core.Models;
using Pizza_API.Repositories;

namespace Pizza_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class PizzaController : ControllerBase
    {
        private readonly IRepository<Pizza> _pizzaRepository;


        private readonly IMapper _mapper;

        public PizzaController(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            IEnumerable<Pizza> pizza = await _pizzaRepository.GetAll();

            return Ok(pizza);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Pizza pizza = await _pizzaRepository.Get(p => p.Id == id);


            if (pizza != null)
                return Ok(new
                {
                    Message = "Pizza found",
                    Pizza = pizza,
                });


            return NotFound(new
            {
                Message = "No pizza has this id"
            });


        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Pizza pizza)
        {

            var pizzaAdded = await _pizzaRepository.Add(pizza);

            if (pizzaAdded != null)
                return CreatedAtAction(nameof(GetById),
                                            new { id = pizza.Id },
                                            new
                                            {
                                                Message = "The pizza was added to the database",
                                                Pizza = pizza
                                            });

            return BadRequest("Oops something went wrong");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Pizza pizza)
        {
            var pizzaFromDb = await _pizzaRepository.Get(p => p.Id == id);

            if (pizzaFromDb != null)
                return NotFound("There's no pizza with this id");

            var pizzaUpdated = await _pizzaRepository.Update(pizza);


            if (pizzaUpdated != null)
                return Ok(new
                {
                    Message = "The pizza was updated properly.",
                    Pizza = pizzaUpdated
                });

            return BadRequest("Oops something went wrong...");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var pizza = await _pizzaRepository.Get(p => p.Id == id);

            if (pizza != null)
            {
                await _pizzaRepository.Delete(id);
                return Ok("The pizza was deleted");
            }

            return BadRequest("Oops something went wrong...");
        }
    }
}
