(function (app) {
    'use strict';

    app.run(function ($rootScope, $location, sessionService, routes, authEvents) {
        $rootScope.$on(authEvents.notAuthenticated, function () {
            sessionService.destroy();
            $location.path(routes.LoginPage);
        });
    });
})(angular.module('filmApp'));