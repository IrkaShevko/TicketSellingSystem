(function (app) {
    'use strict';

    function MainController($scope, authService, initialData) {
        var vm = this;
        vm.films = initialData.films;
        vm.date = new Date();
        vm.clear = function () {
            vm.date = null;
        };
    }

    app.controller('MainController', ['$scope', 'authService', 'initialData', MainController]);
})(angular.module('controllers'));