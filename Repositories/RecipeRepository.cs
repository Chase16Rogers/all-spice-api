using System;
using System.Collections.Generic;
using System.Data;
using all_spice.Models;
using Dapper;

namespace all_spice.Repositories
{
  public class RecipeRepository
  {
      public readonly IDbConnection _db;

    public RecipeRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Recipe> GetAll()
    {
      string sql = "SELECT * FROM recipes;";
      return _db.Query<Recipe>(sql);
    }

    internal Recipe GetOne(int id)
    {
      string sql = "SELECT * FROM recipes WHERE id = @id";
      return _db.QueryFirstOrDefault<Recipe>(sql, new { id });
    }

    internal Recipe Create(Recipe newRecipe)
    {
      string sql = @"
      INSERT INTO recipes (title, description, imgUrl, steps) VALUES (@title, @description, @imgUrl, @steps);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newRecipe);
      newRecipe.id = id;
      return newRecipe;
    }

    internal Recipe Edit(Recipe editRecipe)
    {
      string sql = @"
      UPDATE recipes SET title = @title, description = @description, imgUrl = @imgUrl, steps = @steps
      WHERE id = @id;";
      _db.Execute(sql, editRecipe);
      return editRecipe;
    }

    internal string Delete(int id)
    {
      string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
      return "Gone Boss";
    }
  }
}