// types
let test = { name: "Pesho", age: 20}

let testName = test.name;

console.log(testName)

type a = typeof test;
type b = keyof typeof test;
type c = {
    [k in keyof typeof test]: typeof test[k]
}

// class
class Doggye {
    private name: string;
    private age: number;

    constructor(n: string, a: number) {
        this.name = n;
        this.age = a;
    }

    bark(){
        return `${this.name} barked friendly`
    }
} 

// object
let tommy = new Doggye('Tommy', 6);

console.log(tommy);
console.log(tommy.bark()) 

// encaplsulation
interface Human {
    greet(): string;
}
    class Person implements Human {
    greet():string {
    return 'Hello, there!'
    }
}

// abstraction
interface Human {
greet(): string;
}

    class Person1 implements Human {
    greet():string {
    return 'Hello, there!'
    }
}

// inheritance
class Animal {
    sound: string;
    constructor(sound: string) {
    this.sound = sound;   
}
    makeSound(): void {
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

// polymorphism
type Greeter = { greet(): string; }

class Person2 {
    constructor(public name: string){}
    greet() { return `${this.name} says hello`};
}

let person: Greeter = new Person2('John');
console.log(person.greet());

// method overriding
class Shape {
    draw():void {console.log('Drawing a shape.'); }
}

class Circle extends Shape {
    draw() {console.log('Drawing a circle.'); } //Implicit override
} 


class Person3 {
    greet(num: number): void;
    greet(fName: string, lName: string): void;
    greet(a: number | string, b?: string): void {
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

private _fullName!: string;

get fullName(): string { // getter
    return this._fullName;
}
    set fullName(newName: string) { // setter
        if (newName && newName.length > fullNameMaxLength) {
            throw new Error("fullName has a max length of " + fullNameMaxLength);
        }
        
    this._fullName = newName;
    }
}

// public

class Zoo {
    public type: string;
    public name: string;
    public constructor(t: string, n: string) {
    this.type = t;
    this.name = n;
    }
}

// protected

class Animal1 {
    constructor(protected _name: string) {

     }
}

class Bear extends Animal1 {
    constructor (name:string) {
        super(name);
    }
    roar(){ console.log(`${this._name} roars.`) };
}

let martha = new Bear('Martha');
martha.roar(); // Martha roars.

// private

class Zoo1 {
private type: string;
private name: string;
constructor(t: string, n: string) {
this.type = t;
this.name = n;
}
}
let animal = new Zoo1('bear', 'Martha');
// console.log(animal.name); // Error: name is private.

// static

class Manufacturing {
    public maker: string;
    public model: string;
    public static vehiclesCount = 0;
    constructor(maker: string, model: string,) {
    this.maker = maker;
    this.model = model;
}

createVehicle() {
    let calls = ++Manufacturing.vehiclesCount;
    return `createVehicle called: ${calls} times`;
    }
}

// abstract

abstract class Department {
    public depName: string;
    constructor(n: string) { this.depName = n; }
    abstract sayHello(): void;
}

class Engineering extends Department {
    constructor(depName: string, public employee: string) {
        super(depName);
    }

    sayHello() {
    return `${this.employee} of ${this.depName} department says hi!`;
    }
}
//let dep = new Department('Test') // Cannot create instance of abstract class

// readonly
class Animal2 {
    readonly name: string;
    constructor(n: string) {
    this.name = n;
    }
}

let animal2 = new Animal2('Martha');
//animal2.name = 'Thomas'; //Error: name is read-only.