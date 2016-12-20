(function () {
    var todoListModule = angular.module('TodoList', ['Repository']);

    todoListModule.controller('TodoListController', ['$scope', '$http', 'TodoListItems', function ($scope, $http, TodoListItems) {

        $scope.todoList = [];
        $scope.isVisiblePopup = false;

        function Init() {
            TodoListItems.getAll().then(function (response) {
                var objectsFromJson = response.data;

                console.log("The received data from cloud: ");

                for (var i = 0; i < objectsFromJson.length; i++) {
                    $scope.todoList.push(objectsFromJson[i]);
                    console.log(objectsFromJson[i]);
                }
                    
            }), function () {
                alert("Something went wrong.");
            }
        }

        Init();

        $scope.showPopup = function () {
            $scope.isVisiblePopup = true;
        }

        $scope.hidePopup = function () {
            $scope.isVisiblePopup = false;
        }

        $scope.submitNewTask = function () {
            console.log("Is completed: " + $scope.isCompleted);
            console.log("Name: " + $scope.name);

            var data = { "isCompleted": $scope.isCompleted, "Name": $scope.name };

            $http.post(
                '/api/todos',
                JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json' }
                }
            ).then(function (response) {
                console.log("A new todo item was successfully sent.");
                console.log(response.data);
                $scope.todoList.push(response.data);
            },
                function () {
                    console.log("Something went wrong.");
                });
        }

    }]);

})();