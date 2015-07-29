'use strict';
app.controller('qaCtrl', ['$scope', 'qaService', function ($scope, qaService) {
    $scope.qa = { Text: ""};
    $scope.answer = {};
    
    $scope.message = '';
    //qaService.getQa().then(function (results) {

    //    $scope.qa = results.data;

    //}, function (error) {
    //    //alert(error.data.message);
    //});

    $scope.submitQuestion = function () {
        qaService.saveQuestion($scope.qa).then(function (response) {

                $scope.message = "Question submitted successfully.";
                $scope.qa.Text = '';

            },
         function (response) {
              $scope.message = "Failed to save question.";
         });
            

    };

    $scope.getQuestions = function () {
        qaService.getQuestionList().then(function (response) {

            $scope.qmessage = "List loaded";
            $scope.questions = response.data;

        },
         function (response) {
             $scope.qmessage = "Failed to load questions.";
         });
    };
    $scope.logout = function () {
        qaService.logout();
    };

    $scope.submitAnswer = function (id) {
        var answer = { QuestionId: id, Text: $scope.answer.Text };
        qaService.saveAnswer(answer).then(function (response) {

            $scope.message = "Question submitted successfully.";
            $scope.qa.Text = '';

        },
         function (response) {
             $scope.message = "Failed to save question.";
         });

    };
}]);