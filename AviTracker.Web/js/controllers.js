
ngTracker.controller("ClientListCtrl", function ($scope, $routeParams, Tracker) {

    $scope.clients = Tracker.client.query({}, isArray = true);

    $scope.removeClient = function (client) {
        if (confirm("Delete this client? There is no undo.")) {
            Tracker.client.remove({ id: client.clientId });
            $scope.clients.splice($scope.clients.indexOf(client, 1));
        }

    };

});

ngTracker.controller("ClientNewCtrl", function ($scope, $routeParams, $location, Tracker) {
    $scope.client = new Tracker.client();

    $scope.save = function () {
        var client = $scope.client;
        Tracker.client.save(client, function () {
            $location.path('/');
        });
    };

    $scope.reset = function () {
        $location.path('/');
    };

});

ngTracker.controller('ProjectListCtrl', function ($scope, $routeParams, $location, Tracker, Context) {
    Context.clientId = $routeParams.id;
    $scope.client = Tracker.client.get({ clientId: $routeParams.id });

    $scope.removeProject = function (project) {
        if (confirm("Delete this project? There is no undo.")) {
            Tracker.project.remove({ clientId: Context.clientId, projectId: project.projectId });
            $scope.client.projects.splice($scope.client.projects.indexOf(project, 1));
        }

    };
});

ngTracker.controller('ProjectNewCtrl', function ($scope, $routeParams, $location, Tracker, Context) {
    $scope.project = new Tracker.project();

    $scope.save = function () {
        var clientId = Context.clientId;
        var project = $scope.project;
        project.clientId = clientId;
        Tracker.project.save(project, function () {
            $location.path('/client/' + clientId);
        });
    };
});

ngTracker.controller('TaskListCtrl', function ($scope, $routeParams, $location, Tracker, Context) {
    Context.projectId = $routeParams.id;
    $scope.project = Tracker.project.get({ clientId: Context.clientId, projectId: $routeParams.id });
});

ngTracker.controller('TaskTypeController', function($scope, $routeParams, $locaton, Tracker, Context) {
    Context.taskTypes = Tracker.taskTypes.query({}, isArray = true);
});