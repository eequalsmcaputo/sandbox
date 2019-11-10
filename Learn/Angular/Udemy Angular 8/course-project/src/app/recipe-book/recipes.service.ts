import { Recipe } from './recipe.model';
import { EventEmitter } from '@angular/core';

export class RecipesService {
  readonly recipeSelected = new EventEmitter<Recipe>();
  private recipes: Recipe[] = [];

  addRecipe(name: string, description: string) {
    this.recipes.push(new Recipe(name, description,
      'https://assets.bonappetit.com/photos/5d7296eec4af4d0008ad1263/3:2/w_1028,c_limit/Basically-Gojuchang-Chicken-Recipe-Wide.jpg'));
  }

  constructor() {
    this.addRecipe('Test Recipe', 'Test Recipe');
    this.addRecipe('Another Test Recipe',
      'Another Test Recipe');
  }

  getRecipesCopy() {
    return this.recipes.slice();
  }
}
