(function (app) {
    'use strict';

    function FilmController($scope, data) {
        var vm = this;
        vm.data = data;
    }

    app.controller('FilmController', ['$scope', 'data', FilmController]);
})(angular.module('controllers'));