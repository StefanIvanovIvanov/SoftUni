function passwordValidator(inputStr) {

    function isBetweenRange(inputStr) {
        return inputStr.length >= 6 && inputStr.length <= 10;
    }

    function isLettersNumbersOnly(inputStr) {
        let validContent = true;
        for (let i = 0; i < inputStr.length; i++) {
            let asciiCode = inputStr[i].charCodeAt(0);
            if ((asciiCode >= 48 && asciiCode <= 57) ||
                (asciiCode >= 65 && asciiCode <= 90) ||
                (asciiCode >= 97 && asciiCode <= 122)) {
                continue;
            }
            validContent = false;
            break;
        }
        return validContent;
    }

    function isAtLeastTwoDigist(inputStr) {
        let digitCount = 0;
        for (let i = 0; i < inputStr.length; i++) {
            if (inputStr[i].charCodeAt(0) >= 48 && inputStr[i].charCodeAt(0) <= 57) {
                digitCount++;
            }
        }
        return digitCount >= 2;
    }

    let result = [];
    if (isAtLeastTwoDigist(inputStr) && isBetweenRange(inputStr) && isLettersNumbersOnly(inputStr)) {
        result.push("Password is valid");
    } else {
        if (!isBetweenRange(inputStr)) {
            result.push("Password must be between 6 and 10 characters");
        }
        if (!isLettersNumbersOnly(inputStr)) {
            result.push("Password must consist only of letters and digits");
        }
        if (!isAtLeastTwoDigist(inputStr)) {
            result.push("Password must have at least 2 digits");
        }
    }
    console.log(result.join(`\n`));
}

passwordValidator(`Pa12123`);