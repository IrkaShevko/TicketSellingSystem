(function (app) {
    'use strict';

    function cinemaLoadingService($http, routes) {
        var serv = this;
        serv.getCinemas = function (page) {
            return $http.get(routes.GetCinemas, { params: { page: page } })
                .then(function (response) {
                    return response.data;
                });
        }
    }

    app.service('cinemaLoadingService', ['$http', 'routes', cinemaLoadingService]);
})(angular.module('services'));