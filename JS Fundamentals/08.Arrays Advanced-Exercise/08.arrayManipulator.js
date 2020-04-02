function arrManipulator(intArr, strArr) {
    intArr = intArr.map(Number);

    for (let el of strArr) {
        let splitted = el.split(" ");
        let command = splitted[0];

        if (command === `add`) {
            let index = Number(splitted[1]);
            let element = Number(splitted[2]);
            intArr.splice(index, 0, element);
        }
        else if (command === `addMany`) {
            let index = Number(splitted[1]);
            for (let i = splitted.length - 1; i >= 2; i--) {
                let element = Number(splitted[i]);
                intArr.splice(index, 0, element);
            }
        }
        else if (command === `contains`) {
            let element = Number(splitted[1]);
            if (intArr.includes(element)) {
                let index = intArr.indexOf(element);
                console.log(index);
            } else {
                console.log(`-1`);
            }
        }
        else if (command === `remove`) {
            let index = Number(splitted[1]);
            intArr.splice(index, 1);
        }
        else if (command === `shift`) {
            let positions = Number(splitted[1]);
            for (let i = 0; i < positions; i++) {
                let transitionNumber = intArr.shift();
                intArr.push(transitionNumber);
            }
        }
        else if (command === `sumPairs`) {
            let result = [];
            for (let i = 0; i < intArr.length; i += 2) {
                let firstElem = intArr[i];
                let secondElem = intArr[i+1];
                if (secondElem === undefined) {
                    secondElem = 0;
                }
                let sum = firstElem + secondElem;
                result.push(sum);
                sum = 0;
            }
            intArr = result;
        }
        else if (command === `print`) {
            console.log(intArr);
        }
    }
}

arrManipulator([1, 2, 3, 4, 5],['addMany 5 9 8 7 6 5', 'contains 15', 'remove 3', 'shift 1', 'print']);