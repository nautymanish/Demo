'use strict';
app.factory('qaService', ['$http','authService', function ($http,authService) {

    var serviceBase = '/';
    var qaServiceFactory = {};

    var _getQa = function () {

        return $http.get(serviceBase + 'api/').then(function (results) {
            return results;
        });
    };

    var _saveQuestion = function (question) {
        question.AspNetUserId = authService.authentication.userUniqueId;
        return $http.post(serviceBase + 'api/question/submitquestion', question).then(function (results) {
            return results;
        });
    }

    var _getQuestionList = function () {
        return $http.get(serviceBase + 'api/question/listquestion').then(function (results) {
            return results;
        });
    };

    var _logout = function ()
    {
        authService.logOut();
    };

    var _saveAnswer = function (answer) {
        answer.AspNetUserId = authService.authentication.userUniqueId;
        return $http.post(serviceBase + 'api/question/submitanswer', answer).then(function (results) {
            return results;
        });
    };
    qaServiceFactory.getQa = _getQa;
    qaServiceFactory.saveQuestion = _saveQuestion;
    qaServiceFactory.getQuestionList = _getQuestionList;
    qaServiceFactory.logout = _logout;
    qaServiceFactory.saveAnswer = _saveAnswer;
    return qaServiceFactory;

}]);