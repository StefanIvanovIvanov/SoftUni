function lastKNumsSeq(n, k) {
    let result = [1];
    for (let i = 0; i < n - 1; i++) {
        let firstIndex = i - k + 1;
        if (firstIndex < 0) {
            firstIndex = 0;
        }
        let num = result.slice(firstIndex, i+1);
        let sum = num.reduce((a,b) => (a + b));
        result.push(sum);
    }
    console.log(result.join(" "));
}

lastKNumsSeq(6, 3);