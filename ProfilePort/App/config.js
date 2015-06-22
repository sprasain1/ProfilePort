﻿
(function () {

    // configure the routing for the site.
    angular.module('app').config(['$routeProvider', '$locationProvider', '$httpProvider', '$logProvider',
        function ($routeProvider, $locationProvider, $httpProvider, $logProvider) {

            $logProvider.debugEnabled(true);

            $locationProvider.html5Mode(false);


            // Routing structure.
            $routeProvider
                // configure the base level site pages.
               
                .when('/profile/:id?', { templateUrl: 'app/profile/partials/profile.html', controller: 'profileCtrl' })
                .when('/404', { templateUrl: 'app/common/partials/404.html', controller: 'co404Ctrl' })
                .when('/note', { templateUrl: 'app/note/partials/note.html', controller: 'coDeniedCtrl' })
                .when('/message/:id?', { templateUrl: 'app/message/partials/message.html', controller: 'messageCtrl' })
                .when('/', { redirectTo: 'profile' })

                // otherwise redirect to the 404 error page
                .otherwise({ redirectTo: 'profile' });


            // Http Settings
            $httpProvider.defaults.withCredentials = true;

            // alternatively, register the interceptor via an anonymous factory
            $httpProvider.interceptors.push(['$location', '$q', '$rootScope', function ($location, $q, $rootScope) {
                return {
                    'request': function (config) {

                        return config;
                    },

                    'response': function (response) {
                        return response;
                    },
                    'responseError': function (response) {
                        // request was unauthenticated, redirect away.
                        if (response.status === 401) {

                            if ($location.$$path.indexOf("/login") === 0) {
                                // do nothing when you're on the login page, without this line the site will lockup
                            }
                            else {
                                var expectedUrl = encodeURIComponent(window.location.hash.replace("#", ""));
                          }
                            return $q.reject(response);
                        }
                        $rootScope.$broadcast('httpResponseError', { response: response });

                        return $q.reject(response);
                    }
                };
            }]);


        }]);
}());