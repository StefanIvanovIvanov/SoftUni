function partyTime(input) {
    let index = input.indexOf('PARTY');
    let invitedGuests = input.slice(0, index);
    let arrivedGuests = input.slice(index + 1);

    for (let arrived of arrivedGuests) {
        if (invitedGuests.includes(arrived)) {
            let index = invitedGuests.indexOf(arrived);
            invitedGuests.splice(index, 1);
        }
    }
    let vip = [];
    let regular = [];
    for (let guests of invitedGuests) {
        if('0123456789'.includes(guests[0])) {
            vip.push(guests);
        } else {
            regular.push(guests);
        }
    }
    console.log(vip.length+regular.length);
    console.log(vip.join("\n"));
    console.log(regular.join("\n"));
}

partyTime(['7IK9Yo0h','9NoBUajQ','Ce8vwPmE','SVQXQCbc','tSzE5t0p','PARTY','9NoBUajQ','Ce8vwPmE','SVQXQCbc']);