using System;
using System.Collections.Generic;
using all_spice.Models;
using all_spice.Repositories;

namespace all_spice.Services
{
  public class IngredientsService
  {
private readonly IngredientRepository _repo;

    public IngredientsService(IngredientRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Ingredient> GetAll()
    {
      return _repo.GetAll();
    }
    internal Ingredient Create(Ingredient newIng)
    {
      return _repo.Create(newIng);
    }

    internal Ingredient Edit(int id, Ingredient editIng)
    {
      Ingredient found = _repo.GetOne(id);
      if (found == null)
      {
        throw new Exception("Bad Id");
      }
      return _repo.Edit(editIng);
    }

    internal string Delete(int id)
    {
      throw new NotImplementedException();
    }

  }
}