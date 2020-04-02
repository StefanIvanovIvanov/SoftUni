function softUniBarIncome(input) {
    let totalPrice = 0;
    for (let line of input) {
        if (line === 'end of shift') {
            console.log(`Total income: ${totalPrice.toFixed(2)}`);
            break;
        }
        let pattern = /%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+[.]?[\d]*)\$/gm;

        let result = pattern.exec(line);
        while (result !== null) {
            let customer = result.groups['customer'];
            let product = result.groups['product'];
            let count = Number(result.groups['count']);
            let price = Number(result.groups['price']);
            let currentPrice = count * price;
            console.log(`${customer}: ${product} - ${currentPrice.toFixed(2)}`);
            
            totalPrice += currentPrice;
            result = pattern.exec(line);
        }

    }
}

softUniBarIncome([
    '%InvalidName%<Croissant>|2|10.3$',
    '%Peter%<Gum>1.3$',
    '%Maria%<Cola>|1|2.4',
    '%Valid%<Valid>valid|10|valid20$',
    '%George%<Croissant>|2|10.3$',
    '%Peter%<Gum>|1|1.3$',
    '%Maria%<Cola>|1|2.4$',
    'end of shift'
]);