// classes
class Person {
    name: string;
    private type: string = "man";
    protected age: number;

    // Using an accessibility modifier in the constructor
    // arguments is a shortcut to creating a property
    // and assigning its value in the constructor
    constructor(name: string, public username: string,
        age: number) {
        this.name = name;
        this.age = age;
    }

    printAge() {
        console.log(this.age);
        this.setType("Old dude");
    }

    private setType(type: string) {
        this.type = type;
    }
}

const person = new Person("Mike", "mcaputo", 40);
console.log(person);
person.printAge();
// person.setType("dude");


// inheritance
class Mike extends Person {
    constructor(username: string, age: number) {
        super("Mike", username, age);
        this.age += 1;
    }
}

const mike = new Mike("mcaputo", 40);


// getters & setters
class Plant {
    private _species: string = "default";

    get species() {
        return this._species;
    }

    set species(value: string) {
        if(value.length > 3) {
            this._species = value;
        } else {
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
    static Pi: number = 3.1415;

    static calcCircumference(diameter: number): number {
        return this.Pi * diameter;
    }
}
console.log(Helpers.Pi);
console.log(Helpers.calcCircumference(8));


// abstract classes
abstract class Project {
    name: string = "Default";
    budget: number = 0;

    abstract changeName(name: string) : void;

    calcBudget() {
        return this.budget * 2;
    }
}

class ITProject extends Project {
    changeName(name: string) : void {
        this.name = name;
    }
}

const newProject = new ITProject();
console.log(newProject);
newProject.changeName("Super IT Project");
console.log(newProject);


// private constructors
class OnlyOne {
    private static instance: OnlyOne;
    private constructor(public name: string) {}

    static getInstance(): OnlyOne {
        if(!OnlyOne.instance) {
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
    private _nameLast = "";
    public readonly nameFirst: string = "";

    get nameLast(): string {
        return this._nameLast;
    }
}
