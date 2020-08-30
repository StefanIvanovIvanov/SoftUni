import { post } from "../requester.js";
import { clearSessionData } from "./sessionController.js";
import { redirect } from "./redirect.js";

export function logout(ctx){
    post('user', '_logout', 'Kinvey')
    .then(x => {
        clearSessionData();
        redirect(ctx, '/');
    })
    .catch(console.error)
}