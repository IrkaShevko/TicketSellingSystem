(function(app) {
    'use strict';

    function authService($http, sessionService, routes) {
        var serv = this;
        serv.register = function(user) {
            return $http.post(routes.Register,
                {
                    Name: user.name,
                    Email: user.email,
                    Password: user.password,
                    Phone: user.phone
                })
                .then(function(response) {
                    sessionService.create(response.data.Result.Name,
                        response.data.Result.Roles);
                    return response.data;
                });
        };

        serv.logIn = function(user) {
            return $http.post(routes.LogIn,
                {
                    Email: user.email,
                    Password: user.password
                })
                .then(function(response) {
                    sessionService.create(response.data.Result.Name,
                        response.data.Result.Roles);
                    return response.data;
                });
        };

        serv.logOff = function() {
            sessionService.destroy();
            return $http.post(routes.LogOff);
        };

        serv.isAuthenticated = function() {
            return !!sessionService.userName;
        };

        serv.isAuthorized = function(authorizedRoles) {
            if (!angular.isArray(authorizedRoles)) {
                authorizedRoles = [authorizedRoles];
            }
            if (serv.isAuthenticated()) {
                for (var i = 0, length = sessionService.userRoles.length; i < length; i++) {
                    if (authorizedRoles.indexOf(sessionService.userRoles[i]) !== -1)
                        return true;
                }
            }
            return false;
        };

        serv.getCurrentUser = function() {
            return $http.get(routes.GetCurrentUser)
                .then(function(response) {
                    return response.data;
                });
        }
    };

    app.service('authService', ['$http', 'sessionService', 'routes', authService]);
})(angular.module('services'));