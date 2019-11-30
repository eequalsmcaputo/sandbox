import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { LaptopsService } from '../laptops.service';
import { Observable } from 'rxjs';
import { Laptop } from './laptop.model';

@Injectable()
export class LaptopResolver implements Resolve<Laptop> {

  constructor(private laptopsService: LaptopsService) {

  }

  resolve(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<Laptop> |
      Promise<Laptop> | Laptop {
    return this.laptopsService.find(
      route.queryParams['id']);
  }
}
