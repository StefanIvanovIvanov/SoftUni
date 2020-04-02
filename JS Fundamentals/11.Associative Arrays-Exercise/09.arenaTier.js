function arenaTier(input) {
    let gladiators = {};
    for (let line of input) {
        if (line === 'Ave Cesar') {
            break;
        }
        line = line.split(" ");
        if (line[1] === '->') {
            let name = line[0];
            let technique = line[2];
            let power = Number(line[4]);

            if (!gladiators[name]) {
                gladiators[name] = { [technique]: power };
            } else {
                if (!gladiators[name][technique]) {
                    gladiators[name][technique] = power;
                } else {
                    if (gladiators[name][technique] < power) {
                        gladiators[name][technique] = power;
                    }
                }
            }
        }
        else if (line[1] === 'vs') {
            let firstGladiator = line[0];
            let secondGladiator = line[2];

            if (gladiators[firstGladiator] && gladiators[secondGladiator]) {
                let firstGladiatorArr = Object.entries(gladiators[firstGladiator]);
                let secondGladiatorArr = Object.entries(gladiators[secondGladiator]);

                firstGladiatorTotalSkill = Object.values(gladiators[firstGladiator]).reduce((a, b) => a + b);
                secondGladiatorTotalSkill = Object.values(gladiators[secondGladiator]).reduce((a, b) => a + b);

                for (let [keyOne, valueOne] of firstGladiatorArr) {
                    for (let [keyTwo, valueTwo] of secondGladiatorArr) {
                        if (keyOne === keyTwo) {
                            if (firstGladiatorTotalSkill > secondGladiatorTotalSkill) {
                                delete gladiators[secondGladiator];
                                break;
                            }
                            else if (firstGladiatorTotalSkill < secondGladiatorTotalSkill) {
                                delete gladiators[firstGladiatorArr];
                                break;
                            }
                        }
                    }

                }
            }
        }
    }
    let sorted = Object.entries(gladiators).sort((a, b) => {
        let x = Object.values(a[1]).reduce((a, b) => a + b);
        let y = Object.values(b[1]).reduce((c, d) => c + d);
        let result = y - x;
        if (result === 0) {
            return a[0].localeCompare(b[0]);
        } else {
            return y - x;
        }
    })

    for (let sort of sorted) {
        let sum = Object.values(sort[1]).reduce((a, b) => (a + b));
        console.log(`${sort[0]}: ${sum} skill`);
        let sortedAttributes = Object.entries(sort[1]).sort((a, b) => {
            let result = b[1] - a[1];
            if (result === 0) {
                return a[0].localeCompare(b[0]);
            } else {
                return result;
            }
        });
        for (let sort of sortedAttributes) {
            console.log(`- ${sort[0]} <!> ${sort[1]}`);
        }
    }
}

arenaTier([
    'Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Peter vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Maximilian',
    'Ave Cesar'
]);