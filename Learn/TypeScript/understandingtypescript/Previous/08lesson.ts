// Generics
// Simple Generic
function echo(data: any) {
    return data;
}

console.log(echo("Mike").length);
console.log(echo(27));
console.log(echo({name: "Mike", age: 40}));

// Better Generic
function betterEcho<T>(data: T) {
    return data;
}

console.log(betterEcho("Mike").length);
console.log(betterEcho<number>(27));
console.log(betterEcho({name: "Mike", age: 40}));



// Built-in Generics
const testResults2: Array<number> = [1.94, 2.33];
testResults2.push(-2.99);
console.log(testResults2);

// Arrays
function printAll<T>(args: T[]) {
    args.forEach((element) => console.log(element));
}

printAll<string>(["apple", "banana"]);

// Generic Types
const echo2: <T>(data: T) => T = betterEcho;

console.log(echo2<string>("Something"));

// Generic Classes
class SimpleMath<T extends number | string, 
    U extends number | string> {
    baseValue: T;
    multiplyValue: U;

    calculate(): number {
        return +this.baseValue * +this.multiplyValue;
    }
}

const simpleMath = new SimpleMath<number, string>();
simpleMath.baseValue = 10;
simpleMath.multiplyValue = "20";
console.log(simpleMath.calculate());