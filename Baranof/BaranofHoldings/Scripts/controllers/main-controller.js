(function(){
    angular.module('BaranofHoldingsApp.controllers').controller('mainController', ['$scope', '$anchorScroll', function ($scope, $anchorScroll) {
        $scope.gotoAnchor = function(anchor) {
            $anchorScroll(anchor);
        }
	}]);
}());