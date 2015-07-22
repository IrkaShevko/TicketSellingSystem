(function(app) {
    'use strict';

    function authResolveService( $rootScope, $q, authService, sessionService) {
        var serv = this;
        serv.resolve = function () {
            var user = $rootScope.getCurrentUser();
            if (!user) {
                return authService.getCurrentUser().then(function(user) {
                    $rootScope.setCurrentUser(user);
                    if (user) {
                        sessionService.create(user.Name, user.Roles);
                    }
                });
            } else {
                return $q.resolve(user);
            }
        };
    }

    app.service('authResolveService', ['$rootScope', '$q', 'authService', 'sessionService', authResolveService]);
})(angular.module('services'));