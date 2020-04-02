function name(quizWord, letter, answerWord) {
    let splitted = quizWord.split("_");
    
    if (splitted[0] + letter + splitted[1] === answerWord) {
        console.log(`Matched`)
    } else {
        console.log(`Not Matched`)
    }
}

name('Str_ng', 'o', 'Strong');