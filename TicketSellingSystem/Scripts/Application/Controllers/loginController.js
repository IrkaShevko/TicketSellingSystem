(function (app) {
    'use strict';

    function LoginController($scope, $rootScope, authService, authEvents) {
        var vm = this;
        vm.user = {};
        vm.errorMessage = '';

        vm.submit = function() {
            authService.logIn(vm.user).then(function (response) {
                if (response.IsOk) {
                    $scope.setCurrentUser(response.Result);
                    $rootScope.$broadcast(authEvents.goToMainPage);
                } else {
                    vm.errorMessage = response.ErrorMessage;
                }
            });
        }
    }
    app.controller('LoginController', ['$scope', '$rootScope', 'authService', 'authEvents', LoginController]);
})(angular.module('controllers'));