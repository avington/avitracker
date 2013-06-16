ngTracker.constant('TrackerApiConfig', [
    { name: 'client', url: '/api/client/:clientId', params: { clientId: '@id' } },
    { name: 'taskType', url: '/api/tasktype/:taskTypeId', params: { taskTypeId: '@id' } },
    { name: 'project', url: '/api/client/:clientId/project/:projectId', params: { clientId: '@clientId', projectId: '@projectId' } },
    { name: 'task', url: '/api/project/:projectId/project/:projectTaskId', params: { projectId: '@projectId', projectTaskId: '@projectTaskId' } }
]);


ngTracker.provider('Tracker', function (TrackerApiConfig) {
    //configuration
    var resourceItems = TrackerApiConfig;

    //injection
    this.$get = function ($resource) {
        var result = {};
        _.each(resourceItems, function (resource) {
            result[resource.name] = $resource(resource.url, resource.params, { 'update': { method: 'PUT' } });
        });
        return result;
    };
});

ngTracker.factory('Context', function () {
    return {
        clientId: 0,
        projectId: 0,
        projectTaskId: 0,
        taskTypes: {}
    };
});