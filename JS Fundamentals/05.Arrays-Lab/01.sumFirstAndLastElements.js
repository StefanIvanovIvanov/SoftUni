function sumFirstAndLastElements(inputArr) {
    inputArr = inputArr.map(x => Number(x));
    let firstNum = inputArr.shift();
    let lastNum = inputArr.pop();
    console.log(firstNum + lastNum);
}

sumFirstAndLastElements(['20', '30', '40']);