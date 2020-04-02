function modernTimes(input) {
    let splitted = input.split(" ");
    let isLetters = true;
    for (let word of splitted) {
        if (word[0] === "#" && word.length > 1) {
            for (let i = 1; i < word.length; i++) {
                let asciiN = word[i].charCodeAt(0);
                if ((asciiN >= 65 && asciiN <= 90) ||
                    (asciiN >= 97 && asciiN <= 122)) {
                } else {
                    isLetters = false;
                    break;
                }
            }
            if (isLetters) {
                console.log(word.substring(1));
            }
            isLetters = true;
        }
    }
}

modernTimes('Nowadays everyone uses # to tag a #special word in #socialMedia');