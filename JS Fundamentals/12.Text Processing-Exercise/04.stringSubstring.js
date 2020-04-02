function stringSubstring(word, sentence) {
    let sentenceToLowerCase = sentence.toLowerCase();
    let wordToLowerCase = word.toLowerCase();
    let isFound = false;

    let words = sentenceToLowerCase.split(" ");
    for (let word of words) {
        if (word === wordToLowerCase) {
            console.log(word);
            isFound = true;
            break;
        }
    }   
    if (!isFound) {
        console.log(`${word} not found!`);
    }
}

stringSubstring('pythonJavaScript','pythonJavaScript is the best programming language');