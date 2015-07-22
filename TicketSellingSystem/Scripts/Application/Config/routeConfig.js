(function(app) {
    'use strict';

    function routeConfig($locationProvider, $routeProvider, roles, constants) {
        $locationProvider.html5Mode(true);
        $routeProvider
            .when('/Register', {
                controller: 'RegisterController as register',
                templateUrl: '/Scripts/Application/Views/Register.tmpl.html'
            })
            .when('/Login', {
                controller: 'LoginController as login',
                templateUrl: '/Scripts/Application/Views/Login.tmpl.html'
            })
            .when('/Film/:filmId', {
                controller: 'FilmController as film',
                templateUrl: '/Scripts/Application/Views/FilmInfo.tmpl.html',
                resolve: {
                    data: [
                        '$route', 'filmLoadingService', function($route, filmLoadingService) {
                            return filmLoadingService.loadFilm($route.current.params.filmId);
                        }
                    ]
                }
            })
            .when('/Admin/Users', {
                controller: 'AdminUserController as admin',
                templateUrl: '/Scripts/Application/Views/Admin.Users.tmpl.html',
                data: {
                    authorizedRoles: roles.Admin
                },
                resolve: {
                    users: [
                        'userLoadingService', function(userLoadingService) {
                            return userLoadingService.getUsers(constants.firstPage);
                        }
                    ]
                }
            })
            .when('/Admin/Cinemas', {
                controller: 'AdminCinemaController as admin',
                templateUrl: '/Scripts/Application/Views/Admin.Cinemas.tmpl.html',
                data: {
                    authorizedRoles: roles.Admin
                },
                resolve: {
                    cinemas: [
                        'cinemaLoadingService', function(cinemaLoadingService) {
                            return cinemaLoadingService.getCinemas(constants.firstPage);
                        }
                    ]
                }
            })
            .when('/', {
                templateUrl: '/Scripts/Application/Views/Main.tmpl.html',
                controller: 'MainController as main',
                resolve: {
                    initialData: [
                        'mainLoadingService', function(mainLoadingService) {
                            return mainLoadingService.loadData();
                        }
                    ]
                }
            }).otherwise({
                redirectTo: '/'
            });
    }

    app.config(['$locationProvider', '$routeProvider', 'roles', 'constants', routeConfig]);
})(angular.module('filmApp'));