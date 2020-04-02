function orderedList(input) {
    let result = input.sort();
    for (let i = 1; i <= result.length; i++) {
        console.log(`${i}.${result[i-1]}`);
    }
}

orderedList(["Potatoes", "Tomatoes", "Onions", "Apples"]);