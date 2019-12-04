import { Component, OnInit } from '@angular/core';
import { Recipe } from '../recipe.model';
import { RecipesService } from '../recipes.service';
import { Ingredient } from 'src/app/shared/ingredient.model';
import { ShoppingListService } from 'src/app/shopping-list/shopping-list.service';
import { ActivatedRoute, Router, Data, Params } from '@angular/router';

@Component({
    selector: 'app-recipe-detail',
    templateUrl: './recipe-detail.component.html'
})
export class RecipeDetailComponent implements OnInit {
  recipe: Recipe;

  constructor(
    private recipesService: RecipesService,
    private shoppingListService: ShoppingListService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.params.subscribe(
      (params: Params) => {
        this.recipe = this.recipesService.find(
          params.name
        );
      }
    );
  }

  editRecipe() {
    this.router.navigate(
      ['edit'],
      {
        relativeTo: this.route,
        queryParamsHandling: 'preserve'
      }
    );
  }

  addToShoppingList() {
    this.recipe.ingredients.forEach((ing: Ingredient) => {
      this.shoppingListService.addIngredient(
        ing.name, ing.quantity);
    });
  }
}
