import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  paraVisible: boolean = false;
  clickCount: number = 0;
  clicks = [];

  displayDetails() {
    this.paraVisible = !this.paraVisible;
    /* this.clickCount += 1;
    this.clicks.push(this.clickCount); */
    this.clicks.push(new Date());
  }
}
