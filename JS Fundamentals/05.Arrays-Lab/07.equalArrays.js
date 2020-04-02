function equalArrays(firstArr, secArr) {
    firstArr = firstArr.map(x => (Number(x)));
    secArr = secArr.map(x => (Number(x)));
    let sum = 0;
    let isEqual = true;

    for (let i = 0; i < firstArr.length; i++) {
        if (firstArr[i] === secArr[i]) {
            sum += firstArr[i]; 
        } else {
            isEqual = false;
            console.log(`Arrays are not identical. Found difference at ${i} index`) 
            break;
        }
    }
    if (isEqual) {
        console.log(`Arrays are identical. Sum: ${sum}`)
    }
}

equalArrays(['1','2','3','4','5'], ['1','2','4','4','5']);