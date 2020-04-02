function bitDestroer(n, p) {
    
    let mask = 1 << p;
    mask = mask.toString(2);
    let inverted = ~ mask;

    console.log(inverted);
}

bitDestroer(1313, 5);