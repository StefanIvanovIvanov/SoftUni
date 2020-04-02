function perfectNum(num) {
    num = Number(num);
    let sumDivisor = 0;
    for(let i = 0; i < num; i++) {
        if (num % i === 0) {
            sumDivisor += i;
        }
    }
    if (num === sumDivisor) {
        console.log(`We have a perfect number!`);
    } else {
        console.log(`It's not so perfect.`);
    }
}

perfectNum(28);