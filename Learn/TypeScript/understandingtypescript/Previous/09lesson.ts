function logged(constructorFn: Function) {
    console.log(constructorFn);
}

@logged
class Person3 {
    constructor() {
        console.log("Hi");
    }
}

// Decorator Factories
function logging(value: boolean): any {
    return value ? logged : null;
}

@logging(true)
class Car2 {

}

// Advanced Decorators
function printable(constructorFn: Function) {
    constructorFn.prototype.print = function() {
        console.log(this);
    }
}

@logging(true)
@printable
class Plant2 {
    name = "Green Plant";
}

const plant2 = new Plant2();
(<any>plant2).print();


// Method Decorators
// Property Decorators
function editable(value: boolean) {
    return function(target: any, propName: string, 
        descriptor: PropertyDescriptor) {
        descriptor.writable = value;
    }
}

function overwritable(value: boolean): any {
    return function(target: any, propName: string): any {
        const newDescriptor: PropertyDescriptor = {
            writable: value
        };
        return newDescriptor;
    }
}

class Project2 {
    //@overwritable(false)
    // Prevents all assignments to the property,
    // including within the constructor
    name: string;

    constructor(name: string) {
        this.name = name;
    }

    @editable(false)
    calcBudget() {
        console.log(1000);
    }


}

const project = new Project2("Project");
project.calcBudget();
// Because the method is not editable, this assignment 
// causes an error
/*project.calcBudget = function() {
    console.log(2000);
}*/


// Parameter Decorator
function printInfo(target: any, methodName: string,
    paramIndex: number) {
    console.log("Target: " + target);
    console.log("Method: " + methodName);
    console.log("Parameter Index: " + paramIndex);
}

class Course {
    name: string;

    constructor(name: string) {
        this.name = name;
    }

    printStudentNumbers(mode: string, 
        @printInfo all: boolean) {
        if(all) {
            console.log(10000);
        } else {
            console.log(2000);
        }
    }
}

const course = new Course("TypeScript");
course.printStudentNumbers("whatever", true);
course.printStudentNumbers("whatever", false);
