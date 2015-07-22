(function(app) {
    'use strict';

    function userLoadingService($http, routes) {
        var serv = this;
        serv.getUsers = function (page) {
            return $http.get(routes.GetUsers, {params: {page: page} })
                .then(function(response) {
                    return response.data;
                });
        }
    }

    app.service('userLoadingService', ['$http', 'routes', userLoadingService]);
})(angular.module('services'));