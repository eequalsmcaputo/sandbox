import { Component, OnInit } from '@angular/core';
import { Recipe } from './recipe.model';
import { RecipesService } from './recipes.service';

@Component({
  selector: 'app-recipe-book',
  templateUrl: './recipe-book.component.html',
  styleUrls: ['./recipe-book.component.css'],
  providers: [RecipesService]
})
export class RecipeBookComponent implements OnInit {
  selectedRecipe: Recipe;

  constructor(private recipesService: RecipesService) {}

  ngOnInit() {
    this.recipesService.recipeSelected.subscribe(
      (recipe: Recipe) => {
        this.selectedRecipe = recipe;
      }
    );
  }
}
