"use strict";
// classes
class Person {
    // Using an accessibility modifier in the constructor
    // arguments is a shortcut to creating a property
    // and assigning its value in the constructor
    constructor(name, username, age) {
        this.username = username;
        this.type = "man";
        this.name = name;
        this.age = age;
    }
    printAge() {
        console.log(this.age);
        this.setType("Old dude");
    }
    setType(type) {
        this.type = type;
    }
}
const person = new Person("Mike", "mcaputo", 40);
console.log(person);
person.printAge();
// person.setType("dude");
// inheritance
class Mike extends Person {
    constructor(username, age) {
        super("Mike", username, age);
        this.age += 1;
    }
}
const mike = new Mike("mcaputo", 40);
// getters & setters
class Plant {
    constructor() {
        this._species = "default";
    }
    get species() {
        return this._species;
    }
    set species(value) {
        if (value.length > 3) {
            this._species = value;
        }
        else {
            this._species = "default";
        }
    }
}
const plant = new Plant();
console.log(plant.species);
plant.species = "AB";
console.log(plant.species);
plant.species = "Green plant";
console.log(plant.species);
// static properties & methods
class Helpers {
    static calcCircumference(diameter) {
        return this.Pi * diameter;
    }
}
Helpers.Pi = 3.1415;
console.log(Helpers.Pi);
console.log(Helpers.calcCircumference(8));
// abstract classes
class Project {
    constructor() {
        this.name = "Default";
        this.budget = 0;
    }
    calcBudget() {
        return this.budget * 2;
    }
}
class ITProject extends Project {
    changeName(name) {
        this.name = name;
    }
}
const newProject = new ITProject();
console.log(newProject);
newProject.changeName("Super IT Project");
console.log(newProject);
// private constructors
class OnlyOne {
    constructor(name) {
        this.name = name;
    }
    static getInstance() {
        if (!OnlyOne.instance) {
            OnlyOne.instance =
                new OnlyOne("The only one");
        }
        return OnlyOne.instance;
    }
}
//let wrong = new OnlyOne("The only one");
let right = OnlyOne.getInstance();
// readonly properties
console.log(right.name);
right.name = "Something else";
class ReadOnly {
    constructor() {
        this._nameLast = "";
        this.nameFirst = "";
    }
    get nameLast() {
        return this._nameLast;
    }
}
