"use strict";
function friday13(dates) {
    let Months;
    (function (Months) {
        Months[Months["January"] = 1] = "January";
        Months[Months["February"] = 2] = "February";
        Months[Months["March"] = 3] = "March";
        Months[Months["April"] = 4] = "April";
        Months[Months["May"] = 5] = "May";
        Months[Months["June"] = 6] = "June";
        Months[Months["July"] = 7] = "July";
        Months[Months["August"] = 8] = "August";
        Months[Months["September"] = 9] = "September";
        Months[Months["October"] = 10] = "October";
        Months[Months["November"] = 11] = "November";
        Months[Months["December"] = 12] = "December";
    })(Months || (Months = {}));
    for (const date of dates) {
        if (date instanceof Date) {
            const monthDay = date.getDate();
            const weeklyDay = date.getDay();
            const mothNum = date.getMonth();
            if (monthDay === 13 && weeklyDay === 5) {
                console.log(`${monthDay}-${Months[mothNum]}-${date.getFullYear()}`);
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
]);
//# sourceMappingURL=09.FridayThe13th.js.map