"use strict";
class Calculator {
    // implementation
    calculate(operator, a, b, c, d) {
        let validNums = [a, b, c, d].filter(el => el !== undefined);
        switch (operator) {
            case "power":
                return a ** b;
            case "log":
                if (a <= 0 || b <= 0) {
                    throw new Error('Invalid log values');
                }
                return Math.log(a) / Math.log(b);
            case "add":
                return validNums.reduce((acc, val) => acc + val);
            case "subtract":
                return validNums.reduce((acc, val) => acc - val);
            case "multiply":
                return validNums.reduce((acc, val) => acc * val);
            case "divide":
                return validNums.reduce((acc, val) => acc / val);
        }
    }
    ;
}
const calc = new Calculator();
console.log(calc.calculate('power', 2, 3));
console.log(calc.calculate('power', 4, 1 / 2));
console.log(calc.calculate('log', 8, 2));
console.log(calc.calculate('add', 10, 5));
console.log(calc.calculate('add', 10, 5, 3));
console.log(calc.calculate('subtract', 10, 5));
console.log(calc.calculate('multiply', 2, 3, 4));
console.log(calc.calculate('divide', 100, 5, 2, 2));
// should be errors
// const calc = new Calculator();
// console.log(calc.calculate('power', 2, 3, 2));
// console.log(calc.calculate('add', 2));
// console.log(calc.calculate('log', 2, 3, 4, 5)); 
// console.log(calc.calculate('multiply', 2, 3, 4, 5, 6));
//# sourceMappingURL=14.OverloadedCalculator.js.map