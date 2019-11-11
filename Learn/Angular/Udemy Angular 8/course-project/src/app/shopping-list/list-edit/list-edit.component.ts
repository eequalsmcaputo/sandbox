import { Component } from '@angular/core';
import { ShoppingListService } from '../shopping-list.service';

@Component({
    selector: 'app-list-edit',
    templateUrl: './list-edit.component.html'
})
export class ListEditComponent {
  constructor(public readonly shoppingListService:
    ShoppingListService) {
  }

  addIngredient(name: string, qty: number) {
    this.shoppingListService.addIngredient(name, qty);
  }
}
