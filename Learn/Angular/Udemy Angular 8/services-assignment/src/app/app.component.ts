import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { User } from './user.model';
import { CounterService } from './counter.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent
  implements OnInit {
  users: User[];

  constructor(private usersService: UsersService,
    public counterService: CounterService) {}

  ngOnInit() {
    this.users = this.usersService.users;
  }
}
