function cutAndReverse(string) {
    let halfIndex = string.length / 2;
    let firstPart = string.substring(0, halfIndex);
    let secondPart = string.substring(halfIndex);


    function reverseString(str) {
        if (str === "")
            return "";
        else
            return reverseString(str.substr(1)) + str.charAt(0);
    }
    
    console.log(reverseString(firstPart));
    console.log(reverseString(secondPart));
}

cutAndReverse('sihToDtnaCuoYteBIboJsihTtAdooGoSmI')