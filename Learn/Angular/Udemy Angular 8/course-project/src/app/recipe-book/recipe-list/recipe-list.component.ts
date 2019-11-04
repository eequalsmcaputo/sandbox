import { Component } from '@angular/core';
import { Recipe } from '../recipe.model';

@Component({
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html'
})
export class RecipeListComponent {
  recipes: Recipe[] = [];

  addRecipe() {
    this.recipes.push(new Recipe('Test Recipe',
      'Test Recipe',
      'https://assets.bonappetit.com/photos/5d7296eec4af4d0008ad1263/3:2/w_1028,c_limit/Basically-Gojuchang-Chicken-Recipe-Wide.jpg'));
  }

  constructor() {
    this.addRecipe();
  }
}
