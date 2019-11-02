"use strict";
// exercise 1
class Car {
    constructor(name) {
        this.name = name;
        this.acceleration = 0;
    }
    honk() {
        console.log("Honk");
    }
    accelerate(speed) {
        this.acceleration += speed;
    }
}
const car2 = new Car("BMW");
car2.honk();
console.log("Acceleration: " + car2.acceleration);
car2.accelerate(10);
console.log("Acceleration: " + car2.acceleration);
// exercise 2
class BaseObject {
    constructor(width = 0, length = 0) {
        this.width = width;
        this.length = length;
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
const rectangle = new Rectangle();
console.log("Size: " + rectangle.calcSize());
// exercise 3
class Person2 {
    constructor() {
        this._firstName = "";
        this.enumerable = true;
        this.configurable = true;
    }
    get firstName() {
        return this._firstName;
    }
    set firstName(value) {
        if (value.length > 3) {
            this._firstName = value;
        }
        else {
            this._firstName = "";
        }
    }
}
const person2 = new Person2();
console.log("First Name: " + person2.firstName);
person2.firstName = "Mi";
console.log("First Name: " + person2.firstName);
person2.firstName = "Mike";
console.log("First Name: " + person2.firstName);
