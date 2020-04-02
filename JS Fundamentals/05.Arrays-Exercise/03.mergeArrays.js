function mergeArrays(firstInput, secondInput) {
    let resultArr = [];
    for (let key in firstInput) {
        key = Number(key);
        if (key % 2 === 0) {
            let firstInputNumber = firstInput.map(Number);
            let secondInputNumber = secondInput.map(Number);
            let sum = firstInputNumber[key] + secondInputNumber[key];
            resultArr.push(sum);
        } else {
            let firstInputString = firstInput.map(x => x.toString());
            let secondInputString = secondInput.map(x => x.toString());
            let sum = firstInputString[key] + secondInputString[key];
            resultArr.push(sum);
        }
    }
    console.log(resultArr.join(" - "));
}

mergeArrays(["13", "12312", "5", "77", "4"],["22", "333", "5", "122", "44"]);