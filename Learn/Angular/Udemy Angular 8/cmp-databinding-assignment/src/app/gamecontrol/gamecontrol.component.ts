import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gamecontrol',
  templateUrl: './gamecontrol.component.html',
  styleUrls: ['./gamecontrol.component.css']
})
export class GamecontrolComponent implements OnInit {
  private timerId: any;
  private increment: number;

  constructor() { }

  ngOnInit() {
  }

  startGame() {
    this.timerId = setInterval(() =>
      this.increment += 1, 1000);
  }

  stopGame() {
    clearInterval(this.timerId);
  }

}
