import {
  Component,
  OnInit,
  EventEmitter,
  Output } from '@angular/core';

@Component({
  selector: 'app-gamecontrol',
  templateUrl: './gamecontrol.component.html',
  styleUrls: ['./gamecontrol.component.css']
})
export class GamecontrolComponent implements OnInit {
  private timerId: any;
  private increment = 0;

  @Output()
  intervalReached = new EventEmitter<{
    increment: number
  }>();

  constructor() { }

  ngOnInit() {
  }

  startGame() {
    this.timerId = setInterval(
      this.onInterval, 1000);
  }

  private onInterval = () => {
    this.increment += 1;
    console.log(this.increment);
    this.intervalReached.emit({
      increment: this.increment
    });
  }

  stopGame() {
    clearInterval(this.timerId);
  }

}
