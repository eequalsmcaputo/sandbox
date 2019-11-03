import { Component, OnInit } from '@angular/core';

@Component({
  // selector: '.app-servers' by class
  // selector: [app-servers] by attribute
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent implements OnInit {
  allowNewServer: boolean = false;
  serverCreationStatus: string = 'No servers created';
  serverName: string = 'TestServer';
  username: string = '';

  constructor() {
    setTimeout(() => {
      this.allowNewServer = true;
    }, 2000);
  }

  ngOnInit() {
  }

  onCreateServer() {
    this.serverCreationStatus = 'Server ' +
      this.serverName + ' created';
  }

  onUpdateServerName(event: any) {
    this.serverName = (<HTMLInputElement> event.target).value;
  }

  resetUsername(event: any) {
    this.username = '';
  }

}
