function train(input) {
    let train = input.shift().split(" ").map(Number);
    let wagonCapacity = Number(input.shift());
    
    for (let el of input) {
        el = el.split(" ");
        let commandValue = el[0];
        let value = Number(el[1]);
        
        if (commandValue === "Add") {
            train.push(value);
        } else {
            for (let i = 0; i < train.length; i++) {
                commandValue = Number(commandValue);
                if (train[i] + commandValue <= wagonCapacity) {
                    train[i] += commandValue;
                    break;
                }
            }
        }
    }
    console.log(train.join(" "));
}

train(['32 54 21 12 4 0 23','75','Add 10','Add 0','30','10','75']);