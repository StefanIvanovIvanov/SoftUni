function buildWall(input) {
    input = input.map(Number);
    let concretePerDay = 0;
    let result = [];
    
    while (input.length > 0) {
        for (let i = 0; i < input.length; i++) {
            let element = input[i];
            if (element < 30) {
                concretePerDay += 195;
            } else {
                input.splice(i, 1);
                i -= 1;
            }
        }
        if (input.length === 0) {
            break;
        }
        result.push(concretePerDay);
        concretePerDay = 0;
        input = input.map((x) => (x + 1));
    }
    console.log(result.join(", "));
    let concrete = result.reduce((a, b) => (a + b));
    let pesos = concrete * 1900
    console.log(`${pesos} pesos`);
}

buildWall([21, 25, 28]);