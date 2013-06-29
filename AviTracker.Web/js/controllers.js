
ngTracker.controller("ClientListController", ['$scope', '$routeParams', 'Tracker', function($scope, $routeParams, Tracker) {

    $scope.clients = Tracker.client.query({});

    $scope.removeClient = function(client) {
        if (confirm("Delete this client? There is no undo.")) {
            Tracker.client.remove({ id: client.clientId });
            $scope.clients.splice($scope.clients.indexOf(client, 1));
        }

    };

}]);

ngTracker.controller("ClientNewController", function($scope, $routeParams, $location, Tracker) {
    $scope.client = new Tracker.client();

    $scope.save = function() {
        var client = $scope.client;
        Tracker.client.save(client, function() {
            $location.path('/');
        });
    };

    $scope.reset = function() {
        $location.path('/');
    };

});

ngTracker.controller("ClientEditController", function($scope, $routeParams, $location, Tracker, Context) {
    Context.clientId = $routeParams.clientId;
    $scope.client = Tracker.client.get({ clientId: $routeParams.clientId });
    $scope.save = function() {
        Tracker.client.update({ clientId: Context.clientId }, $scope.client, function() {
            $location.path('/');
        });
    };

});

ngTracker.controller('ProjectListController', function($scope, $routeParams, $location, Tracker, Context) {
    $scope.isLoaded = false;
    Context.clientId = $routeParams.clientId;
    $scope.clientId = $routeParams.clientId;
    $scope.client = Tracker.client.get({ clientId: $routeParams.clientId }, function(result) {
        $scope.isLoaded = true;
        Context.client = result;
    });

    $scope.removeProject = function(project) {
        if (confirm("Delete this project? There is no undo.")) {
            Tracker.project.remove({ clientId: Context.clientId, projectId: project.projectId });
            $scope.client.projects.splice($scope.client.projects.indexOf(project, 1));
        }

    };
});

ngTracker.controller('ProjectNewController', function($scope, $routeParams, $location, Tracker, Context) {
    $scope.project = new Tracker.project();
    $scope.isLoaded = true;
    $scope.clientId = $routeParams.clientId;

    $scope.save = function() {
        var clientId = $routeParams.clientId;
        var project = $scope.project;
        project.clientId = clientId;
        Tracker.project.save({ clientId: $scope.clientId }, project, function() {
            $location.path('/client/' + clientId);
        });
    };
});

ngTracker.controller('ProjectEditController', function($scope, $routeParams, $location, Tracker, Context) {
    $scope.isLoaded = false;
    $scope.clientId = $routeParams.clientId;
    Context.clientId = $routeParams.clientId;
    $scope.projectId = $routeParams.projectId;
    Context.projectId = $routeParams.projectId;
    $scope.project = Tracker.project.get({ clientId: $scope.clientId, projectId: $scope.projectId }, function() {
        $scope.isLoaded = true;
    });

    $scope.save = function() {
        Tracker.project.update({ clientId: $scope.clientId, projectId: $scope.projectId }, $scope.project, function() {
            Context.projectId = 0;
            $location.path('/client/' + $scope.clientId);
        });
    };

    $scope.cancel = function() {
        location.path('/client/' + $scope.clientId);
    };
});


ngTracker.controller('TaskListController', function($scope, $routeParams, $location, Tracker, Context, $q) {
    var clientDeffer = $q.defer(),
        loadTasks = function() {
            $scope.project = Tracker.project.get({ clientId: $scope.clientId, projectId: $scope.projectId }, function() {
                $scope.isLoaded = true;
            });
        };

    $scope.client = Context.client;
    $scope.clientId = $routeParams.clientId;
    $scope.projectId = $routeParams.projectId;
    $scope.isLoaded = false;

    if ($scope.client === null) {
        Tracker.client.get({ clientId: $scope.clientId }, function(result) {
            $scope.client = result;
            clientDeffer.resolve();
        });
        $q.all([clientDeffer.promise]).then(function() {
            loadTasks();
        });
    } else {
        loadTasks();
    }
});

ngTracker.controller('TaskFormController',['$scope', '$routeParams', '$location', 'Tracker', 'Context', '$q',
    function ($scope, $routeParams, $location, Tracker, Context, $q) {

        var deferTypes = $q.defer(),
            deferStatuses = $q.defer();

        var loadNewTask = function() {
            $scope.task = new Tracker.task();
            $scope.isLoaded = true;
        },
            loadSelectedTask = function() {
                $scope.task = Tracker.task.get({ projectId: $scope.projectId, taskId: $scope.taskId },function() {
                    $scope.isLoaded = true;
                });
                
            };

        $scope.clientId = $routeParams.clientId;
        $scope.projectId = $routeParams.projectId;
        $scope.taskId = $routeParams.taskId;
        $scope.taskTypes = Context.taskTypes;
        $scope.statuses = Context.statuses;
        $scope.reset = function() {
            $location.path('/client/' + $scope.clientId +'/project/' + $scope.projectId +'/tasks');
        };
        
        if ($scope.taskTypes === null) {
            Tracker.type.query({}, function(result) {
                $scope.taskTypes = result;
                Context.taskTypes = result;
                deferTypes.resolve();
            });
        } else {
            deferTypes.resolve();
        }
        
        if ($scope.statuses === null) {
            Tracker.status.query({}, function(result) {
                $scope.statuses = result;
                Context.statuses = result;
                deferStatuses.resolve();
            });
        } else {
            deferStatuses.resolve();
        }


        $q.all([
            deferTypes.promise,
            deferStatuses.promise
        ]).then(function () {
            if ($scope.taskId === undefined) {
                loadNewTask();
            } else {
                loadSelectedTask();
            }
            
        });

    }]);