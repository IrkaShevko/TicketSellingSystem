(function(app) {
    'use strict';

    app.run([
        '$rootScope', 'authService', 'sessionService', function($rootScope, authService, sessionService) {
            authService.getCurrentUser().then(function(user) {
                $rootScope.setCurrentUser(user);
                if (user)
                    sessionService.create(user.Name, user.Roles);
            });
        }
    ]);
})(angular.module('filmApp'));