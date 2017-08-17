(function(){
    var app = angular.module('BaranofHoldingsApp', ['ngSanitize', 'BaranofHoldingsApp.directives', 'BaranofHoldingsApp.controllers']);

    angular.module('BaranofHoldingsApp.directives', []);
    angular.module('BaranofHoldingsApp.controllers', []);

    //app.run(function ($templateCache, $http) {
    //    $http.get('static/portmodal.html', { cache: $templateCache });
    //    $http.get('static/membermodal.html', { cache: $templateCache });
    //});

	app.filter('split', function () {
	    return function (input, splitChar, splitIndex) {
	        if (splitIndex < 0) {
	            splitIndex = 0;
	        }

	        return input.split(splitChar)[splitIndex];
	    }
	});

	app.factory('myService', function () {
	    var type = '';
	    function updateVal(newType) {
	        type = newType;
	    };
	    return {
	        updateVal: updateVal,
	        getVal: function () {
	            return type;
	        }
	    };
	});
}());