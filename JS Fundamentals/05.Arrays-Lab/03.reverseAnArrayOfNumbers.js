function reverseAnArrayOfNumbers(n, array) {
    n = Number(n);
    array.map(x => Number(x));
    let solveArr = [];
    
    for (let i = n - 1; i >= 0; i--) {
        solveArr.push(array[i]);
    }

    console.log(solveArr.join(" "));
}

reverseAnArrayOfNumbers(3, [10, 20, 30, 40, 50]);