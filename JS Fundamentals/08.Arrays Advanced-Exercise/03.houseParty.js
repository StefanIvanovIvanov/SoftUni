function houseParty(input) {
    let result = [];
    for (let el of input) {
        let splitted = el.split(" ");
        let name = splitted[0];

        if (splitted.length === 3) {
            if (result.includes(name)) {
                console.log(`${name} is already in the list!`);
            } else {
                result.push(splitted[0]);
            }
        } else {
            if (result.includes(name)) {
                let index = result.indexOf(name);
                result.splice(index, 1);
            } else {
                console.log(`${name} is not in the list!`);
            }
        }
    }
    for (let el of result) {
        console.log(el);
    }
}

houseParty(['Tom is going!','Annie is going!','Tom is going!','Garry is going!','Jerry is going!']);
