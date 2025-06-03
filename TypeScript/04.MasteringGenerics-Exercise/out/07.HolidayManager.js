"use strict";
var TravelVacation;
(function (TravelVacation) {
    TravelVacation["Abroad"] = "Abroad";
    TravelVacation["InCountry"] = "InCountry";
})(TravelVacation || (TravelVacation = {}));
var MountainVacation;
(function (MountainVacation) {
    MountainVacation["Ski"] = "Ski";
    MountainVacation["Hiking"] = "Hiking";
})(MountainVacation || (MountainVacation = {}));
var BeachVacation;
(function (BeachVacation) {
    BeachVacation["Pool"] = "Pool";
    BeachVacation["Sea"] = "Sea";
    BeachVacation["ScubaDiving"] = "ScubaDiving";
})(BeachVacation || (BeachVacation = {}));
class PlannedHoliday {
    _start;
    _end;
    constructor(startDate, endDate) {
        this.start = startDate;
        this.end = endDate;
    }
    set start(val) {
        if (val > this._end) {
            throw Error('Start date cannot be after end date');
        }
        this._start = val;
    }
    set end(val) {
        if (val < this._start) {
            throw Error('End date cannot be before start date');
        }
        this._end = val;
    }
    getInfo() {
        return `Holiday: ${this._start.getDate()}/${this._start.getMonth() + 1}/${this._start.getFullYear()} - ${this._end.getDate()}/${this._end.getMonth() + 1}/${this._end.getFullYear()}`;
    }
}
class HolidayManager {
    holidays = new Map();
    reserveVacation(holiday, vacationType) {
        this.holidays.set(holiday, vacationType);
    }
    ;
    listReservations() {
        let result = [];
        Array.from(this.holidays.entries()).forEach(entry => {
            result.push(`${entry[0].getInfo()} => ${entry[1]}`);
        });
        return result.join('\n');
    }
    ;
}
let holiday = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
let holiday2 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2025, 3, 17));
let holidayManager = new HolidayManager();
holidayManager.reserveVacation(holiday, TravelVacation.Abroad);
holidayManager.reserveVacation(holiday2, TravelVacation.InCountry);
console.log(holidayManager.listReservations());
let newHoliday = new PlannedHoliday(new Date(2022, 10, 11), new Date(2022, 10, 18));
let newHoliday2 = new PlannedHoliday(new Date(2024, 5, 18), new Date(2024, 5, 22));
let newHolidayManager = new HolidayManager();
newHolidayManager.reserveVacation(holiday, BeachVacation.ScubaDiving);
newHolidayManager.reserveVacation(holiday2, BeachVacation.Sea);
console.log(newHolidayManager.listReservations());
//TS error
// let newerHoliday = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
// let newerHoliday2 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2024, 3, 17));
// let newerHolidayManager = new HolidayManager<Holiday, MountainVacation>();
// newerHolidayManager.reserveVacation(holiday, BeachVacation.ScubaDiving);
// newerHolidayManager.reserveVacation(holiday2, TravelVacation.InCountry);
// console.log(newerHolidayManager.listReservations())
//# sourceMappingURL=07.HolidayManager.js.map