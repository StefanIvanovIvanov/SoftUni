function binaryDigitCount(num, count) {
    let binary = num.toString(2).split("");
    let counter = 0;
    for (let el of binary) {
        el = Number(el);
        count = Number(count);
        if (el === count) {
            counter++;
        }
    } 
    console.log(counter);
}

binaryDigitCount(15, 1);