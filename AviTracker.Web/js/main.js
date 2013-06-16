var ngTracker = angular.module("ngTracker", ['ngResource']);

ngTracker.constant('TrackerApiConfig', [
    { name: 'client', url: '/api/client/:clientId', params: { clientId: '@id' } },
    { name: 'project', url: '/api/client/:clientId/project/:projectId', params: { clientId: '@clientId', projectId: '@projectId' } },
    { name: 'task', url: '/api/project/:projectId/project/:projectTaskId', params: { projectId: '@projectId', projectTaskId: '@projectTaskId' } }
]);

ngTracker.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'ClientListCtrl',
            templateUrl: '/templates/client_list.html'
        }).
        when('/new_client', {
            controller: 'ClientNewCtrl',
            templateUrl: '/templates/client_form.html'
        }).
        when('/client/:id', {
            controller: 'ProjectListCtrl',
            templateUrl: '/templates/project_list.html'
        }).
        when('/new_project', {
            controller: 'ProjectNewCtrl',
            templateUrl: '/templates/project_form.html'
        }).
        when('/task/:id', {
            controller: 'TaskListCtrl',
            templateUrl: '/templates/task_list.html'
        });
});
