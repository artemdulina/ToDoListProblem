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
                    console.log(objectsFromJson[i]);
                } 
            }), function () {
                // remove it
                alert("Something went wrong in TodoListItems.getAll function.");
            }
        }

        Init();

        $scope.getStatus = function () {
            console.log("Todo list status:");
            for (var i = 0; i < $scope.todoList.length; i++)
                console.log($scope.todoList[i]);
        }

        $scope.createEmptyTodo = function () {
            var todo = { ToDoId: 0, UserId: 0, IsCompleted: false, Name: "" };
            $scope.todoList.push(todo);
        }

        $scope.saveChanges = function (index, todoId) {

            var todo = { ToDoId: todoId, UserId: $scope.todoList[index].UserId, IsCompleted: $scope.todoList[index].IsCompleted, Name: $scope.todoList[index].Name };
            var data = { "ToDoId": todoId, "UserId": $scope.todoList[index].UserId, "IsCompleted": $scope.todoList[index].IsCompleted, "Name": $scope.todoList[index].Name };
            $scope.todoList[index].isEdit = false;

            if (todo.ToDoId != 0) {
                $http.put(
                '/api/todos',
                JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json' }
                }
            ).then(function (response) {
                // remove it
                console.log("A new todo item was successfully sent.");
            },
                function () {
                    // remove it
                    console.log("SubmitNewTodo(). Something went wrong.");
                });
            }
            else
            {
                //$scope.todoList.push(todo);

                $http.post(
                '/api/todos',
                JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json' }
                }
            ).then(function (response) {
                // remove it
                console.log("A new todo item was successfully sent.");
                $scope.todoList[index].isEdit = false;
            },
                function () {
                    // remove it
                    console.log("SubmitNewTodo(). Something went wrong.");
                });
            }
        }

        $scope.deleteTodo = function (index, todoId) {
            $scope.todoList.splice(index, 1);

            $http.delete('/api/todos/' + todoId)
            .then(function (response) {
                // remove it
                console.log("Todo was successfully deleted.");
            },
                function () {
                    // remove it
                    console.log("Something went wrong in deleteTodo function.");
                });
        }

    }]);

})();