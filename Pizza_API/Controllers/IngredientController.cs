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

    public class IngredientController : ControllerBase
    {
        private readonly IRepository<Ingredient> _repository;
        private readonly IMapper _mapper;

        public IngredientController(IRepository<Ingredient> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            IEnumerable<Ingredient> ingredients = await _repository.GetAll();


            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ingredient = await _repository.Get(p => p.Id == id);

            if (ingredient == null)
                return NotFound(new
                {
                    Message = "No ingredient has this id"
                });


            return Ok(new
            {
                Message = "ingredient found",
                Ingredient = ingredient
            });
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Ingredient ingredient)
        {
            var ingredientAdded = await _repository.Add(ingredient);

            if (ingredientAdded != null)
                return CreatedAtAction(nameof(GetById),
                                            new { id = ingredient.Id },
                                            new
                                            {
                                                Message = "The pizza was added to the database",
                                                Ingredient = ingredient
                                            });
            return BadRequest("Oops something went wrong");
        }


    }
}
