import { Output,
  EventEmitter,
  OnInit } from '@angular/core';
import { UserStatus, User } from './user.model';

export class UsersService {
  users: User[] = [
    new User('Joe Blow', UserStatus.active),
    new User('Jim Bob', UserStatus.active),
    new User('Mike Caputo', UserStatus.inactive),
    new User('John Thomas', UserStatus.inactive)
  ];
  @Output()
  statusToggled = new EventEmitter<{
    fromStatus: UserStatus,
    toStatus: UserStatus
  }>();

  addUser(name: string, status: UserStatus) {
    // tslint:disable-next-line: object-literal-shorthand
    this.users.push(new User(name, status));
  }

  setUserStatus(id: number, status: UserStatus) {
    this.users[id].status = status;
  }

  toggleUserStatus(id: number) {
    const current: UserStatus = this.users[id].status;
    const opposite = this.getOppositeStatus(current);
    this.setUserStatus(id, opposite);
    this.statusToggled.emit({fromStatus: current,
      toStatus: opposite});
  }

  private getOppositeStatus(status: UserStatus) {
    if (status === UserStatus.active) {
      return UserStatus.inactive;
    } else {
      return UserStatus.active;
    }
  }

  getUserId(name: string) {
    for (let i: number; i < this.users.length; i++) {
      if (this.users[i].name === name) {
        return i;
      }
    }
    return -1;
  }
}
