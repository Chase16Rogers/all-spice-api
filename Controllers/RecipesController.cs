using System.Collections.Generic;
using all_spice.Models;
using all_spice.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace all_spice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _RS;
        private readonly IngredientsService _IS;
    public RecipesController(RecipesService rS, IngredientsService iS)
    {
      _RS = rS;
      _IS = iS;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetAll()
    {
        try
        {
            _IS.GetAll();
            return Ok(_RS.GetAll());
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Recipe> GetOne(int id)
    {
         try
        {
            return Ok(_RS.GetOne(id));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpPost]
    public ActionResult<Recipe> Create([FromBody] Recipe newRecipe)
    {
         try
        {
            return Ok(_RS.Create(newRecipe));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpPut("{id}")]
    public ActionResult<Recipe> Edit(int id, Recipe editRecipe)
    {
         try
        {
            return Ok(_RS.Edit(id, editRecipe));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
         try
        {
            return Ok(_RS.Delete(id));
        }
        catch (Exception err)
        {
            return BadRequest(err.Message);
        }
    }
  }
}