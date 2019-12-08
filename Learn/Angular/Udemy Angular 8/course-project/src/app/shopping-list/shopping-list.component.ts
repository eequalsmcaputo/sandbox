import { Component, OnDestroy } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from './shopping-list.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css'],
  providers: []
})
export class ShoppingListComponent
  implements OnDestroy {
  ingredients: Ingredient[];
  private ingChangedSub: Subscription;

  constructor(
    private readonly shoppingListService:
      ShoppingListService) {

    this.ingredients = this
      .shoppingListService
      .getIngredients();
    this.ingChangedSub = this
      .shoppingListService.ingredientsChanged
      .subscribe(
        (ingredients: Ingredient[]) => {
        this.ingredients = ingredients;
      });

  }

  ngOnDestroy(): void {
    this.ingChangedSub.unsubscribe();
  }
}
