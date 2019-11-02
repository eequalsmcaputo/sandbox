// let & const
console.log("LET & CONST");
// let: block scope
let variable: string = "Test";
console.log(variable);
variable = "Another value";
console.log(variable);

const maxLevel: number = 100;
console.log(maxLevel);


// block scope
console.log("BLOCK SCOPE");
function reset() {
    let variable = null;
    console.log(variable);
}
reset();
console.log(variable);

// arrow functions
console.log("ARROW FUNCTIONS");
const multiplyNumbers = (number1: number, number2: number) =>
    number1 * number2;
/* can also do it with curly braces and a return statement:
    (number1: number, number2: number) => {
        return number1 * number2; 
    }
*/
console.log(multiplyNumbers(10, 3));
const greet = () => {console.log("Hello");}
greet();

const greetFriend = (friend: string) => console.log(friend);
greetFriend("Manu");


// default parameters
console.log("DEFAULT PARAMETERS");
// can reference previously-declared parameters with
// following parameters
const countdown = (start: number = 10, 
    end: number = start - 10): void => {
    while (start >= end) {
        start--;
    }
    console.log("Done", start);
}
countdown();


// rest & spread
console.log("REST & SPREAD");

// spread
const numbers = [1, 10, 99, -5];
// can't pass the numbers array alone
console.log(Math.max(...numbers));

// rest
function makeArray(...args: number[]) {
    return args;
}

console.log(makeArray(1, 2, 6));


// destructuring
console.log("DESTRUCTURING");
const hobbies2 = ["Programming", "Reading"];
const [hobby1, hobby2] = hobbies2
console.log(hobby1, hobby2);

const userData2 = { username: "Mike", age: "40" };
// keys must match
const {username, age} = userData2;
// can also assign new variable names
//const {username: un, age: a} = userData2;
console.log(username, age);


// template literals (c# verbatim / interpolated strings)
console.log("TEMPLATE LITERALS");
const userName = "Mike";
// const greeting = "Hello, I'm " + userName;
const greeting = `Hello, I'm ${userName}.
I'm learning TypeScript`;

console.log(greeting);


