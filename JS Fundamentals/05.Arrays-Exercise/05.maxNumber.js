function maxNumber(input) {
    let result = input.slice();
    for (let i = 1; i < result.length; i++) {
        if (result[i] >= result[i - 1]) {
            let spliced = result.splice(i-1, 1);
            i = 0;            
        }
    }
    console.log(result.join(" "));
}

maxNumber([14, 24, 3, 19, 15, 17]);
