function processOddNums(input) {
    let result = input
    .map(Number)
    .filter((el, i) => i % 2 !== 0)
    .map(x => 2 * x)
    .reverse();
    

    console.log(result.join(" "));
    
}

processOddNums([3, 0, 10, 4, 7, 3]);