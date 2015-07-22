(function(app) {
    'use strict';

    function RegisterController($scope, $rootScope, authService, authEvents) {
        var vm = this;

        vm.user = {};
        vm.errorMessage = '';

        vm.submit = function() {
            authService.register(vm.user).then(function(response) {
                if (response.IsOk) {
                    $rootScope.setCurrentUser(response.Result);
                    $rootScope.$broadcast(authEvents.goToMainPage);
                } else {
                    vm.errorMessage = response.ErrorMessage;
                }
            });
        };

        vm.reset = function() {
            vm.user = {};
        };
    }

    app.controller('RegisterController', ['$scope', '$rootScope', 'authService', 'authEvents', RegisterController]);
})
(angular.module('controllers'));