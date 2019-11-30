import { Component, OnInit, Input } from '@angular/core';
import { LaptopsService } from '../laptops.service';
import { ActivatedRoute, Router, Data } from '@angular/router';
import { Laptop } from './laptop.model';

@Component({
  selector: 'app-laptop',
  templateUrl: './laptop.component.html',
  styleUrls: ['./laptop.component.css']
})
export class LaptopComponent implements OnInit {
  @Input()
  laptop: Laptop;

  constructor(private laptopsService: LaptopsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(
      (data: Data) => {
        this.laptop = data['laptop'];
      }
    );
  }

}
