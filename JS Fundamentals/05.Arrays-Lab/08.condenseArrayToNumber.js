function condenseArrayToNumber(inputArr) {
    inputArr = inputArr.map(x => Number(x));
    let solveArr = [];

    while (inputArr.length > 1) {
        for (let i = 0; i < inputArr.length - 1; i++) {
            firstNum = inputArr[i];
            secNum = inputArr[i+1];
            let sum = firstNum + secNum;
            solveArr.push(sum);
        }
        inputArr = solveArr.slice();
        solveArr = [];
    }
    console.log(inputArr[0]);
}

condenseArrayToNumber([5,0,4,1,2]);