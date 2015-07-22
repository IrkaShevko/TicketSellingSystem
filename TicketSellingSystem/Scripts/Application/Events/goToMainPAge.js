(function (app) {
    'use strict';

    app.run(function ($rootScope, $location, routes) {
        $rootScope.$on('go-to-main-page', function () {
            $location.path(routes.MainPage);
        });
    });
})(angular.module('filmApp'));