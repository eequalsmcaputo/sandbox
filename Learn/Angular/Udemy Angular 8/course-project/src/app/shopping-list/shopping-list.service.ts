import { Ingredient } from '../shared/ingredient.model';
import { Output, EventEmitter } from '@angular/core';

export class ShoppingListService {
  @Output()
  ingredientsChanged = new EventEmitter<Ingredient[]>();

  private readonly ingredients: Ingredient[] = [];

  getIngredients() {
    return this.ingredients.slice();
  }

  addIngredient(name: string, qty: number) {
    const ingredient: Ingredient =
      new Ingredient(name, qty);
    this.ingredients.push(ingredient);
    this.ingredientsChanged.emit(this.getIngredients());
  }
}
