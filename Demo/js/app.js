
'use strict';

var app = angular.module('demoApp', ['ngRoute','LocalStorageModule']);
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: 'AngularViews/Login.html', controller: 'loginCtrl' });
    $routeProvider.when('/register', { templateUrl: 'AngularViews/Register.html', controller: 'signupController' });
    $routeProvider.otherwise({ redirectTo: '/' });
    $routeProvider.when("/qa", {
        controller: "qaCtrl",
        templateUrl: "AngularViews/qa.html"
    });

}]);


app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
