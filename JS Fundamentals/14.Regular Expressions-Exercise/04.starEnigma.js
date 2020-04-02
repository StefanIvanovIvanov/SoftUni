function example(input) {
    let num = Number(input.shift());
    let counter = 0;
    let decrypted = "";
    let attackedCounter = 0;
    let destroyedCounter = 0;
    let attacked = [];
    let destroyed = [];
    for (let string of input) {
        for (let symbol of string) {
            symbol = symbol.toLowerCase();
            if (symbol === 's' || symbol === 't' || symbol === 'a' || symbol === 'r') {
                counter++;
            }                        
        }
        for (let symbol of string) {
            let newSymbol = String.fromCharCode(symbol.charCodeAt(0) - counter);
            decrypted += newSymbol;
        }
        let pattern = /@(?<planetName>[A-Za-z]+)[^@\-!:>]*:[^@\-!:>]*?(?<planetPopulation>[\d]+)[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldierCount>[\d]+)/gm;
        let result = pattern.exec(decrypted);
        while(result !== null) {
            let planetName = result.groups['planetName'];
            let planetPopulation = Number(result.groups['planetPopulation']);
            let attackType = result.groups['attackType'];
            let soldierCount = Number(result.groups['soldierCount']);

            if (attackType === 'A') {
                attacked.push(planetName);
            }
            else if (attackType === 'D') {
                destroyed.push(planetName);
            }
            
            result = pattern.exec(decrypted);
        }
        
        counter = 0;
        decrypted = "";
    }
    console.log(`Attacked planets: ${attacked.length}`);
        attacked.sort((a, b) => a.localeCompare(b)).forEach(elem => console.log(`-> ${elem}`));
    console.log(`Destroyed planets: ${destroyed.length}`);
        destroyed.sort((a, b) => a.localeCompare(b)).forEach(elem => console.log(`-> ${elem}`));
}

example([
  '3',
  'tt(\'\'DGsvywgerx>6444444444%H%1B9444',
  'GQhrr|A977777(H(TTTT',
  'EHfsytsnhf?8555&I&2C9555SR' 
]);