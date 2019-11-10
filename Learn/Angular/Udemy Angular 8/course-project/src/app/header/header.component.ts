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
  menuFired = new EventEmitter<{
    source: EventSource
  }>();

  onClickRecipes = (event: Event) => {
    event.preventDefault();
    this.menuFired.emit({
      source: EventSource.Recipes});
  }

  onClickShoppingList = (event: Event) => {
    event.preventDefault();
    this.menuFired.emit({
      source: EventSource.ShoppingList});
  }
}
