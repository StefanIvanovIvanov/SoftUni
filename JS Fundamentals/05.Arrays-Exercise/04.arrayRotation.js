function arrayRotation(inputArr, rotations) {
    let resultArr = inputArr;
    for (let i = 0; i < rotations; i++) {
        let shifted = resultArr.shift();
        resultArr.push(shifted);
    }
    console.log(resultArr.join(" "));
}

arrayRotation([51, 47, 32, 61, 21], 2);