function factorialDivision(numOne, numTwo) {
    numOne = Number(numOne);
    numTwo = Number(numTwo);
    
    let numOneFact = 1;
    let numTwoFact = 1;
    for (let i = 1; i <= numOne; i++) {
        numOneFact *= i;
    }
    for (let j = 1; j <= numTwo; j++) {
        numTwoFact *= j;
    }
    let result = numOneFact / numTwoFact
    console.log(result.toFixed(2));
}

factorialDivision(6, 2);