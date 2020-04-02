function minerTask(input) {
    let result = {};

    for (let i = 0; i < input.length; i+=2) {
        let name = input[i];
        let qty = Number(input[i+1]);
        
        if (!result.hasOwnProperty(name)) {
            result[name] = qty;
        } else {
            result[name] += qty;
        }
    }
    console.log();
    for (let [name, qty] of Object.entries(result)) {
        console.log(`${name} -> ${qty}`);
    }
}

minerTask([`gold`,`155`,`silver`,`10`,`copper`,`17`,`gold`,`15`]);