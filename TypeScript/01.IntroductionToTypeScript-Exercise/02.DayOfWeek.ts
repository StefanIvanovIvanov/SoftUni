enum Days {
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}

function dayOfWeek(input: number) : void {
    console.log(Days[input] || 'error');
}

dayOfWeek(1);
dayOfWeek(5);
dayOfWeek(8);