(function (app) {
    'use strict';

    function sessionService() {
        var serv = this;
        serv.create = function (userName, userRoles) {
            serv.userName = userName;
            serv.userRoles = userRoles;
        };
        serv.destroy = function () {
            serv.userName = null;
            serv.userRoles = null;
        };
    };

    app.service('sessionService', [sessionService]);
})(angular.module('services'));