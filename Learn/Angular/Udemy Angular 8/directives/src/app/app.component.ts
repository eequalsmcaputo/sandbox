import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // numbers = [1, 2, 3, 4, 5, 6];
  numbers: number[];
  onlyOdd = false;
  value: number = 5;

  onClickOnlyOdd() {
    this.onlyOdd = !this.onlyOdd;
    if (this.onlyOdd) {
      this.numbers = [1, 3, 5];
    } else {
      this.numbers = [1, 2, 3, 4, 5, 6];
    }
  }
}
