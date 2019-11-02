// exercise 1
class Car {
    public constructor(public name: string) {

    }

    public acceleration: number = 0;

    honk() {
        console.log("Honk");
    }

    accelerate(speed: number) {
        this.acceleration += speed;
    }
}

const car2: Car = new Car("BMW");
car2.honk();
console.log("Acceleration: " + car2.acceleration);
car2.accelerate(10);
console.log("Acceleration: " + car2.acceleration);


// exercise 2
class BaseObject {
    constructor(public width: number = 0, 
        public length: number = 0) {
        
    }
}

class Rectangle extends BaseObject {
    constructor() {
        super();
        this.width = 5;
        this.length = 2;
    }

    calcSize() {
        return this.width * this.length;
    }
}

const rectangle: Rectangle = new Rectangle();
console.log("Size: " + rectangle.calcSize());


// exercise 3
class Person2 {
    private _firstName: string = "";

    get firstName(): string {
        return this._firstName;
    }

    set firstName(value: string) {
        if(value.length > 3) {
            this._firstName = value;
        } else {
            this._firstName = "";
        }
    }

    public enumerable: boolean = true;
    public configurable: boolean = true;
}

const person2: Person2 = new Person2();
console.log("First Name: " + person2.firstName);
person2.firstName = "Mi";
console.log("First Name: " + person2.firstName);
person2.firstName = "Mike";
console.log("First Name: " + person2.firstName);
