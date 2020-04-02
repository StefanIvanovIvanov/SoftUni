function negPosOrderArr(input) {
    let numberArr = input.map(Number);
    let result = [];
    numberArr.forEach(element => {
        if (element >= 0) {
            result.push(element);
        } else {
            result.unshift(element);
        }
    });
    return result.join("\n")
}

console.log(negPosOrderArr([3, -2, 0, -1]));