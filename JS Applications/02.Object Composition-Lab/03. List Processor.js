function solve(input) {
    const commands = {
        add: function (arr, str) {
            arr.push(str);
            return arr;
        },
        remove: function (arr, str) {
            return arr.filter(x => x !== str);
        },
        print: function (arr, _) {
            console.log(arr.join(','));
            return arr;
        }
    };

    let output = [];
    return input.map(line => {
        const [command, str] = line.split(' ');
        output = commands[command](output, str);
    });
}

solve([
    'add hello',
    'print',
    'add again',
    'remove hello',
    'add again',
    'print',
]);