function bitcoinMining(inputArr) {
    const bitcoinPrice = 11949.16;
    const goldPrice = 67.51;
    let numOfBitcoins = 0;
    let moneyLeft = 0;
    let isFirstDay = true;
    let allBitcoins = 0;
    let firstDay = 0;


    for (let i = 0; i < inputArr.length; i++) {
        let gramsGoldPerDay = inputArr[i];
        gramsGoldPerDay = Number(gramsGoldPerDay);
        if ((i + 1) % 3 === 0) {
            gramsGoldPerDay *= 0.7;
        }
        let goldValuePerDay = gramsGoldPerDay * goldPrice;

        allMoney = goldValuePerDay + moneyLeft

        if (allMoney >= bitcoinPrice) {
            if (isFirstDay) {
                firstDay = i + 1;
                isFirstDay = false;
            }
            numOfBitcoins = Math.floor(allMoney / bitcoinPrice);
            allBitcoins += numOfBitcoins;
            moneyLeft = allMoney - numOfBitcoins * bitcoinPrice;
        } else {
            moneyLeft += goldValuePerDay;
        }

    }
    console.log(`Bought bitcoins: ${allBitcoins}`)
    if (allBitcoins) {
        console.log(`Day of the first purchased bitcoin: ${firstDay}`)
    }
    console.log(`Left money: ${moneyLeft.toFixed(2)} lv.`)

}

bitcoinMining([3124.15, 504.212, 2511.124]);