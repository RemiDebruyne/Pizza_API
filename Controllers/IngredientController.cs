using AutoMapper;
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

            IEnumerable<IngredientDTO> ingredientDTO = _mapper.Map<IEnumerable<IngredientDTO>>(ingredients);

            return Ok(ingredientDTO);
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

            IngredientDTO ingredientDTO = _mapper.Map<IngredientDTO>(ingredient)!;

            return Ok(new
            {
                Message = "ingredient found",
                Ingredient = ingredientDTO
            });
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromForm] IngredientDTO ingredientDTO)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDTO);
            var ingredientAdded = await _repository.Add(ingredient);

            var IngredientAddedDTO = _mapper.Map<IngredientDTO>(ingredientAdded);
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
