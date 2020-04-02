function name(num1, num2, num3) {

    let sum = +num1 + +num2 + +num3;
    let int = parseInt(sum)
    
    if (sum === int) {
        console.log(`${sum} - Integer`);
    } else {
        console.log(`${sum} - Float`);
    }
}

name(9, 100, 1.9);