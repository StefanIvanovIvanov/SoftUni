function spiceMustFlow(startingYield) {
    let dayCounter = 0;
    startingYield = Number(startingYield);
    let produce = 0;
    
    while (startingYield >= 100) {
        produce += startingYield - 26;
        startingYield -= 10;
        dayCounter++;
    }
    produce >= 26 ? produce -= 26 : produce = 0;
    console.log(dayCounter);
    console.log(produce);
}

spiceMustFlow(111);