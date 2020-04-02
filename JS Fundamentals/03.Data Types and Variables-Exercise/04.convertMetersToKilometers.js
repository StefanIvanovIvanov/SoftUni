function metersToKm(meters) {
    meters = Number(meters);
    let km = meters / 1000;
    console.log(km.toFixed(2))
}

metersToKm(1852);