(function (app) {
    'use strict';

    app.constant('authEvents', {
        goToMainPage: 'go-to-main-page',
        notAuthenticated: 'auth-not-authenticated',
        notAuthorized: 'auth-not-authorized'
    });
})(angular.module('constants'));