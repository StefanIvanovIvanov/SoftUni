function pthBit(n, p) {
    n = n.toString(2).split("");
    let bitAtPosP = p >> n;
    let result = bitAtPosP & 1;
    console.log(result);
}

pthBit(2145, 5);
pthBit(512, 0);
pthBit(111, 8);
pthBit(255, 7);