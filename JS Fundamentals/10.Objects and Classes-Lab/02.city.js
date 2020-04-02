function city(name, area, population, country, postCode) {
    let city = {
        name,
        area,
        population,
        country,
        postCode,
    };
    let cityArr = Object.entries(city);
    for (let [key, value] of cityArr) {
        console.log(`${key} -> ${value}`);
    }
}

city("Sofia", "492", "1238438", "Bulgaria", "1000");