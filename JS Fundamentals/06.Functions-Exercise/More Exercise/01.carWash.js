function carWash(inputArr) {
    let currentClean = 0;

    for (let input of inputArr) {
        if (input === "soap") {
            currentClean += 10;
        }
        else if (input === "water") {
            currentClean *= 1.2;
        }
        else if (input === "vacuum cleaner") {
            currentClean *= 1.25;
        }
        else if (input === "mud") {
            currentClean *= 0.9;
        }
    }
    console.log(`The car is ${currentClean.toFixed(2)}% clean.`);
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);