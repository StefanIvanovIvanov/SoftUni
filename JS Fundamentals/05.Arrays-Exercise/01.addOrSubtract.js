function addOrSubtract(input) {
    let inputArr = input.map(Number);
    let sumOriginalArr = 0;
    let sumModifiedArr = 0;

    for (let i = 0; i < inputArr.length; i++) {
        sumOriginalArr += inputArr[i];
        if (inputArr[i] % 2 === 0) {
            inputArr[i] += i; 
        } else {
            inputArr[i] -= i; 
        }
        sumModifiedArr += inputArr[i];
    }
    console.log(inputArr);
    console.log(sumOriginalArr);
    console.log(sumModifiedArr);
}

addOrSubtract([5, 15, 23, 56, 35]);