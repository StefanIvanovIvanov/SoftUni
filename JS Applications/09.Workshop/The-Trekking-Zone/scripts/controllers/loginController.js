import { getSessionInfo, setSessionInfo } from "./sessionController.js";
import { post } from "../requester.js";
import { partials } from "../partials/partials.js";
import { redirect } from "./redirect.js";

export function loadLoginForm(ctx){
    getSessionInfo(ctx);

    this.loadPartials(partials).then(function () {
        this.partial('./components/login/login.hbs')
    });
}

export function login(ctx){
    const { username, password } = ctx.params;

    if (username !== '' && password !== '') {
        post('user', 'login', 'Basic', { username, password })
            .then(x => {
                setSessionInfo(x);
                redirect(ctx, '/');
            })
    }
}