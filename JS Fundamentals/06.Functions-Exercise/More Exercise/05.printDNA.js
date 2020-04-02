function printDNA(num) {
    num = Number(num);
    let letters = [`A`, `T`, `C`, `G`, `T`, `T`, `A`, `G`, `G`, `G`];
    let i = 0;
    let k = 0;

    while (i !== num) {
        if (k + 1 >= 10) {
            k = 0;
        }
        console.log(`**${letters[k]}${letters[k+1]}**`)
        i++;
        k += 2;
        if (i === num) {
            break;
        }
        if (k + 1 >= 10) {
            k = 0;
        }
        console.log(`*${letters[k]}--${letters[k+1]}*`)
        i++;
        k += 2;
        if (i === num) {
            break;
        }
        if (k + 1 >= 10) {
            k = 0;
        }
        console.log(`${letters[k]}----${letters[k+1]}`)
        i++;
        k += 2;
        if (i === num) {
            break;
        }
        if (k + 1 >= 10) {
            k = 0;
        }
        console.log(`*${letters[k]}--${letters[k+1]}*`)
        i++;
        k += 2;
        if (i === num) {
            break;
        }
    }
}

printDNA(10);