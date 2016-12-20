angular.module('Repository', []) 
	.service('TodoListItems', ['$http', function ($http) {
	    return {
	        getAll: function () {
	            return $http.get('/api/todos');
	        }
	    };
	}])