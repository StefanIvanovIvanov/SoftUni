function nxnMatrix(num) {
    num = num.toString();
    let result = [];
    for (let j = 0; j < num; j++) {
        for (let i = 0; i < num; i++) {
            result.push(num);
        }
        console.log(result.join(" "));
        result = [];
    }
}

nxnMatrix(6);