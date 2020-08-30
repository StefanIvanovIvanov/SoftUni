import { getSessionInfo, setSessionInfo } from "./sessionController.js";
import { post } from "../requester.js";
import { partials } from "../partials/partials.js";
import { redirect } from "./redirect.js";

export function loadRegisterForm(ctx){
    getSessionInfo(ctx);

    this.loadPartials(partials).then(function () {
        this.partial('./components/register/register.hbs')
    });
}

export function createUser(ctx){
    const { username, password, repeatPassword } = ctx.params;
    if ( username.length > 1 && password.length > 1 && password === repeatPassword) {
        post('user', '', 'Basic', { username, password })
            .then(x => {
                setSessionInfo(x);
                redirect(ctx, '/');
            })
            .catch(console.error)
    }
}