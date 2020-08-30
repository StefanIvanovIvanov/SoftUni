export function getSessionInfo(ctx) {
    ctx.loggedIn = localStorage.getItem('authtoken') !== null;
    if (ctx.loggedIn) {
        ctx.username = localStorage.getItem('username');
    }
}

export function setSessionInfo(data) {
    localStorage.setItem('authtoken', data._kmd.authtoken);
    localStorage.setItem('username', data.username);
    localStorage.setItem('id', data._id);
}

export function clearSessionData(){
    localStorage.clear();
}