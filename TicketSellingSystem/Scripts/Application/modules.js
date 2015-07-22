(function () {
    'use strict';

    angular.module('constants', []);
    angular.module('services', ['constants']);
    angular.module('controllers', ['ui.bootstrap', 'services', 'constants']);
    angular.module('filmApp', ['ngRoute', 'controllers', 'services']);
})();