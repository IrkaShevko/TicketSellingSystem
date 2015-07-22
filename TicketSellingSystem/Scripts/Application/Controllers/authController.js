(function(app) {
    'use strict';

    function AuthController($scope, $rootScope, authService, roles, authEvents) {
        var vm = this;
        vm.currentUser = null;
        vm.isAuthorized = authService.isAuthorized;
        vm.roles = roles;
        vm.logOff = function() {
            $rootScope.setCurrentUser(null);
            authService.logOff();
            $rootScope.$broadcast(authEvents.goToMainPage);
        };

        $rootScope.setCurrentUser = function(user) {
            vm.currentUser = user;
        };

        $rootScope.getCurrentUser = function () {
            return vm.currentUser;
        };
    }

    app.controller('AuthController', ['$scope', '$rootScope', 'authService', 'roles', 'authEvents', AuthController]);
})
(angular.module('controllers'));