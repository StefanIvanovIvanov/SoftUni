import { getSessionInfo, setSessionInfo } from "./sessionController.js";
import { post } from "../requester.js";
import { partials } from "../partials/partials.js";
import { redirect } from "./redirect.js";

export function loadCreateTrekForm(ctx){
    getSessionInfo(ctx);

    this.loadPartials(partials).then(function () {
        this.partial('./components/adventure/createAdventure.hbs')
    });
}

export function createTrek(ctx){
    let { location, date, description, imageURL} = ctx.params;

    if (location.length > 6 && description.length > 10) {
        const header = { location, date, description, imageURL, likes: 0, organizer: localStorage.getItem('username') };
        post('appdata', 'treks', 'Kinvey', header)
            .then(x => {
                    redirect(ctx, '/')
                }
            )
            .catch(console.error)
    }
}