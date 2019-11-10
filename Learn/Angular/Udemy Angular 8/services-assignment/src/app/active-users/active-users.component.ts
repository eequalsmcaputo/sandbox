import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UsersService } from '../users.service';
import { User } from '../user.model';

@Component({
  selector: 'app-active-users',
  templateUrl: './active-users.component.html',
  styleUrls: ['./active-users.component.css']
})
export class ActiveUsersComponent {
  @Input() users: User[];

  constructor(private usersService: UsersService) {}

  onSetToActive(id: number) {
    this.usersService.toggleUserStatus(id);
  }
}
