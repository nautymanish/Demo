﻿'use strict';
app.controller('loginCtrl', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

            $location.path('/qa');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

}]);