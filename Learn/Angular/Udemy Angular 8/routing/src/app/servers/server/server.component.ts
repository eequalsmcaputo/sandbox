import { Component, OnInit, Input } from '@angular/core';

import { ServersService } from '../servers.service';
import { ActivatedRoute, Params, Router, Data } from '@angular/router';
import { Server } from '../server.interface';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit {
  @Input()
  server: Server;

  constructor(private serversService: ServersService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.route.data
      .subscribe(
        (data: Data) => {
          this.server = data['server'];
        }
      );
    /*const id: number = +this.route.snapshot
      .params['id'];
    this.server = this.serversService.getServer(id);
    this.route.params.subscribe(
      (params: Params) => {
        this.server = this.serversService.getServer(
          +params['id']);
      }
    );*/
  }

  onEdit() {
    this.router.navigate(['edit'],
      {relativeTo: this.route,
        queryParamsHandling: 'preserve'});
  }
}
