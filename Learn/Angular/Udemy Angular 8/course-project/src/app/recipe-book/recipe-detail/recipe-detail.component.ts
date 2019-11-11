import { Component, Input } from '@angular/core';
import { Recipe } from '../recipe.model';
import { RecipesService } from '../recipes.service';
import { Ingredient } from 'src/app/shared/ingredient.model';
import { ShoppingListService } from 'src/app/shopping-list/shopping-list.service';

@Component({
    selector: 'app-recipe-detail',
    templateUrl: './recipe-detail.component.html'
})
export class RecipeDetailComponent {
  @Input()
  recipe: Recipe;

  constructor(private recipesService: RecipesService,
    private shoppingListService: ShoppingListService) {}

  addToShoppingList() {
    this.recipe.ingredients.forEach((ing: Ingredient) => {
      this.shoppingListService.addIngredient(
        ing.name, ing.quantity);
    });
  }
}
