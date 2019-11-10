import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Recipe } from '../../recipe.model';

@Component({
    selector: 'app-recipe-item',
    templateUrl: './recipe-item.component.html'
})
export class RecipeItemComponent {
  @Input()
  recipe: Recipe;

  @Output()
  clicked = new EventEmitter<void>();

  onClicked = () => {
    this.clicked.emit();
  }
}
