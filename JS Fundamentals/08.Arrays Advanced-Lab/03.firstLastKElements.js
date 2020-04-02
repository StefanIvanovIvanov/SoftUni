function firstLastKElements(input) {
    let numArr = input.map(Number);
    let k = numArr.shift();

    let firstEl = numArr.slice(0, k);
    let lastEl = numArr.slice(numArr.length - k);

    console.log(firstEl.join(" "));
    console.log(lastEl.join(" ")); 
}

firstLastKElements([2, 7, 8, 9]);