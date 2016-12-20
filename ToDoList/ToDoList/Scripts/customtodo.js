(function () {
    var todoListModule = angular.module('TodoList', ['Repository']);

    todoListModule.controller('TodoListController', ['$scope', '$http', 'TodoListItems', function ($scope, $http, TodoListItems) {

        $scope.todoList = [];
        $scope.isVisiblePopup = false;

        function Init() {
            TodoListItems.getAll().then(function (response) {
                var objectsFromJson = response.data;

                for (var i = 0; i < objectsFromJson.length; i++) {
                    $scope.todoList.push(objectsFromJson[i]);
                }
                    
            }), function () {
                // fix
                alert("Something went wrong in TodoListItems.getAll function.");
            }
        }

        Init();

        $scope.showPopup = function () {
            $scope.isVisiblePopup = true;
        }

        $scope.hidePopup = function () {
            $scope.isVisiblePopup = false;
        }

        $scope.submitNewTodo = function () {
            // fix
            var todo = { "ToDoId": 0, "UserId": 0, "IsCompleted": $scope.isCompleted, "Name": $scope.name };
            $scope.todoList.push(todo);
            $scope.isVisiblePopup = false;

            var data = { "isCompleted": $scope.isCompleted, "Name": $scope.name };

            $http.post(
                '/api/todos',
                JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json' }
                }
            ).then(function (response) {
                // fix
                console.log("A new todo item was successfully sent.");
                //console.log("Response data from service: ");
                //console.log(response.data);
            },
                function () {
                    // fix
                    console.log("SubmitNewTodo(). Something went wrong.");
                });
        }

        $scope.deleteTodo = function (index, todoId) {
            $scope.todoList.splice(index, 1);

            $http.delete('/api/todos/' + todoId)
            .then(function (response) {
                // fix
                console.log("Todo was successfully deleted.");
            },
                function () {
                    // fix
                    console.log("Something went wrong in deleteTodo function.");
                });
        }

    }]);

})();