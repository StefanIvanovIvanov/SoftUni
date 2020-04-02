function censoredWords(str, word) {
    let censoredWord = str;
    while (censoredWord.includes(word)) {
        censoredWord = censoredWord.replace(word, "*".repeat(word.length));
    }
    console.log(censoredWord);
}

censoredWords("A small sentence with small some words", "small");