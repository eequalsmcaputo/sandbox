import { Component } from '@angular/core';
import { EventSource } from './header/header.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'course-project';
  currentSelection: EventSource = EventSource.Recipes;

  onMenuFired(eventData: EventSource) {
    console.log(eventData);
    this.currentSelection = eventData;
  }

  isRecipesSelected() {
    return (this.currentSelection ===
      EventSource.Recipes);
  }

  isShoppingListSelected() {
    return (this.currentSelection ===
      EventSource.ShoppingList);
  }
}
