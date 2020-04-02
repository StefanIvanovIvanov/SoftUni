function example(currentStock, orderedProducts) {
    let obj = {};
    for (let i = 0; i < currentStock.length - 1; i += 2) {
        let product = currentStock[i];
        let quantity = Number(currentStock[i + 1]);
        obj[product] = quantity;
    }
    for (let j = 0; j < orderedProducts.length - 1; j += 2) {
        let product = orderedProducts[j];
        let quantity = Number(orderedProducts[j + 1]);
        if (obj.hasOwnProperty(product)) {
            obj[product] += quantity;
        } else {
            obj[product] = quantity;
        }
    }
    for (let [key, value] of Object.entries(obj)) {
        console.log(`${key} -> ${value}`);
    }
}

example(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'], ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);