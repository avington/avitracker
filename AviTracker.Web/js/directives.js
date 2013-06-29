

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

ngTracker.directive('aviDatepicker', function () {
    return {
        restrict: 'A',
        require: '?ngModel',
        scope: {
            select: '&'
        },
        link: function(scope, element, attrs, ngModel) {
            if (!ngModel) return;
            var optionsObj = {};
            optionsObj.dateFormat = 'mm/dd/yy';
            var updateModel = function(dateTxt) {
                scope.$apply(function() {
                    ngModel.$setViewValue(dateTxt);
                });
            };

            optionsObj.onSelect = function(dateTxt, picker) {
                updateModel(dateTxt);
                if (scope.select) {
                    scope.$apply(function() {
                        scope.select({ date: dateTxt });
                    });
                }
            };

            ngModel.$render = function() {
                element.datepicker('setDate', ngModel.$viewValue || '');
            };

            element.datepicker(optionsObj);

        }
        
    };
});