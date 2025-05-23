"use strict";
var WeekDays;
(function (WeekDays) {
    WeekDays[WeekDays["Monday"] = 1] = "Monday";
    WeekDays[WeekDays["Tuesday"] = 2] = "Tuesday";
    WeekDays[WeekDays["Wednesday"] = 3] = "Wednesday";
    WeekDays[WeekDays["Thursday"] = 4] = "Thursday";
    WeekDays[WeekDays["Friday"] = 5] = "Friday";
    WeekDays[WeekDays["Saturday"] = 6] = "Saturday";
    WeekDays[WeekDays["Sunday"] = 7] = "Sunday";
})(WeekDays || (WeekDays = {}));
function reverseDayOfTheWeek(dayName) {
    return WeekDays[dayName] || 'error';
}
console.log(reverseDayOfTheWeek('Monday'));
console.log(reverseDayOfTheWeek('Thursday'));
console.log(reverseDayOfTheWeek('Invalid'));
//# sourceMappingURL=06.ReverseDayOfTheWeek.js.map