function friday13(dates: unknown[]) : void {

    enum Months {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }

    for (const date of dates) {
        if(date instanceof Date){
            const monthDay = date.getDate();
            const weeklyDay = date.getDay();
            const mothNum = date.getMonth();

            if(monthDay === 13 && weeklyDay === 5) {
                console.log(`${monthDay}-${Months[mothNum]}-${date.getFullYear()}`)
            }
        }
    }
}

friday13([
new Date(2024, 0, 13),
new Date(2024, 1, 13),
new Date(2024, 2, 13),
new Date(2024, 3, 13),
new Date(2024, 4, 13),
new Date(2024, 5, 13),
new Date(2024, 6, 13),
new Date(2024, 7, 13),
new Date(2024, 8, 13),
new Date(2024, 9, 13),
new Date(2024, 10, 13),
new Date(2024, 11, 13)
])