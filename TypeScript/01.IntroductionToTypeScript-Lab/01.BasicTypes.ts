// string
let str: string = 'pen4o';

str = 'singleQuotes';
str = "doubleQuotes";
//str = 11// invalid

//number
let decimal : number = 11;
let hex: number = 7E3;
let binary: number = 11111100011
let float: number = 3.14
//decimal = 'hello'//invalid

//boolean
let isBool: boolean = true;
isBool = 5 < 2 ;

//symbols - always unique
let uniqueSymbol: symbol = Symbol('mySymbol');
let anotherSymbol: symbol = Symbol('mySymbol');
console.log(uniqueSymbol === anotherSymbol); //false

//null and undefined
let undefinedValue1; //undefined
let undefinedValue2: undefined = undefined;
let person: null = null;

//array
 let arrayOfStr:  string[] = ['JS', 'HTML'];
 arrayOfStr.push("Hello");
 //arrayOfStr.push(11); //invalid

let strNumArr: Array<number | string> = ['pen40', 45]
let strNumArr2: (string | number)[] = ['pen40', 45]

 //tuple
let nameAndAge: [string, number] = ['pen4o', 45]

 let certificateInfo: [string, number, boolean] = [
    'MySQL',
    2025,
    true
]

//enum
enum DaysOfTheWeek {
    Monday, //0
    Tuesday, //1
}

function movePoint(point = {x: 0, y:0}, moveDirections: Directions) {
if(moveDirections ===Directions.Up) {
    return {x: point.x, y:point.y + 1 };
    } else if (moveDirections === Directions.Down) {
        return {x: point.x, y:point.y - 1 };
    }  else if (moveDirections === Directions.Left) {
        return {x: point.x - 1 , y:point.y };
    }  else if (moveDirections === Directions.Right) {
        return {x: point.x + 1, y:point.y };
    }
}

enum Directions {
    Up,
    Down,
    Left,
    Right
}

let point = {x: 0, y: 0};
console.log(movePoint(point, Directions.Right))

// any and unknown
let a: any = 'hello';
let b: unknown = 'hello';
a = 11;
b = 12;
console.log(a.length); // allowed, skips all type checks
//console.log(b.length); // TS Error: Proprty 'length' does notexist on type 'unknown'

// void used in functions that return no value
function greet(message: string) : void {
    console.log(message);
}

// return data types
function greetUser(username: string, addHello?: boolean): string {
    if(addHello === true){
        return `Hello, ${username}`;
    } else {
        return username;
    }
}

console.log(greetUser('Pen4o'))

// type interface

let httpCode = {
    code: 404,
    text: 'Page not found'
}

//type assertions
let val:unknown = 20;
let strVal = val as string; // does NOT convert to string but treats it as one

console.log(strVal.length); // undefined
console.log((<string>val).length); // undefined

//console.log(strVal * 10);
console.log(typeof strVal) // number - doesn't change the type

const inputEl = document.getElementById('email');
console.log((inputEl as HTMLInputElement)!.value);
// or
const inputEl2 = document.getElementById('email') as HTMLInputElement;
console.log(inputEl2!.value);

// type narrowing
function formatData(a: string | number, b: string | number) {
    if (typeof a === 'number' && typeof b === 'number'){
        console.log(a + b);
    } else {
        console.log(`${a}<->${b}`);
    }
}

// type guards - narrows the type
function isNumber(val: string | number) : val is number {
    return typeof val === 'number';
}