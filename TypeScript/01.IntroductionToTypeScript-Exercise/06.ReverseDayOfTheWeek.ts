enum WeekDays {
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}

function reverseDayOfTheWeek(dayName: string) : string | number {
    return WeekDays[dayName as keyof typeof WeekDays] || 'error';
}

console.log(reverseDayOfTheWeek('Monday'));
console.log(reverseDayOfTheWeek('Thursday'));
console.log(reverseDayOfTheWeek('Invalid'));