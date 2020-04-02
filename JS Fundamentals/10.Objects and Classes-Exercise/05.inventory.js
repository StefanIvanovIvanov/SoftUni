function inventory(input) {
    let heroes = [];
    for (let line of input) {
        let splitted = line.split(" / ");
        let name = splitted[0];
        let level = Number(splitted[1]);
        
        let items = splitted[2].split(", ").sort((a, b) => a.localeCompare(b));
        console.log(items);
        
        heroes.push({
            Hero: name,
            level: level,
            items: items
        })
    }
    
    heroes.sort((a, b) => (a.level - b.level));
    
    for (let obj of heroes) {
       let [hero, level, items] = Object.entries(obj);
       let heroKey = hero.shift();
       let levelKey = level.shift();
       let itemsKey = items.shift();
       level = level.map(Number);        
    }
}

inventory(["Isacc / 25 / Apple, GravityGun","Derek / 12 / BarrelVest, DestructionSword","Hes / 1 / Desolator, Sentinel, Antara"]);