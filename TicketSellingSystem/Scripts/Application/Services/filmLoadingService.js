(function (app) {
    'use strict';

    function filmLoadingService($http, routes) {
        var serv = this;
        serv.loadFilm = function(id) {
            return $http.get(routes.GetFilm, { params: { id: id } })
                .then(function(response) {
                    return response.data.Result;
                });
        }
    }

    app.service('filmLoadingService', ['$http', 'routes', filmLoadingService]);
})(angular.module('services'));