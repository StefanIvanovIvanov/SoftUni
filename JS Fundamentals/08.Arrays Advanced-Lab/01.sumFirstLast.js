function sumFirstLastEl(inputArr) {
    let numberArr = inputArr.map(Number);
    let firstElement = numberArr.shift();
    let lastElement = numberArr.pop();
    let sum = firstElement + lastElement;
    return sum;
}

console.log(sumFirstLastEl(['20', '30', '40']));