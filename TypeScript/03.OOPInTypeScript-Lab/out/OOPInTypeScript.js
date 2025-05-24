"use strict";
// types
let test = { name: "Pesho", age: 20 };
let testName = test.name;
console.log(testName);
// class
class Doggye {
    name;
    age;
    constructor(n, a) {
        this.name = n;
        this.age = a;
    }
    bark() {
        return `${this.name} barked friendly`;
    }
}
// object
let tommy = new Doggye('Tommy', 6);
console.log(tommy);
console.log(tommy.bark());
class Person {
    greet() {
        return 'Hello, there!';
    }
}
class Person1 {
    greet() {
        return 'Hello, there!';
    }
}
// inheritance
class Animal {
    sound;
    constructor(sound) {
        this.sound = sound;
    }
    makeSound() {
        console.log(this.sound);
    }
}
class Dog extends Animal {
    constructor() {
        super('Bark');
    }
}
let dog = new Dog();
dog.makeSound(); // Bark
class Person2 {
    name;
    constructor(name) {
        this.name = name;
    }
    greet() { return `${this.name} says hello`; }
    ;
}
let person = new Person2('John');
console.log(person.greet());
// method overriding
class Shape {
    draw() { console.log('Drawing a shape.'); }
}
class Circle extends Shape {
    draw() { console.log('Drawing a circle.'); } //Implicit override
}
class Person3 {
    greet(a, b) {
        console.log(typeof a === 'number'
            ? `Your number: ${a}`
            : `Hello, ${a} ${b}`);
    }
}
let newPerson = new Person3();
newPerson.greet('John', 'Doe'); // Hello, John Doe
newPerson.greet(13); // Your number: 13
//newPerson.greet('John'); // Error: no matching signature
// S: Single Responsibility Principle
// O: Open / Closed Principle
// L: Liskov Substitution Principle
// I: Interface Segregation Principle
// D: Dependency Inversion Principle
// accessors
const fullNameMaxLength = 10;
class Employee {
    _fullName;
    get fullName() {
        return this._fullName;
    }
    set fullName(newName) {
        if (newName && newName.length > fullNameMaxLength) {
            throw new Error("fullName has a max length of " + fullNameMaxLength);
        }
        this._fullName = newName;
    }
}
// public
class Zoo {
    type;
    name;
    constructor(t, n) {
        this.type = t;
        this.name = n;
    }
}
// protected
class Animal1 {
    _name;
    constructor(_name) {
        this._name = _name;
    }
}
class Bear extends Animal1 {
    constructor(name) {
        super(name);
    }
    roar() { console.log(`${this._name} roars.`); }
    ;
}
let martha = new Bear('Martha');
martha.roar(); // Martha roars.
// private
class Zoo1 {
    type;
    name;
    constructor(t, n) {
        this.type = t;
        this.name = n;
    }
}
let animal = new Zoo1('bear', 'Martha');
// console.log(animal.name); // Error: name is private.
// static
class Manufacturing {
    maker;
    model;
    static vehiclesCount = 0;
    constructor(maker, model) {
        this.maker = maker;
        this.model = model;
    }
    createVehicle() {
        let calls = ++Manufacturing.vehiclesCount;
        return `createVehicle called: ${calls} times`;
    }
}
// abstract
class Department {
    depName;
    constructor(n) { this.depName = n; }
}
class Engineering extends Department {
    employee;
    constructor(depName, employee) {
        super(depName);
        this.employee = employee;
    }
    sayHello() {
        return `${this.employee} of ${this.depName} department says hi!`;
    }
}
//let dep = new Department('Test') // Cannot create instance of abstract class
// readonly
class Animal2 {
    name;
    constructor(n) {
        this.name = n;
    }
}
let animal2 = new Animal2('Martha');
//animal2.name = 'Thomas'; //Error: name is read-only.
//# sourceMappingURL=OOPInTypeScript.js.map