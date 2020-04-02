function bomberman(field, bomb) {
    let numField = field.map(Number);

    let bombNumber = Number(bomb[0]);
    let bombPower = Number(bomb[1]);

    for (let i = 0; i < numField.length; i++) {
        if (bombNumber === numField[i]) {
            if (i - bombPower >= 0) {
                numField.splice(i - bombPower, 2 * bombPower + 1);
                i = -1;
            } else {
                let index = i - bombPower + 2 * bombPower + 1
                if (index > numField.length) {
                    index = numField.length
                }
                numField.splice(0, index);
                i = -1;
            }
        }
    }
let sum = numField.reduce((a, b) => a + b, 0);
console.log(sum);
}

bomberman([3, 3, 4, 5, 6, 7, 3], [5, 3]);