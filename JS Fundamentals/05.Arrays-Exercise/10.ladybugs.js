function ladybugs(inputArr) {
    fieldSize = Number(inputArr.shift());
    ladybugsIndexes = inputArr.shift().split(" ").map(Number).filter(i => i >= 0 && i < fieldSize);

    let field = new Array(fieldSize).fill(0, 0, fieldSize);

    for (let i = 0; i < ladybugsIndexes.length; i++) {
        for (let j = 0; j < field.length; j++) {
            if (j === ladybugsIndexes[i]) {
                field[j] = 1;
            }
        }
    }

    for (let i = 0; i < inputArr.length; i++) {
        let splitted = inputArr[i].split(" ");
        let startIndex = Number(splitted[0]);
        let direction = splitted[1];
        let flyLength = Number(splitted[2]);

        if (startIndex >= 0 && startIndex < field.length) {
            if (field[startIndex] === 1) {
                field[startIndex] = 0;
                while (startIndex >= 0 && startIndex < field.length) {
                    if (direction === "right") {
                        startIndex += flyLength;
                    }
                    else if (direction === "left") {
                        startIndex -= flyLength;
                    }
                    if (field[startIndex] === 0) {
                        field[startIndex] = 1;
                        break;
                    }
                }
            }
        }
    }
    console.log(field.join(" "));
}

ladybugs([`5`,`3`,`3 left 2`,`1 left -2`]);