(function (app) {
    'use strict';

    app.config(function($httpProvider) {
            $httpProvider.interceptors.push([
                '$injector',
                function($injector) {
                    return $injector.get('AuthInterceptor');
                }
            ]);
        })
        .factory('AuthInterceptor', function($rootScope, $q, authEvents) {
            return {
                responseError: function (response) {
                    $rootScope.$broadcast({
                        401: authEvents.notAuthenticated,
                        403: authEvents.notAuthorized
                    }[response.status], response);
                    return $q.reject(response);
                }
            };
        });
})(angular.module('filmApp'));