(function (app) {
    'use strict';

    function AdminCinemaController($scope, $modal, cinemas, adminCinemaService, cinemaLoadingService, routes, constants, errorMessages) {
        var vm = this;
        vm.cinemas = cinemas;
        vm.currentPage = constants.firstPage;
        vm.onePage = vm.cinemas.Count / vm.cinemas.CountPerPage <= 1;
        vm.delete = function (index) {
            adminCinemaService.deleteCinema(vm.cinemas.Items[index].Id);
            vm.cinemas.Items.splice(index, 1);
        };

        vm.saveCinema = function (data, id, index) {
            angular.extend(data, { Id: id });
            adminCinemaService.editCinema(data).then(
                function (id) {
                    if (id !== 0) {
                        vm.cinemas.Items[index].Id = id;
                    }
                });
        };

        vm.checkCinemaName = function (name, id) {
            if (!name)
                return errorMessages.EmptyField;
            return adminCinemaService.getCinemaByName(name).then(function (cinema) {
                if (cinema && cinema.Id !== id)
                    return errorMessages.NameExists;
            });
        };

        vm.checkCinemaAddress = function (address, id) {
            if (!address)
                return errorMessages.EmptyField;
            return adminCinemaService.getCinemaByAddress(address).then(function (cinema) {
                if (cinema && cinema.Id !== id)
                    return errorMessages.AddressExists;
            });
        };

        vm.isEmpty = function () {
            return vm.cinemas.Items.length === 0;
        };

        vm.maxId = function () {
            var id = 0;
            for (var i = 0, length = vm.cinemas.Items.length; i < length; i++) {
                var currId = vm.cinemas.Items[i].Id;
                if (currId > id)
                    id = currId;
            }
            return id;
        }

        vm.pageChanged = function () {
            cinemaLoadingService.getCinemas(vm.currentPage)
                .then(function (response) {
                    vm.cinemas = response;
                });
        };

        vm.addCinema = function () {
            $scope.inserted = {
                LogoPath: null,
                Name: '',
                Address: '',
                Id: 0
            }
            vm.cinemas.Items.push($scope.inserted);
        };

        vm.checkIsNewRow = function (index) {
            if (!vm.cinemas.Items[index].Name || !vm.cinemas.Items[index].Address) {
                if (vm.cinemas.Items[index].Id === 0) {
                    vm.cinemas.Items.splice(index, 1);
                    return false;
                }
            }
            return true;
        };

        vm.createFileUploadDialog = function (filmId) {
            var modalInstance = $modal.open({
                templateUrl: routes.Modal,
                controller: 'ModalInstanceController as modal',
                windowClass: 'animated',
                resolve: {
                    filmId: function () {
                        return filmId;
                    }
                }
            });
        }

        vm.uploadSuccess = function () {

        }
    }

    app.controller('AdminCinemaController', ['$scope', '$modal', 'cinemas', 'adminCinemaService', 'cinemaLoadingService', 'routes', 'constants', 'errorMessages', AdminCinemaController]);
})
(angular.module('controllers'));