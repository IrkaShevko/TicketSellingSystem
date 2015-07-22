(function (app) {
    'use strict';

    app.constant('roles', {
        Admin: 'Admin',
        Moderator: 'Moderator',
        User: 'User'
    });
})(angular.module('constants'));