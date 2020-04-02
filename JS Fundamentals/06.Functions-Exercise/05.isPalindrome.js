function isPalindromeInt(inputArr) {
    for (let element of inputArr) {
        element = element.toString();
        let reversed = element.toString().split("").reverse().join("");

        if (element === reversed) {
            console.log(`true`)
        } else {
            console.log(`false`)
        }
    }
}

isPalindromeInt([123, 323, 421, 121]);