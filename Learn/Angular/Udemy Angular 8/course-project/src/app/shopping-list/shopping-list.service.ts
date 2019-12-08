import { Ingredient } from '../shared/ingredient.model';
import { Output } from '@angular/core';
import { Subject } from 'rxjs';
export class ShoppingListService {
  @Output()
  ingredientsChanged =
    new Subject<Ingredient[]>();

  private readonly ingredients: Ingredient[] = [];

  getIngredients() {
    return this.ingredients.slice();
  }

  addIngredient(name: string, qty: number) {
    const ingredient: Ingredient =
      new Ingredient(name, qty);
    this.ingredients.push(ingredient);
    this.ingredientsChanged.next(this.getIngredients());
  }
}
