angular.module("todolist", [])
    /*.directive("oneIce", function () {
        return {
            restrict: "E",
            template: "<span>just smile {{mysrc}}</span>",
            scope: { mysrc: "=" }
        };
    })*/
    .controller("todoforms", [
        "$scope", "$http",
        function ($scope, $http) {

            $scope.todoforms = [];

            $scope.removeTask = function (parentIndex, index) {
                $scope.todoforms[parentIndex].Tasks.splice(index, 1);
            };

            $scope.createForm = function () {
                var empty = {
                    Title: "Enter title here",
                    Author: {
                        FirstName: "",
                        LastName: ""
                    },
                    Tasks: [{
                        Content: ""
                    }]
                }
                $http.put("/api/todolist/", empty)
                .then(function (responce) {
                    //change id
                    
                    $scope.todoforms.unshift(empty);
                });
            };

            $scope.deleteForm = function (databaseIndex, onPageIndex) {
                var answer = confirm("Do you really want to delete this form?");

                if (answer) {
                    $http.delete("/api/todolist/" + databaseIndex)
                        .then(function (response) {
                            $scope.todoforms.splice(onPageIndex, 1);
                            console.dir(response);
                        });
                }
            };

            $scope.addTask = function (currentFormIndex) {
                $scope.todoforms[currentFormIndex].Tasks.push({
                    Content: ""
                })
            };

            function init() {
                $http.get("/api/todolist/").then(function (response) {
                    $scope.todoforms = response.data;
                    console.dir($scope.todoforms);
                });
            };

            init();
        }
    ])