function smallestTwoInArr(input) {
    let result = input
    .map(Number)
    .sort((a, b) => (a - b))
    .filter((el, i) => (i < 2));
    console.log(result.join(" "));
}

smallestTwoInArr([3, 0, 10, 4, 7, 3]);