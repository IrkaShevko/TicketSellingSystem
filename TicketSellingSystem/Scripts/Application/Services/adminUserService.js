(function(app) {
    'use strict';

    function adminUserService($http, routes) {
        var serv = this;
        serv.deleteUser = function(email) {
            return $http.post(routes.DeleteUser, {email:email});
        };

        serv.blockUser = function (email, block) {
            return $http.post(routes.BlockUser, {
                Email: email,
                Blocked: block
            });
        }
    }

    app.service('adminUserService', ['$http', 'routes', adminUserService]);
})(angular.module('services'));