(function (app) {
    'use strict';

    function adminCinemaService($http, routes) {
        var serv = this;
        serv.deleteCinema = function (id) {
            return $http.post(routes.DeleteCinema, id);
        };

        serv.getCinemaByName = function (name) {
            return $http.get(routes.GetCinemaByName, { params: { name: name } })
                .then(function (response) {
                    return response.data;
                });;
        };

        serv.getCinemaByAddress = function (address) {
            return $http.get(routes.GetCinemaByAddress, { params: { address: address } })
                .then(function (response) {
                    return response.data;
                });
        };

        serv.editCinema = function (cinema) {
            return $http.post(routes.EditCinema, cinema);
        };

        serv.addCinema = function (cinema) {
            return $http.post(routes.AddCinema, cinema)
                .then(function (response) {
                    return response.data;
                });
        }
    }

    app.service('adminCinemaService', ['$http', 'routes', adminCinemaService]);
})(angular.module('services'));