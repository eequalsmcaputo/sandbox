"use strict";
function greet3(person) {
    console.log("Hello, " + person.firstName);
}
const person3 = {
    firstName: "Mike",
    hobbies: ["Cooking", "Sports"],
    greet(lastName) {
        console.log("Hi, I'm " + this.firstName +
            " " + lastName);
    }
};
greet3(person3);
person3.greet("Caputo");
class Person4 {
    constructor() {
        this.firstName = "";
        this.lastName = "";
    }
    greet(lastName) {
        console.log("Hi, I'm " + this.firstName +
            " " + lastName);
    }
}
const mike2 = new Person4();
mike2.firstName = "Mike";
mike2.lastName = "Caputo";
greet3(mike2);
mike2.greet(mike2.lastName);
let doubleFunc = function (value1, value2) {
    return (value1 + value2) * 2;
};
console.log(doubleFunc(10, 20));
const oldPerson = {
    age: 40,
    firstName: "Mike",
    greet(lastName) {
        console.log("Hello. I'm " + this.firstName +
            " " + lastName);
    }
};
console.log(oldPerson);
