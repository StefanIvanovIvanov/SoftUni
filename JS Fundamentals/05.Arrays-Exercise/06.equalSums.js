function equalSums(input) {
    let sumLeft = 0;
    let sumRight = 0;
    let isEqual = false;
    let equalIndex = 0;
    for (let i = 0; i < input.length; i++) {
        for (let j = 0; j < i; j++) {
            sumLeft += input[j];
        }
        for (let k = i + 1; k < input.length; k++) {
            sumRight += input[k];
        }
        if (sumLeft === sumRight) {
            isEqual = true;
            equalIndex = i;
            break;
        }
        sumLeft = 0;
        sumRight = 0;
    }
    if (isEqual) {
        console.log(equalIndex);
    } else {
        console.log(`no`)
    }
}

equalSums([1, 2, 3, 3]);