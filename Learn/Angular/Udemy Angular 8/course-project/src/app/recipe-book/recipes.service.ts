import { Recipe } from './recipe.model';
import { EventEmitter } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';

export class RecipesService {
  readonly recipeSelected = new EventEmitter<Recipe>();
  private recipes: Recipe[] = [];

  addRecipe(name: string,
    description: string,
    imagePath: string,
    ingredients: Ingredient[]) {
    this.recipes.push(new Recipe(name, description,
      imagePath,
      ingredients));
  }

  constructor() {
    this.addRecipe('Schnitzel', 'Tasty schnitzel',
      'assets/images/schnitzel.png',
      [
        new Ingredient('Meat', 1),
        new Ingredient('Lemon', 1)
      ]);
    this.addRecipe('Burger',
      'Big fat burger',
      'assets/images/burger.png',
      [
        new Ingredient('Bun', 1),
        new Ingredient('Meat', 1),
        new Ingredient('French Fries', 20)
      ]);
  }

  getRecipesCopy() {
    return this.recipes.slice();
  }

  find(recipeName: string) {
    return this.recipes.find(
      (r) => {
        return r.name === recipeName;
      }
    );
  }
}
