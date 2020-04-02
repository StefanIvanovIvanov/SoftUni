function evenAndOddSubtraction(inputArr) {
    inputArr.map(x => Number(x));
    let sumEven = 0;
    let sumOdd = 0;

    for (let i = 0; i < inputArr.length; i++) {
        inputArr[i] % 2 === 0 ? sumEven += inputArr[i] : sumOdd += inputArr[i];
    }
    console.log(sumEven - sumOdd);
}

evenAndOddSubtraction([1,2,3,4,5,6]);