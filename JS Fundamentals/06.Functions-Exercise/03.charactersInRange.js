function charactersInRange(charOne, charTwo) {
    let charOneToNum = charOne.charCodeAt();
    let charTwoToNum = charTwo.charCodeAt();
    let result = [];

    if (charOneToNum < charTwoToNum) {
        for (let i = charOneToNum + 1; i < charTwoToNum; i++) {
            let charOneFromString = String.fromCharCode(i);
            result.push(charOneFromString);
        }
        console.log(result.join(" "));
    } else {
        for (let i = charTwoToNum + 1; i < charOneToNum; i++) {
            let charOneFromString = String.fromCharCode(i);
            result.push(charOneFromString);
        }
        console.log(result.join(" "));
    }
}

charactersInRange('C','#');