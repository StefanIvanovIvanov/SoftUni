import { loadHome } from './controllers/homeController.js';
import { loadRegisterForm, createUser } from './controllers/registerController.js';
import { loadLoginForm, login } from './controllers/loginController.js';
import { logout } from './controllers/logoutController.js';
import { loadDetails, closeTreck, like, loadEditForm, edit } from './controllers/detailsController.js';
import { loadUserPage } from './controllers/userPageController.js';
import { loadCreateTrekForm, createTrek } from './controllers/createFormController.js';

const app = Sammy('body', function () {
    this.use('Handlebars', 'hbs');

    this.get('/', loadHome)
    this.get('/index.html', loadHome)
    this.get('/register', loadRegisterForm)
    this.get('/login', loadLoginForm)
    this.get('/logout', logout)
    this.get('/userPage', loadUserPage)
    this.get('/createTrek', loadCreateTrekForm)
    this.get('/details/:id', loadDetails)
    this.get('/closeTreck/:id', closeTreck)
    this.get('/like/:id', like)
    this.get('/edit/:id', loadEditForm)
    
    this.post('/register', createUser)
    this.post('/login', login)
    this.post('/createTrek', createTrek)

    this.put('/edit/:id', edit)
})

app.run();