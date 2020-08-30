function solve(input) {
    const cars = [];

    const commands = {
        create: function (name, _, parent) {
            parent = cars.find(c => c.name === parent) || null;
            const newCar = Object.create(parent); // This example is OK for this solution. In real life Object.create(null) is not OK! Read about it in MDN.
            newCar.name = name;
            cars.push(newCar);
        },
        set: function (name, key, value) {
            let car = cars.find(c => c.name === name);
            car[key] = value;
        },
        print: function (name) {
            const result = [];
            let car = cars.find(c => c.name === name);
            for (const key in car) {
                result.push(`${key}:${car[key]}`);
            }
            console.log(result.slice(1).join(', '));
        }
    };

    input.map(x => {
        const [command, ...params] = x.split(' ');
        commands[command](...params);
    });
}

solve([
    'create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c2',
    'print c1',
]);