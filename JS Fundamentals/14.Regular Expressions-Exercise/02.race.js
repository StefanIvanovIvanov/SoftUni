function race(input) {
    let players = input.shift().split(", ");
    let resultObj = {};
    let score = input.shift();
    while (score !== 'end of race') {
        let namePattern = /[A-Za-z]/g;
        let name = score.match(namePattern).join("");

        let scorePattern = /\d/g;
        let numScore = score.match(scorePattern).map(Number).reduce((a, b) => (a + b));

        if (!resultObj[name] && players.includes(name)) {
            resultObj[name] = numScore;
        } else if (resultObj[name]) {
            resultObj[name] += numScore;
        }

        score = input.shift();
    }
    let sortedObj = Object.entries(resultObj).sort((a, b) => b[1] - a[1]);
    let counter = 1;
    for (let [name, score] of sortedObj) {
        if (counter === 4) {
            break;
        }
        if (players.includes(name)) {
            if (counter === 1) {
                console.log(`${counter}st place: ${name}`);
            }
            if (counter === 2) {
                console.log(`${counter}nd place: ${name}`);
            }
            if (counter === 3) {
                console.log(`${counter}rd place: ${name}`);
            }
        }
        counter++;
    }
}
race(['George, Peter, Bill, Tom',
    'G4e@55or%6g6!68e!!@',
    'R1@!3a$y4456@',
    'B5@i@#123ll',
    'G@e54o$r6ge#',
    '7P%et^#e5346r',
    'T$o553m&6',
    'end of race']);