"use strict";
// string
let str = 'pen4o';
str = 'singleQuotes';
str = "doubleQuotes";
//str = 11// invalid
//number
let decimal = 11;
let hex = 7E3;
let binary = 11111100011;
let float = 3.14;
//decimal = 'hello'//invalid
//boolean
let isBool = true;
isBool = 5 < 2;
//symbols - always unique
let uniqueSymbol = Symbol('mySymbol');
let anotherSymbol = Symbol('mySymbol');
console.log(uniqueSymbol === anotherSymbol); //false
//null and undefined
let undefinedValue1; //undefined
let undefinedValue2 = undefined;
let person = null;
//array
let arrayOfStr = ['JS', 'HTML'];
arrayOfStr.push("Hello");
//arrayOfStr.push(11); //invalid
let strNumArr = ['pen40', 45];
let strNumArr2 = ['pen40', 45];
//tuple
let nameAndAge = ['pen4o', 45];
let certificateInfo = [
    'MySQL',
    2025,
    true
];
//enum
var DaysOfTheWeek;
(function (DaysOfTheWeek) {
    DaysOfTheWeek[DaysOfTheWeek["Monday"] = 0] = "Monday";
    DaysOfTheWeek[DaysOfTheWeek["Tuesday"] = 1] = "Tuesday";
})(DaysOfTheWeek || (DaysOfTheWeek = {}));
function movePoint(point = { x: 0, y: 0 }, moveDirections) {
    if (moveDirections === Directions.Up) {
        return { x: point.x, y: point.y + 1 };
    }
    else if (moveDirections === Directions.Down) {
        return { x: point.x, y: point.y - 1 };
    }
    else if (moveDirections === Directions.Left) {
        return { x: point.x - 1, y: point.y };
    }
    else if (moveDirections === Directions.Right) {
        return { x: point.x + 1, y: point.y };
    }
}
var Directions;
(function (Directions) {
    Directions[Directions["Up"] = 0] = "Up";
    Directions[Directions["Down"] = 1] = "Down";
    Directions[Directions["Left"] = 2] = "Left";
    Directions[Directions["Right"] = 3] = "Right";
})(Directions || (Directions = {}));
let point = { x: 0, y: 0 };
console.log(movePoint(point, Directions.Right));
// any and unknown
let a = 'hello';
let b = 'hello';
a = 11;
b = 12;
console.log(a.length); // allowed, skips all type checks
//console.log(b.length); // TS Error: Proprty 'length' does notexist on type 'unknown'
// void used in functions that return no value
function greet(message) {
    console.log(message);
}
// return data types
function greetUser(username, addHello) {
    if (addHello === true) {
        return `Hello, ${username}`;
    }
    else {
        return username;
    }
}
console.log(greetUser('Pen4o'));
// type interface
let httpCode = {
    code: 404,
    text: 'Page not found'
};
//type assertions
let val = 20;
let strVal = val; // does NOT convert to string but treats it as one
console.log(strVal.length); // undefined
console.log(val.length); // undefined
//console.log(strVal * 10);
console.log(typeof strVal); // number - doesn't change the type
const inputEl = document.getElementById('email');
console.log(inputEl.value);
// or
const inputEl2 = document.getElementById('email');
console.log(inputEl2.value);
// type narrowing
function formatData(a, b) {
    if (typeof a === 'number' && typeof b === 'number') {
        console.log(a + b);
    }
    else {
        console.log(`${a}<->${b}`);
    }
}
// type guards - narrows the type
function isNumber(val) {
    return typeof val === 'number';
}
//# sourceMappingURL=01.BasicTypes.js.map