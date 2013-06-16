

ngTracker.directive("removeButton", function () {
    return {
        restrict: "E",
        replace: true,
        scope: {
            text: "@",
            action: "&"
        },
        template: "<button class='btn btn-danger' ng-click='action()'><i class='icon-remove-circle icon-2'></i> {{text}}</button>"
    };
});