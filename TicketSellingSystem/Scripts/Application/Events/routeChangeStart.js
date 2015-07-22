(function(app) {
    'use strict';

    app.run(function($rootScope, authEvents, authService, authResolveService) {
        $rootScope.$on('$routeChangeStart', function(event, next) {
            if (next.data) {
                var authorizedRoles = next.data.authorizedRoles;
                if (authorizedRoles !== undefined) {
                    authResolveService.resolve().then(function() {
                        if (!authService.isAuthorized(authorizedRoles)) {
                            event.preventDefault();
                            if (authService.isAuthenticated()) {
                                $rootScope.$broadcast(authEvents.notAuthorized);
                            } else {
                                $rootScope.$broadcast(authEvents.notAuthenticated);
                            }
                        }
                    });
                }
            }
        });
    });
})(angular.module('filmApp'));