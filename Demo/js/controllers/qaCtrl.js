
'use strict';
app.controller('qaCtrl', ['$scope', 'qaService', function ($scope, qaService) {
    $scope.qa = { Text: "" };
    //$scope.answer = { QuestionId: '', Text: '', QuestionText:'' };
        
    $scope.message = '';
    
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
            $scope.answers=[];
                 
             for (var quest in response.data) {
                            
                 $scope.answers.push(({ QuestionId: response.data[quest].id, QuestionText: response.data[quest].text, Text: '' }));
              
            }

        },
         function (response) {
             $scope.qmessage = "Failed to load questions.";
         });
    };
    $scope.logout = function () {
        qaService.logout();
    };

    $scope.submitAnswer = function (id) {
        var answer = { QuestionId: id.QuestionId, Text: id.Text };
        qaService.saveAnswer(answer).then(function (response) {

            $scope.message = "Question submitted successfully.";
            $scope.qa.Text = '';

        },
         function (response) {
             $scope.message = "Failed to save question.";
         });

    };
}]);