let isLettersNumbersOnly = (string) => {
    let result = string.split("")
    for (let i = 0; i < result.length; i++) {
        if ((result[i].charCodeAt(0) >= 65 && result[i].charCodeAt(0) <= 90)
            || (result[i].charCodeAt(0) >= 97 && result[i].charCodeAt(0) <= 122)
            || (result[i].charCodeAt(0) >= 48 && result[i].charCodeAt(0) <= 57)) {
        } else {
            console.log("Password must consist only of letters and digits");
            return false;
        }
    }
    return true;
}

isLettersNumbersOnly('logIn');