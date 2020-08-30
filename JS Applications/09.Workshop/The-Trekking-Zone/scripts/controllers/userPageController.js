import { get } from "../requester.js";
import { getSessionInfo } from "./sessionController.js";
import { partials } from "../partials/partials.js";

export function loadUserPage(ctx) {
    getSessionInfo(ctx)
    this.loadPartials(partials).then(function () {
        let myTreks = [];
        let user = localStorage.getItem('username');
        get('appdata', `treks`, 'Kinvey')
            .then(x => {
                x.map(x => {
                    if (x.organizer === user) {
                        myTreks.push(x.location);
                    }
                })

                ctx.username = user;
                ctx.treksNumber = myTreks.length;
                ctx.foundTreks = myTreks.length > 0;
                ctx.treks = myTreks;
                this.partial('/components/userPage/userPage.hbs');
            })
            .catch(console.error)
       
    });
}