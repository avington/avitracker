ngTracker.provider('Tracker', function(TrackerApiConfig) {
    //configuration
    var resourceItems = [
        { name: 'client', url: '/api/client/:clientId', params: { clientId: '@clientId' } },
        { name: 'project', url: '/api/client/:clientId/project/:projectId', params: { clientId: '@clientId', projectId: '@projectId' } },
        { name: 'task', url: '/api/project/:projectId/task/:taskId', params: { projectId: '@projectId', taskId: '@taskIsd' } },
        { name: 'type', url: '/api/tasktype/:taskTypeId', params: { taskTypeId: '@id' } },
        { name: 'status', url: '/api/status/:statusId', params: { statusId: '@Id' } }
    ];

    //injection
    this.$get = function($resource) {
        var result = {};
        _.each(resourceItems, function(resource) {
            result[resource.name] = $resource(resource.url, resource.params, { update: { method: 'PUT' } });
        });
        return result;
    };
});


ngTracker.factory('Context', function() {
    return {
        clientId: 0,
        projectId: 0,
        projectTaskId: 0,
        client: null,
        project: null,
        task: null,
        timesheet: null,
        taskTypes: null,
        statuses: null
    };
});