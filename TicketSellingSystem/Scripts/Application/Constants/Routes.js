(function (app) {
    'use strict';

    app.constant('routes', {
        GetUsers: 'api/adminUser/GetUsers',
        DeleteUser: 'api/adminUser/DeleteUser',
        BlockUser: 'api/adminUser/BlockUser',
        Register: 'api/account/Register',
        LogIn: 'api/account/LogIn',
        LogOff: 'api/account/LogOff',
        IsAuthorized: 'api/account/IsAuthorized',
        MainPage: '/',
        LoginPage: '/Login',
        GetFilms: 'api/film/GetFilms',
        GetFilm: 'api/film/GetFilm',
        GetCinemas: 'api/adminCinema/GetCinemas',
        GetCurrentUser: 'api/account/GetCurrentUser'
    });
})(angular.module('constants'));