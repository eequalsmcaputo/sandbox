import { Component, EventEmitter, Output } from '@angular/core';
import { LoggingService } from '../logging.service';
import { AccountsService } from '../accounts.service';
import { stringify } from 'querystring';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.css']
  // Leave out provider in order
  // to ensure that the same instance is used all the way
  // down the component tree starting from app
})
export class NewAccountComponent {
  constructor(private loggingService: LoggingService,
    private accountsService: AccountsService) {
      this.accountsService.statusUpdated.subscribe(
        (statusUpdate: {name: string, status: string}) =>
        alert('New status for account ' +
          statusUpdate.name + ': ' + statusUpdate.status
        )
      );
    }

  onCreateAccount(accountName: string,
    accountStatus: string) {
    this.accountsService.addAccount(
      accountName, accountStatus
    );
  }
}
