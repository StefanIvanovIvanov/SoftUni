function commonElements(firstInput, secondInput) {
    for (let firstIterator of firstInput) {
        for (let secondIterator of secondInput) {
            if (firstIterator === secondIterator) {
                console.log(firstIterator);
            }
        }
    }
}

commonElements(["Hey", "hello", 2, 4, "Pesho", "e"], ["Pecho", 10, "hey", 4, "hello", "2"]);