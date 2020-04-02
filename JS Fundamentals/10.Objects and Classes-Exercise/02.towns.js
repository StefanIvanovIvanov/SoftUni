function towns(input) {
    for (let el of input) {
        let splitted = el.split(" | ");
        let town = splitted[0];
        let latitude = Number(splitted[1]).toFixed(2);
        let longitude = Number(splitted[2]).toFixed(2);

        let obj = {
            town,
            latitude,
            longitude
        }
        console.log(obj);
    }
};

towns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);