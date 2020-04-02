function wrongResult(numOne, numTwo, numThree) {
    numOne = Number(numOne);
    numTwo = Number(numTwo);
    numThree = Number(numThree);

    if (numOne < 0 && numTwo < 0 && numThree < 0) {
        return "Negative";
    }
    else if (numOne < 0 && numTwo > 0 && numThree > 0) {
        return "Negative";
    }
    else if (numOne > 0 && numTwo < 0 && numThree > 0) {
        return "Negative";
    }
    else if (numOne > 0 && numTwo > 0 && numThree < 0) {
        return "Negative";
    } else {
        return "Positive"
    }
}

console.log(wrongResult(-1, 0, 1));