import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  evens: number[] = [];
  odds: number[] = [];

  onIntervalReached(incrementData: {
    increment: number
  }) {
    if(incrementData.increment % 2 === 0) {
      this.evens.push(incrementData.increment);
    } else {
      this.odds.push(incrementData.increment);
    }
  }
}
