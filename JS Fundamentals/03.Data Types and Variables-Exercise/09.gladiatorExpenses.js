function gladiatorExpenses(lostFights, helmetP, swordP, shieldP, armorP) {
    lostFights = Number(lostFights)
    helmetP = Number(helmetP)
    swordP = Number(swordP)
    shieldP = Number(shieldP)
    armorP = Number(armorP)

    let helmetCounter = 0;
    let swordCounter = 0;
    let shieldCounter = 0;
    let armourCounter = 0;

    for (let i = 1; i <= lostFights; i++) {
        i % 2 === 0 ? helmetCounter++ : helmetCounter;
        i % 3 === 0 ? swordCounter++ : swordCounter;
        i % 6 === 0 ? shieldCounter++ : shieldCounter;
        i % 12 === 0 ? armourCounter++ : armourCounter;
    }
    let sum = helmetP * helmetCounter +
                swordP * swordCounter +
                 shieldP * shieldCounter +
                 armorP * armourCounter;
       
                 console.log(`Gladiator expenses: ${sum.toFixed(2)} aureus`);
}

gladiatorExpenses(7, 2, 3, 4, 5);