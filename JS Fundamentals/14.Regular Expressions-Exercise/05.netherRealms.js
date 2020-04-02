function netherRealms(input) {
    let damage = 0;
    
    let sorted = input[0].split(', ').sort((a, b) => (a.localeCompare(b)));
    let resultObj = {};
    for (let text of sorted) {
        text = text.trim();        
        let digitPattern = /-?\d+\.?\d*/gm; 
        let damagePattern = /[*\/]/gm;
        let healthPattern = /[^\d\.\+\-\*\/\,]+/gm;
        let digitResult = text.match(digitPattern);
        
        if (digitResult !== null) {
            
            damage = digitResult.map(Number).reduce((a, b) => (a + b));
            let damageArr = text.match(damagePattern);
            
            if (damageArr) {
                for (let char of damageArr) {
                    if (char === "*") {
                        damage *= 2;
                    }
                    else if (char === "/") {
                        damage /= 2;
                    }
                }
            }
        }

        let healthArr = text.match(healthPattern);
        
        let health = healthArr
            .reduce((a, b) => a + b)
            .split("")
            .filter(x => x !== " ")
            .map(symbol => symbol.charCodeAt())
            .reduce((a, b) => a + b);
        if (!resultObj[text]) {
            resultObj[text] = [health, damage];
        }
        damage = 0;
    }
    let sortedObj = Object.entries(resultObj).sort((a, b) => a[0].localeCompare(b[0]));
    for (let [name, [health, damage]] of sortedObj) {
        console.log(`${name} - ${health} health, ${damage.toFixed(2)} damage`);
    }    
}

netherRealms(['Gos/ho, bg5/g*5g/5*/g*5/g5*g/5 g5*/g *5/*5/* 5']);