interface NamedPerson {
    firstName: string;

    // optional
    age?: number;

    // if property names are unknown
    [propName: string]: any;

    greet(lastName: string): void;
}

function greet3(person: NamedPerson) {
    console.log("Hello, " + person.firstName);
}

const person3: NamedPerson = {
    firstName: "Mike",
    hobbies: ["Cooking", "Sports"],
    greet(lastName: string) {
        console.log("Hi, I'm " + this.firstName +
            " " + lastName);
    }
}

greet3(person3);
person3.greet("Caputo");

class Person4 implements NamedPerson {
    firstName: string = "";
    lastName: string = "";

    greet(lastName: string): void {
        console.log("Hi, I'm " + this.firstName +
            " " + lastName);
    }
}

const mike2 = new Person4();
mike2.firstName = "Mike";
mike2.lastName = "Caputo";
greet3(mike2);
mike2.greet(mike2.lastName);



// Function types
interface DoubleValueFunc {
    (number1: number, number2: number): number;
}

let doubleFunc: DoubleValueFunc = function(
    value1: number, value2: number): number {
        return (value1 + value2) * 2;
};

console.log(doubleFunc(10, 20));



// Interface inheritance
interface AgedPerson extends NamedPerson {
    age: number;
}

const oldPerson: AgedPerson = {
    age: 40,
    firstName: "Mike",
    greet(lastName: string) {
        console.log("Hello. I'm " + this.firstName +
            " " + lastName);
    }
}

console.log(oldPerson);
