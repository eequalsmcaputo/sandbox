import { Component, Output, EventEmitter } from '@angular/core';
import { Ingredient } from 'src/app/shared/ingredient.model';

@Component({
    selector: 'app-list-edit',
    templateUrl: './list-edit.component.html'
})
export class ListEditComponent {
  @Output()
  ingredientAdded = new EventEmitter<Ingredient>();

  addIngredient(name: string, qty: number) {
    const ingredient = new Ingredient(name, qty);
    this.ingredientAdded.emit(ingredient);
  }
}

