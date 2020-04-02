function firstBit(num) {
    let binary = num.toString(2).split("");
    let positionOne = binary[binary.length - 2];
    console.log(positionOne);
}

firstBit(2);
firstBit(51);
firstBit(13);
firstBit(24);