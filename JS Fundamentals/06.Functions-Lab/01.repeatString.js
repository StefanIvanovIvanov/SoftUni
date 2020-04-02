function repeatString(inputString, num) {
    let result = "";
    for (let i = 0; i < num; i++) {
        result += inputString
    }
    return result;
}

console.log(repeatString(`abc`, 3));