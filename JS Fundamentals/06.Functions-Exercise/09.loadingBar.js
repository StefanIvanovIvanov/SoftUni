function loadingBar(num) {
    num = Number(num);
    let leftBar = "%".repeat(num / 10);
    let rightBar = ".".repeat(10 - num / 10);

    if (num / 100 !== 1) {
        console.log(`${num}% [${leftBar}${rightBar}]`);
        console.log(`Still loading...`);
        
    } else {
        console.log(`100% Complete!`);
        console.log(`[${leftBar}${rightBar}]`);
    }
}

loadingBar(30);