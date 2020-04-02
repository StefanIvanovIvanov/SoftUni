function printAndSum(start, end) {
    start = +start;
    end = +end;
    let concat = ""
    let sum = 0;
    for (let i = start; i <= end; i++) {
        concat += i.toString() + " "
        sum += i;
    }
    console.log(concat)
    console.log(`Sum: ${sum}`)
}

printAndSum(5, 10);