var ngTracker = angular.module("ngTracker", ['ngResource']);

ngTracker.constant('TrackerApiConfig', [
    { name: 'client', url: '/api/client/:clientId', params: { clientId: '@id' } },
    { name: 'project', url: '/api/client/:clientId/project/:projectId', params: { clientId: '@clientId', projectId: '@projectId' } },
    { name: 'task', url: '/api/project/:projectId/project/:projectTaskId', params: { projectId: '@projectId', projectTaskId: '@projectTaskId' } }
]);

ngTracker.config(function($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'ClientListController',
            templateUrl: '/templates/client_list.html'
        }).
        when('/new_client', {
            controller: 'ClientNewController',
            templateUrl: '/templates/client_form.html'
        })
        .when('/edit_client/:clientId', {
            controller: 'ClientEditController',
            templateUrl: '/templates/client_form.html'
        }).
        when('/client/:clientId', {
            controller: 'ProjectListController',
            templateUrl: '/templates/project_list.html'
        }).
        when('/client/:clientId/new_project', {
            controller: 'ProjectNewController',
            templateUrl: '/templates/project_form.html'
        }).
        when('/client/:clientId/edit_project/:projectId', {
            controller: 'ProjectEditController',
            templateUrl: '/templates/project_form.html'
        }).
        when('/client/:clientId/project/:projectId/tasks', {
            controller: 'TaskListController',
            templateUrl: '/templates/task_list.html'
        })
        .when('/client/:clientId/project/:projectId/new_task', {
            controller: 'TaskFormController',
            templateUrl: '/templates/task_form.html'
        })
        .when('/client/:clientId/project/:projectId/edit_task/:taskId', {
            controller: 'TaskFormController',
            templateUrl: '/templates/task_form.html'
        })
        .otherwise({ redirectTo: '/' });
});