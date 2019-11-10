import { UsersService } from './users.service';
import { OnInit, Injectable } from '@angular/core';
import { UserStatus } from './user.model';

@Injectable()
export class CounterService {
  activeToInactive: number = 0;
  inactiveToActive: number = 0;

  constructor(private usersService: UsersService) {
    this.usersService.statusToggled.subscribe(
      (toggle: {
        fromStatus: UserStatus,
        toStatus: UserStatus
      }) => {
        if (toggle.fromStatus === UserStatus.active) {
          this.activeToInactive += 1;
          console.log('Active to Inactive: ' +
            this.activeToInactive);
        } else {
          this.inactiveToActive += 1;
          console.log('Inactive to Active: ' +
            this.inactiveToActive);
        }
      }
    );
  }
}
