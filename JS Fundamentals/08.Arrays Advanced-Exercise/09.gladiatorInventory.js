function gladiatorInventory(input) {
    let resultArr = input.shift().split(" ");
    for (let el of input) {
        el = el.split(" ");
        let command = el[0];
        let value = el[1];

        if (command === "Buy") {
            if (!resultArr.includes(value)) {
                resultArr.push(value);
            }
        }
        else if (command === "Trash") {
            if (resultArr.includes(value)) {
                let index = resultArr.indexOf(value);
                resultArr.splice(index, 1);
            }
        }
        else if (command === "Repair") {
            if (resultArr.includes(value)) {
                let index = resultArr.indexOf(value);
                let item = resultArr.splice(index, 1);
                resultArr.push(item);
            }
        }
        else if (command === "Upgrade") {
            let splittedValue = value.split("-");
            let item = splittedValue[0];
            let upgrade = splittedValue[1];
            if (resultArr.includes(item)) {
                let index = resultArr.indexOf(item) + 1; 
                let value = `${item}:${upgrade}`;
                resultArr.splice(index, 0, value);
            }
        }
    }  
      console.log(resultArr.join(" "));
}

gladiatorInventory(['SWORD Shield Spear','Trash Bow','Repair Shield','Upgrade Helmet-V']);