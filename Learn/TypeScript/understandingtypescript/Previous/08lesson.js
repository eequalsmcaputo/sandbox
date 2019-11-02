"use strict";
// Generics
// Simple Generic
function echo(data) {
    return data;
}
console.log(echo("Mike").length);
console.log(echo(27));
console.log(echo({ name: "Mike", age: 40 }));
// Better Generic
function betterEcho(data) {
    return data;
}
console.log(betterEcho("Mike").length);
console.log(betterEcho(27));
console.log(betterEcho({ name: "Mike", age: 40 }));
// Built-in Generics
const testResults2 = [1.94, 2.33];
testResults2.push(-2.99);
console.log(testResults2);
// Arrays
function printAll(args) {
    args.forEach((element) => console.log(element));
}
printAll(["apple", "banana"]);
// Generic Types
const echo2 = betterEcho;
console.log(echo2("Something"));
// Generic Classes
class SimpleMath {
    calculate() {
        return +this.baseValue * +this.multiplyValue;
    }
}
const simpleMath = new SimpleMath();
simpleMath.baseValue = 10;
simpleMath.multiplyValue = "20";
console.log(simpleMath.calculate());
