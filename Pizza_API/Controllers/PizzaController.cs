using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_API.DTOs;
using Pizza_API.Models;
using Pizza_API.Repositories;

namespace Pizza_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class PizzaController : ControllerBase
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IRepository<PizzaIngredient> _pizzaIngredientRepository;

        private readonly IMapper _mapper;

        public PizzaController(IRepository<Pizza> pizzaRepository, IRepository<Ingredient> ingredientRepository, IRepository<PizzaIngredient> joinRepository, IMapper mapper)
        {
            _pizzaRepository = pizzaRepository;
            _ingredientRepository = ingredientRepository;
            _pizzaIngredientRepository = joinRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Getall([FromQuery] string? query)
        {
            IEnumerable<Pizza> pizza = await _pizzaRepository.GetAll();
            IEnumerable<PizzaDTO> PizzaDTO = _mapper.Map<IEnumerable<PizzaDTO>>(pizza)!;

            return Ok(PizzaDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Pizza pizza = await _pizzaRepository.Get(p => p.Id == id);

            PizzaDTO pizzaDTO = _mapper.Map<PizzaDTO>(pizza)!;

            IEnumerable<PizzaIngredient> pizzasIngredients = await _pizzaIngredientRepository.GetAll(pi => pi.PizzaId == id);


            foreach (var ingredientOnPizza in pizzasIngredients)
            {
                var Ingredient = await _ingredientRepository.Get(i => i.Id == ingredientOnPizza.IngredientId);
                pizzaDTO.Ingredients.Add(Ingredient);
            }

            if (pizza == null)
                return NotFound(new
                {
                    Message = "No pizza has this id"
                });


            return Ok(new
            {
                Message = "Pizza found",
                Pizza = pizzaDTO,
            });


        }

        [HttpPost("with_DTO")]
        public async Task<IActionResult> Add([FromForm] PizzaDTO pizzaDTO)
        {
            var pizza = _mapper.Map<Pizza>(pizzaDTO)!;

            var pizzaAdded = await _pizzaRepository.Add(pizza);

            var pizzaAddedDTO = _mapper.Map<PizzaDTO>(pizzaAdded)!;

            if (pizzaAdded != null)
                return CreatedAtAction(nameof(GetById),
                                            new { id = pizzaDTO.Id },
                                            new
                                            {
                                                Message = "The pizza was added to the database",
                                                Pizza = pizzaAddedDTO
                                            });

            return BadRequest("Oops something went wrong");
        }

        [HttpPost]
        public async Task<IActionResult> AddWithoutDTO([FromForm] Pizza pizza)
        {
            await _pizzaRepository.Add(pizza);

            if (pizza != null)
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PizzaDTO pizzaDTO)
        {
            var pizzaFromDb = await _pizzaRepository.Get(p => p.Id == id);

            if (pizzaFromDb != null)
                return NotFound("There's no pizza with this id");

            pizzaDTO.Id = id;

            var pizza = _mapper.Map<Pizza>(pizzaDTO)!;

            var pizzaUpdated = await _pizzaRepository.Update(pizza);

            var pizzaUpdatedDTO = _mapper.Map<PizzaDTO>(pizzaUpdated);

            if (pizzaUpdated != null)
                return Ok(new
                {
                    Message = "The pizza was updated properly.",
                    Pizza = pizzaUpdatedDTO
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
