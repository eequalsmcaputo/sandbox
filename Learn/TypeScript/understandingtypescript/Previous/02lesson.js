"use strict";
// Implicitly-assigned types
// string
let myName = "Mike";
// number
let myAge = 40;
// boolean
let hasHobbies = true;
// Explicitly-assigned types
let myRealAge;
// array
let hobbies = ["cooking", "sports"];
// tuple
// order in which elements are declared matters
let address = ["Superstreet", 99];
//let address: [number, string] = ["Superstreet", 99];
// enum
// 0-based index
// can explicitly assign index
var Color;
(function (Color) {
    Color[Color["Gray"] = 0] = "Gray";
    Color[Color["Green"] = 1] = "Green";
    Color[Color["Blue"] = 2] = "Blue";
})(Color || (Color = {}));
let myColor = Color.Green;
// any
let car = "BMW";
car = { brand: "BMW", series: 3 };
// function return types
function returnMyName() {
    return myName;
}
// void
function sayHello() {
    console.log("Hello");
}
// function argument types
function multiply(val1, val2) {
    return val1 * val2;
}
// functions as types
let myMultiply;
myMultiply = multiply;
// objects
let userData = {
    name: "Mike",
    age: 40
};
let complex = {
    data: [100, 3.99, 10],
    output: function () {
        return this.data;
    }
};
let complex2 = {
    data: [100, 3.99, 10],
    output: function () {
        return this.data;
    }
};
// union types
let myRealRealAge = 40; // or "40"
// check types
let finalValue = "A string";
if (typeof finalValue == "number") {
    console.log("Final value is a number");
}
// never
function neverReturns() {
    throw new Error("Error"); // function never returns
}
// nullable types
let canBeNull = 12;
canBeNull = null;
