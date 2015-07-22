(function (app) {
    'use strict';

    function mainLoadingService($http, $q, routes) {
        var serv = this;
        serv.getFilms = function(page) {
            return $http.get(routes.GetFilms, {params: { page: page } })
                .then(function (response) {
                    return response.data;
                });
        }

        serv.loadData = function() {
            return $q.all({films: serv.getFilms(1)})
                .then(function (values) {
                return values;
            });
        }
    }

    app.service('mainLoadingService', ['$http', '$q', 'routes', mainLoadingService]);
})
(angular.module('services'));