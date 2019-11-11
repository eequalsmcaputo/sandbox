import { Component } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from './shopping-list.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css'],
  providers: []
})
export class ShoppingListComponent {
  ingredients: Ingredient[];
  constructor(private readonly shoppingListService:
    ShoppingListService) {
    this.ingredients = this.shoppingListService
      .getIngredients();
    this.shoppingListService.ingredientsChanged
      .subscribe(
        (ingredients: Ingredient[]) => {
        this.ingredients = ingredients;
      });
  }
}
