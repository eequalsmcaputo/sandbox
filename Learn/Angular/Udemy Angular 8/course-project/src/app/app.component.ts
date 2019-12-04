import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'course-project';

  /*onMenuFired(eventData: EventSource) {
    this.currentSelection = eventData;
  }

  isRecipesSelected() {
    return (this.currentSelection ===
      EventSource.Recipes);
  }

  isShoppingListSelected() {
    return (this.currentSelection ===
      EventSource.ShoppingList);
  }*/
}
