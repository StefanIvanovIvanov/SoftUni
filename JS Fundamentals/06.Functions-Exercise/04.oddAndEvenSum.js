function oddAndEvenSum(input) {
    input = input.toString();
    let evenSum = 0;
    let oddSum = 0;
    for (let i = 0; i < input.length; i++) {
        if (input[i] % 2 === 0) {
            evenSum += Number(input[i]);
        } else {
            oddSum += Number(input[i]);
        }
    }   
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddAndEvenSum(1000435);