function reverseAnArrayOfStrings(inputArr) {
    let reversedArr = [];

    for (let i = inputArr.length - 1; i >= 0; i--) {
        reversedArr.push(inputArr[i]);
    }

    console.log(reversedArr.join(" "));
}

reverseAnArrayOfStrings(['a', 'b', 'c', 'd', 'e']);