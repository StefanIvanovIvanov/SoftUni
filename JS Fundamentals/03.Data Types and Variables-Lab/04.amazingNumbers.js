function solve(num) {
    let string = num.toString();
    let splitted = string.split("");
    let sum = 0;

    for (let index in splitted) {
        sum += +splitted[index];
    }

    sum = sum.toString().includes(`9`);

    if (sum) {
        console.log(`${num} Amazing? True`);
    } else {
        console.log(`${num} Amazing? False`);
    }
}

solve(1233);