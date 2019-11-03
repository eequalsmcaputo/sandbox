import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';

@Component({
  // selector: '.app-servers' by class
  // selector: [app-servers] by attribute
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class ServersComponent implements OnInit {
  allowNewServer: boolean = false;
  serverCreationStatus: string = 'No servers created';
  serverName: string = 'TestServer';
  username: string = '';
  serverCreated: boolean = false;
  servers = ['TestServer', 'TestServer2'];

  constructor() {
    setTimeout(() => {
      this.allowNewServer = true;
    }, 2000);
  }

  ngOnInit() {
  }

  onCreateServer() {
    this.serverCreated = true;
    this.servers.push(this.serverName);
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
