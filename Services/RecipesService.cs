using System;
using System.Collections.Generic;
using all_spice.Models;
using all_spice.Repositories;

namespace all_spice.Services
{
  public class RecipesService
  {
    private readonly RecipeRepository _repo;

    public RecipesService(RecipeRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Recipe> GetAll()
    {
      return _repo.GetAll();
    }

    internal Recipe GetOne(int id)
    {
      Recipe found = _repo.GetOne(id);
      if(found == null)
      {
        throw new Exception("Bad Id");
      }
      return found;
    }

    internal Recipe Create(Recipe newRecipe)
    {
      _repo.Create(newRecipe);
      return newRecipe;
    }


    internal Recipe Edit(int id, Recipe editRecipe)
    {
      Recipe found = _repo.GetOne(id);
      if(found == null)
            {
                throw new Exception("UH OH! BAD ID!");
            }
            found.title = editRecipe.title != null ? editRecipe.title : found.title;
            found.description = editRecipe.description != null ? editRecipe.description : found.description;
            found.imgUrl = editRecipe.imgUrl != null ? editRecipe.imgUrl : found.imgUrl;
            found.steps = editRecipe.steps != null ? editRecipe.steps : found.steps;
            editRecipe.id = id;
            return _repo.Edit(editRecipe);
    }

    internal string Delete(int id)
    {
      Recipe found = GetOne(id);
       if(found == null)
            {
                throw new Exception("UH OH! BAD ID!");
            }
            return _repo.Delete(found.id);
    }
  }
}