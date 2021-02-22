using System.Collections.Generic;
using all_spice.Models;
using all_spice.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace all_spice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _IS;

    public IngredientsController(IngredientsService iS, RecipesService rs)
    {
      _IS = iS;
    }
  [HttpPost]
  public ActionResult<Ingredient> Create([FromBody] Ingredient newIng)
  {
        try
      {
          return Ok(_IS.Create(newIng));
      }
      catch (Exception err)
      {
          return BadRequest(err.Message);
      }
  }
  [HttpPut("{id}")]
  public ActionResult<Ingredient> Edit(int id, [FromBody] Ingredient editIng)
  {
      try
      {
          return Ok(_IS.Edit(id, editIng));
      }
      catch (Exception err)
      {
          return BadRequest(err.Message);
      }
  }
  [HttpDelete("{id}")]
  public string Delete(int id)
  {
      try
      {
          return Ok(_IS.Delete(id));
      }
      catch (Exception err)
      {
          return BadRequest(err.Message);
      }
  }
}
}