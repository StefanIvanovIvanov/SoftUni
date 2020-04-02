function legendaryFarming(input) {
    let itemCollection = {};
    let inputArr = input.split(" ");

    itemCollection['shards'] = 0;
    itemCollection['fragments'] = 0;
    itemCollection['motes'] = 0;

    for (let i = 0; i < inputArr.length; i += 2) {
        let qty = Number(inputArr[i]);
        let material = inputArr[i + 1].toLowerCase();

        if (!itemCollection.hasOwnProperty(material)) {
            itemCollection[material] = qty;
        } else {
            itemCollection[material] += qty;
        }

        if (itemCollection['shards'] >= 250) {
            console.log(`Shadowmourne obtained!`);
            itemCollection['shards'] -= 250;
            break;
        }
        if (itemCollection['fragments'] >= 250) {
            console.log(`Valanyr obtained!`);
            itemCollection['fragments'] -= 250;
            break;
        }
        if (itemCollection['motes'] >= 250) {
            console.log(`Dragonwrath obtained!`);
            itemCollection['motes'] -= 250;
            break;
        }
    }
    
    let sorted = Object.entries(itemCollection)
    let specialStones = {};
    let basicStones = {};

    for (let sort of sorted) {
        if (sort[0] === 'motes' || sort[0] === 'shards' || sort[0] === 'fragments') {
            specialStones[sort[0]] = sort[1];
        } else {
            basicStones[sort[0]] = sort[1];
        }
    }

    let sortedSpecial = Object.entries(specialStones).sort(function (a, b) {
        if (a[1] === b[1]) {
           return a[0].localeCompare(b[0]);
        } else {
           return b[1] - a[1];
        }
    });
    
    for (let [item, qty] of sortedSpecial) {
        console.log(`${item}: ${qty}`)
    }

    let sortedBasic = Object.entries(basicStones).sort((a, b) => a[0].localeCompare(b[0]));
    for (let [item, qty] of sortedBasic) {
        console.log(`${item}: ${qty}`)
    }

}

legendaryFarming('123 silver 6 shards 8 shards 5 motes 9 fangs 75 motes 103 MOTES 8 Shards 86 Motes 7 stones 19 silver');