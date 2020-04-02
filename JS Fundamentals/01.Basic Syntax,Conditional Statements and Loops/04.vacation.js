function vacation(group, type, day) {
    group = Number(group);
    let price = 0;

    if (type === "Students") {
        if (day === "Friday") {
            price = 8.45;
        }
        else if (day === "Saturday") {
            price = 9.80;
        }
        else if (day === "Sunday") {
            price = 10.46;
        }
        let totalPrice = price * group;
        
        if (group >= 30) {
            totalPrice *= 0.85;
        }
        console.log(`Total price: ${totalPrice.toFixed(2)}`)
    }
    else if (type === "Business") {
        if (day === "Friday") {
            price = 10.90;
        }
        else if (day === "Saturday") {
            price = 15.60;
        }
        else if (day === "Sunday") {
            price = 16.00;
        }
        if (group >= 100) {
            group -= 10;
        }
        let totalPrice = price * group;
        console.log(`Total price: ${totalPrice.toFixed(2)}`)
    }
    else if (type === "Regular") {
        if (day === "Friday") {
            price = 15;
        }
        else if (day === "Saturday") {
            price = 20;
        }
        else if (day === "Sunday") {
            price = 22.50;
        }
        
        let totalPrice = price * group;
        
        if (group >= 10 && group <= 20) {
            totalPrice *= 0.95;
        }
        console.log(`Total price: ${totalPrice.toFixed(2)}`)
    }
}

vacation(30,"Students","Sunday");

