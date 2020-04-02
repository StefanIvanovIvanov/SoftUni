function radioCrystal(input){
    var target = Number(input[0]);
 
    function process(crystalThickness, action){
        switch(action) {
            case "cut":
                crystalThickness = crystalThickness >> 2;
                cutCount++;
                break;
            case "lap":
                crystalThickness /= 1.25;
                lapCount++;
                break;
            case "grind":
                crystalThickness -= 20;
                grindCount++;
                break;
            case "etch":
                crystalThickness -= 2;
                etchCount++;
                break;
            case "xRay":
                crystalThickness += 1;
                xrayCount++;
                return crystalThickness;
        }
 
        return transportingWashing(crystalThickness);
    }
 
    function transportingWashing(crystalThickness) {
        return Math.floor(crystalThickness);
    }
 
    for(let i = 1; i < input.length; i++){
        var current = input[i];
        var cutCount = 0, lapCount = 0, grindCount = 0, etchCount = 0, xrayCount = 0;
        var used = false;
 
        console.log(`Processing chunk ${current} microns`);
 
        while(current != target){
            while(current >> 2 >= target - 1){
                current = process(current,"cut");
            }
            while(current / 1.25 >= target - 1){
                current = process(current,"lap");
            }
            while(current - 20 >= target - 1){
                current = process(current,"grind");
            }
            while(current - 2 >= target - 1){
                current = process(current,"etch");
            }
            if(current + 1 == target && used == false){
                used = true;
                current = process(current,"xRay");
            }
        }
 
        if(cutCount > 0) {
            console.log(`Cut x${cutCount}`)
            console.log("Transporting and washing");
        }
 
        if(lapCount > 0) {
            console.log(`Lap x${lapCount}`)
            console.log("Transporting and washing");
        }
 
        if(grindCount > 0) {
            console.log(`Grind x${grindCount}`)
            console.log("Transporting and washing");
        }
 
        if(etchCount > 0) {
            console.log(`Etch x${etchCount}`)
            console.log("Transporting and washing");
        }
 
        if(used) {
            console.log(`X-ray x1`)
        }
 
        console.log(`Finished crystal ${target} microns`)
    }
}

radioCrystals([1000, 4000, 8100]);