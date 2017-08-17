(function () {
    angular.module('BaranofHoldingsApp.directives').directive('openPort', ['$compile', '$timeout', function ($compile, $timeout) {
        return {
            restrict: 'A',
            link: function (scope, instanceElement, attributes) {
                instanceElement.on('click', function () {
                    angular.element(document.getElementById('modal-area')).children().remove();
                    var el = $compile('<modal-port></modal-port>')(scope);
                    angular.element(document.getElementById('modal-area')).append(el);
                    var ele = $(this);
                    $timeout(function () {
                        scope.getPort(ele.attr('id'));
                        $('#myPortModal').modal('show');
                    }, 50);
                });
            }
        }
    }]);

    angular.module('BaranofHoldingsApp.directives').directive('modalPort', ['$templateCache', function ($templateCache) {
        return {
            restrict: 'E',
            templateUrl: '/static/portmodal.html'
        }
    }]);
}());