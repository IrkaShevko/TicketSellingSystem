(function(app) {
    'use strict';

    function AdminUserController($scope, users, adminUserService, userLoadingService, constants) {
        var vm = this;
        vm.users = users;
        vm.currentPage = constants.firstPage;
        vm.delete = function(email) {
            adminUserService.deleteUser(email);
            for (var i = 0, length = vm.users.Items.length; i < length; i++) {
                if (vm.users.Items[i].Email === email) {
                    vm.users.Items.splice(i, 1);
                    break;
                }
            }
        };

        vm.block = function(email) {
            for (var i = 0, length = vm.users.Items.length; i < length; i++) {
                if (vm.users.Items[i].Email === email) {
                    vm.users.Items[i].Blocked = !vm.users.Items[i].Blocked;
                    adminUserService.blockUser(email, vm.users.Items[i].Blocked);
                    break;
                }
            }
        };

        vm.isEmpty = function() {
            return vm.users.length === 0;
        };

        vm.pageChanged = function() {
            userLoadingService.getUsers(vm.currentPage)
                .then(function(response) {
                    vm.users = response;
                });
        };
    }

    app.controller('AdminUserController', ['$scope', 'users', 'adminUserService', 'userLoadingService', 'constants', AdminUserController]);
})(angular.module('controllers'));