SELECT * FROM Ingredient ORDER BY Name;

INSERT INTO Ingredient (Name) VALUES ('Pickles');

UPDATE Ingredient SET Name = 'Toast bread' WHERE Id = 4;

DELETE FROM Ingredient WHERE Id = 5;

SELECT Recipe.Name, Recipe.Description, Ingredient.Name, RecipeIngredient.Amount, RecipeIngredient.Unit FROM Recipe
JOIN RecipeIngredient ON (RecipeIngredient.RecipeId = Recipe.Id)
JOIN Ingredient ON (Ingredient.Id = RecipeIngredient.IngredientId);