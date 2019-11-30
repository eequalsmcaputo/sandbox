import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-laptops',
  templateUrl: './laptops.component.html',
  styleUrls: ['./laptops.component.css']
})
export class LaptopsComponent implements OnInit {
  @ViewChild('laptopname', {static: true})
  laptopName: ElementRef;

  constructor(private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
  }

  onSearch() {
    this.router.navigate(['display'],
      {
        relativeTo: this.route,
        queryParams: {id: this.laptopName
          .nativeElement.value}
      }
    );
  }
}
