// Implicitly-assigned types
// string
let myName = "Mike";

// number
let myAge = 40;

// boolean
let hasHobbies = true;


// Explicitly-assigned types
let myRealAge: number;


// array
let hobbies: string[] = ["cooking", "sports"];


// tuple
// order in which elements are declared matters
let address: [string, number] = ["Superstreet", 99];
//let address: [number, string] = ["Superstreet", 99];

// enum
// 0-based index
// can explicitly assign index
enum Color {
    Gray,
    Green,
    Blue
}

let myColor: Color = Color.Green;

// any
let car: any = "BMW";
car = {brand: "BMW", series: 3}


// function return types
function returnMyName(): string {
    return myName;
}

// void
function sayHello(): void {
    console.log("Hello");
}

// function argument types
function multiply(val1: number, val2: number) {
    return val1 * val2;
}

// functions as types
let myMultiply: (val1: number, val2: number) => number;
myMultiply = multiply;

// objects
let userData: { name: string, age: number } = {
    name: "Mike",
    age: 40
};

// complex objects
// type aliases

type Complex = {data: number[], output: (all: boolean) => 
    number[]};

let complex: Complex = {
    
    data: [100, 3.99, 10],
    
    output: function(): number[] {
        return this.data;
    }
};

let complex2: Complex = {
    data: [100, 3.99, 10],
    
    output: function(): number[] {
        return this.data;
    }
};


// union types
let myRealRealAge: number | string = 40; // or "40"

// check types
let finalValue = "A string";
if(typeof finalValue == "number") {
    console.log("Final value is a number");
}


// never
function neverReturns(): never {
    throw new Error("Error"); // function never returns
}

// nullable types
let canBeNull: number | null = 12;
canBeNull = null;
