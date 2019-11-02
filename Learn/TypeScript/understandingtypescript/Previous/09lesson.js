"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
function logged(constructorFn) {
    console.log(constructorFn);
}
let Person3 = class Person3 {
    constructor() {
        console.log("Hi");
    }
};
Person3 = __decorate([
    logged
], Person3);
// Decorator Factories
function logging(value) {
    return value ? logged : null;
}
let Car2 = class Car2 {
};
Car2 = __decorate([
    logging(true)
], Car2);
// Advanced Decorators
function printable(constructorFn) {
    constructorFn.prototype.print = function () {
        console.log(this);
    };
}
let Plant2 = class Plant2 {
    constructor() {
        this.name = "Green Plant";
    }
};
Plant2 = __decorate([
    logging(true),
    printable
], Plant2);
const plant2 = new Plant2();
plant2.print();
// Method Decorators
// Property Decorators
function editable(value) {
    return function (target, propName, descriptor) {
        descriptor.writable = value;
    };
}
function overwritable(value) {
    return function (target, propName) {
        const newDescriptor = {
            writable: value
        };
        return newDescriptor;
    };
}
class Project2 {
    constructor(name) {
        this.name = name;
    }
    calcBudget() {
        console.log(1000);
    }
}
__decorate([
    editable(false)
], Project2.prototype, "calcBudget", null);
const project = new Project2("Project");
project.calcBudget();
// Because the method is not editable, this assignment 
// causes an error
/*project.calcBudget = function() {
    console.log(2000);
}*/
// Parameter Decorator
function printInfo(target, methodName, paramIndex) {
    console.log("Target: " + target);
    console.log("Method: " + methodName);
    console.log("Parameter Index: " + paramIndex);
}
class Course {
    constructor(name) {
        this.name = name;
    }
    printStudentNumbers(mode, all) {
        if (all) {
            console.log(10000);
        }
        else {
            console.log(2000);
        }
    }
}
__decorate([
    __param(1, printInfo)
], Course.prototype, "printStudentNumbers", null);
const course = new Course("TypeScript");
course.printStudentNumbers("whatever", true);
course.printStudentNumbers("whatever", false);
