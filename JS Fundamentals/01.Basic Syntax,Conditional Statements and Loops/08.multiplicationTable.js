function multiplicationTable(param) {
    param = +param;
    
    for (let i = 1; i <= 10; i++) {
        let multiplication = param * i;
        console.log(`${param} X ${i} = ${multiplication}`)
    }
}

multiplicationTable(5);