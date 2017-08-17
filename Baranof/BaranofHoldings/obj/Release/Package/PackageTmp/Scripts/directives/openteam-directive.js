(function () {
    angular.module('BaranofHoldingsApp.directives').directive('openTeam', ['$compile', '$timeout', function ($compile, $timeout) {
        return {
            restrict: 'A',
            link: function (scope, instanceElement, attributes) {
                instanceElement.on('click', function () {
                    angular.element(document.getElementById('modal-area')).children().remove();
                    var el = $compile('<modal-team></modal-team>')(scope);
                    angular.element(document.getElementById('modal-area')).append(el);
                    var ele = $(this);
                    $timeout(function () {
                        scope.getMember(ele.attr('id'));
                        $('#myModal').modal('show');
                    }, 50);
                });
            }
        }
    }]);

    angular.module('BaranofHoldingsApp.directives').directive('modalTeam', ['$templateCache', function ($templateCache) {
        return {
            restrict: 'E',
            templateUrl: '/static/membermodal.html'
        }
    }]);
}());