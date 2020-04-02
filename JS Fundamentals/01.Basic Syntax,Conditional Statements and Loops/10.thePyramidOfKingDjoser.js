function pyramidDjoser(base, increment) {
    base = +base;
    increment = +increment;
    let counter = 0;

    let allMaterials = 0;
    let stoneRequired = 0;
    let marbleRequired = 0;
    let lapisLazuliRequired = 0;
    let goldRequired = 0;

    if (base % 2 !== 0) {
        for (let i = base; i >= 1; i -= 2) {
            counter++
            allMaterials += i * i;
            if (i === 1) {
                goldRequired = 1;
                break;
            }
            else if (counter % 5 === 0) {
                lapisLazuliRequired += i * i - (i - 2) * (i - 2);
            } else {
                marbleRequired += i * i - (i - 2) * (i - 2);
            }
            
        }
        stoneRequired = allMaterials - marbleRequired - lapisLazuliRequired - goldRequired;
    } else {
        for (let i = base; i >= 2; i -= 2) {
            counter++
            allMaterials += i * i;
            if (i === 2) {
                goldRequired = 4;
                break;
            } 
            else if (counter % 5 === 0) {
                lapisLazuliRequired += i * i - (i - 2) * (i - 2);
            }
           else {
                marbleRequired += i * i - (i - 2) * (i - 2);
            }
            
        }
        stoneRequired = allMaterials - marbleRequired - lapisLazuliRequired - goldRequired;
    }



    console.log(`Stone required: ${Math.ceil(stoneRequired * increment)}`);
    console.log(`Marble required: ${Math.ceil(marbleRequired * increment)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuliRequired * increment)}`);
    console.log(`Gold required: ${Math.ceil(goldRequired * increment)}`);
    console.log(`Final pyramid height: ${Math.floor(counter * increment)}`);
}


pyramidDjoser(23,1);