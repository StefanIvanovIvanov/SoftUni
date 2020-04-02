function simpleCalc(firstNum, secNum, operation) {
    firstNum = Number(firstNum);
    secNum = Number(secNum);
    let multiply = (a, b) => (a * b); 
    let divide = (a, b) => (a / b); 
    let add = (a, b) => (a + b); 
    let subtract = (a, b) => (a - b); 

    switch (operation) {
        case `multiply`: return multiply(firstNum, secNum);
        case `divide`: return divide(firstNum, secNum);
        case `add`: return add(firstNum, secNum);
        case `subtract`: return subtract(firstNum, secNum);
        default:
            break;
    }
}

simpleCalc(5, 5, 'multiply');