import {
  Component,
  Output,
  EventEmitter } from '@angular/core';

export enum EventSource {
    Recipes,
    ShoppingList
  }

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})
export class HeaderComponent {
  collapsed = true;

  @Output()
  menuFired = new EventEmitter<EventSource>();

  onClickRecipes = (event: Event) => {
    event.preventDefault();
    this.menuFired.emit(EventSource.Recipes);
  }

  onClickShoppingList = (event: Event) => {
    event.preventDefault();
    this.menuFired.emit(EventSource.ShoppingList);
  }
}
