function travelTime(input) {
    let travelObj = {};
    for (let line of input) {
        let splitted = line.split(" > ");
        let country = splitted[0];
        let town = splitted[1];
        let travelCost = Number(splitted[2]);

        if (!travelObj.hasOwnProperty(country)) {
            travelObj[country] = {};
        }
        if (!travelObj[country].hasOwnProperty(town)) {
            travelObj[country][town] = travelCost;
        }
        if (travelObj[country][town] > travelCost) {
            travelObj[country][town] = travelCost;
        }
    }
    let sortedCountries = Object.entries(travelObj).sort(function (a, b) {
            return a[0][0].localeCompare(b[0][0])
    });


    for (let [country, town] of sortedCountries) {
        let sortedTowns = Object.entries(town)
            .sort((a, b) => (a[1] - b[1]))
            .map(t => t.join(" -> "))
        console.log(`${country} -> ${sortedTowns.join(" ").trim()}`);
    }
}

travelTime([`Bulgaria > Sofia > 25000`,
    `aaa > Sofia > 1`,
    `aa > Orgrimar > 0`,
    `Albania > Tirana > 25000`,
    `zz > Aarna > 25010`,
    `Bulgaria > Lukovit > 10`]);