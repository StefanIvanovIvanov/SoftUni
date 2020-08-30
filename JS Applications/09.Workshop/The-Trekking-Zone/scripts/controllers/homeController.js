import { getSessionInfo } from "./sessionController.js";
import { get } from "../requester.js";
import { partials } from "../partials/partials.js";

export function loadHome(ctx) {
    getSessionInfo(ctx);

    partials.trek = 'components/adventure/trek.hbs';
    this.loadPartials(partials).then(function () {
        if(localStorage.getItem('authtoken') !== null){
            get('appdata', 'treks', 'Kinvey')
                .then(x => {
                    if (x.length > 0) {
                        ctx.foundTreks = true;
                        ctx.treks = x;
                    }

                    this.partial('./components/adventure/treckList.hbs');
                })
                .catch(console.error);
            
        }else{
            this.partial('./components/home/anonHome.hbs');
        }
    });
}