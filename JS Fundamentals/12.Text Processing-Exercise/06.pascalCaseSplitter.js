function pascalCaseSplit(string) {
    let resultString = string[0];
    for (let i = 1; i < string.length - 1; i++) {
        let ascii = string[i+1].charCodeAt(0);
        if (ascii >= 65 && ascii <= 90) {
            resultString += `${string[i]}, `;
        } else {
            resultString += string[i];
        }
    }
    resultString += string[string.length - 1]
    console.log(resultString);

}

pascalCaseSplit('SplitMeIfYouCanHaHaYouCantOrYouCan');