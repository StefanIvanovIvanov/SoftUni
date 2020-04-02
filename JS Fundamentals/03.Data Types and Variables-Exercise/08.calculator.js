function calculator(firstNum, operator, secNum) {
    firstNum = Number(firstNum);
    secNum = Number(secNum);
    let result = 0;
    switch (operator) {
        case `+`:
            result = firstNum + secNum
            break;
        case `-`:
            result = firstNum - secNum
            break;
        case `*`:
            result = firstNum * secNum
            break;
        case `/`:
            result = firstNum / secNum
            break;
    }
    console.log(result.toFixed(2));
}

calculator(5, '+', 10);