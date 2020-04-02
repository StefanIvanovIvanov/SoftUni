function countStrOccurrences(string, word) {
    let splittedString = string.split(" ");
    let counter = 0;
    for (let elem of splittedString) {
        if (elem === word) {
            counter++;
        }
    }
    console.log(counter);
}

countStrOccurrences("This is a word and it also is a sentence","is");