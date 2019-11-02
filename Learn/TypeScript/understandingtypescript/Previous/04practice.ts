// Exercise 1
const double = (value: number): number => value * 2;
console.log(double(10));


// Exercise 2
const greet2 = function(name: string = "Mike"): void {
    console.log(`Hello, ${name}`);
}
greet2();
greet2("Anna");


// Exercise 3
const numbers2: number[] = [-3, 33, 38, 5];
console.log(Math.min(...numbers2));


// Exercise 4
const newArray = [55, 20];
newArray.push(...numbers2);
console.log(newArray);


// Exercise 5
const testResults: number[] = [3.89, 2.99, 1.38];
const [r1, r2, r3] = testResults;
console.log(r1, r2, r3);


// Exercise 6
const scientist = {firstName: "Mike", experience: 15};
const {firstName, experience} = scientist;
console.log(firstName, experience);