import { Component, Output, EventEmitter } from '@angular/core';
import { Recipe } from '../recipe.model';

@Component({
    selector: 'app-recipe-list',
    templateUrl: './recipe-list.component.html'
})
export class RecipeListComponent {
  recipes: Recipe[] = [];

  @Output()
  itemClicked = new EventEmitter<Recipe>();

  addRecipe(name: string, description: string) {
    this.recipes.push(new Recipe(name, description,
      'https://assets.bonappetit.com/photos/5d7296eec4af4d0008ad1263/3:2/w_1028,c_limit/Basically-Gojuchang-Chicken-Recipe-Wide.jpg'));
  }

  constructor() {
    this.addRecipe('Test Recipe', 'Test Recipe');
    this.addRecipe('Another Test Recipe',
      'Another Test Recipe');
  }

  onItemClicked = (recipe: Recipe) => {
    this.itemClicked.emit(recipe);
  }
}
