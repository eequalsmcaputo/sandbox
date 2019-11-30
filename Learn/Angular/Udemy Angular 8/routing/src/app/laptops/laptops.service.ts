import { Laptop } from './laptop/laptop.model';

export class LaptopsService {
  private laptops = [
    new Laptop('mike-laptop', '127.0.0.1'),
    new Laptop('heather-laptop', '999.9.9.9'),
    new Laptop('stephanie-laptop', '888.8.8.8')
  ];

  allLaptops() {
    return this.laptops;
  }

  find(id: string) {
    const laptop: Laptop = this.laptops.find(
      (l) => {
        return l.id === id;
      }
    );
    return laptop;
  }
}
