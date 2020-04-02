function addAndSubtract(numOne, numTwo, numThree) {
    let add = (a, b) => {return a + b;};
    let subtract = (a, b) => {return a - b;};

    let result = add(numOne, numTwo);
    result = subtract(result, numThree);
    return result;

}

console.log(addAndSubtract(1, 17,30 ));
