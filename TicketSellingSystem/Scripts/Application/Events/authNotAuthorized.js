(function (app) {
    'use strict';

    app.run(function ($rootScope, $location, routes, authEvents) {
        $rootScope.$on(authEvents.notAuthorized, function () {
            $location.path(routes.MainPage);
        });
    });
})(angular.module('filmApp'));