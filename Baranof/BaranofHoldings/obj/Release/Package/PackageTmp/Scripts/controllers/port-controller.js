(function () {
    angular.module('BaranofHoldingsApp.controllers').controller('tabController', ['$scope', 'myService', function ($scope, myService) {
        var tab = 'all';

        this.setTab = function (newValue) {
            tab = newValue;

            if (this.tab != 'all') {
                myService.updateVal(newValue);
                $scope.loadPort();
            }
        };

        this.isSet = function (tabName) {
            return tab === tabName;
        };
    }]);

    angular.module('BaranofHoldingsApp.controllers').controller('portController', ['$scope', '$http', 'myService', function ($scope, $http, myService) {
        $http.get('api/portfolio/all')
             .success(function (data, status, header, config) {
                 $scope.portfolios = data;
             })
             .error(function (data, status, header, config) {
                 alert('error!');
             });

        $scope.loadPort = function () {
            $http.get('api/portfolio/' + myService.getVal())
             .success(function (data, status, header, config) {
                 $scope.portfolios = data;
             })
             .error(function (data, status, header, config) {
                 alert('error!');
             });
        };

        $scope.getPort = function (pId) {
            $http.get('/api/portfolio/' + pId)
                .success(function (data, status, headers, config) {
                    $scope.portDetails = data;
                    if (data.portfolioType == "Current") {
                        $scope.isCurrent = 'Partners since ';
                        $scope.portFootnote = '';
                    }
                    else {
                        $scope.isCurrent = 'Exited ';
                        $scope.portFootnote = 'Investment made while at a prior firm.';
                    }
                    if (data.portfolioSite != null) {
                        $scope.portAddr = data.portfolioSite.replace(/.*?:\/\//g, "");
                    }
                    else {
                        $scope.portAddr = '';
                    }
                })
                .error(function (data, status, headers, config) {
                    alert('error!');
                });
        };

        $scope.getPortList = function (pId, isNext) {
            for (var i = 0; i < $scope.portList.length; i++) {
                if ($scope.portList[i].portfolioId === pId) {
                    if (isNext) {
                        if (i + 1 >= $scope.portList.length) {
                            $scope.getPort($scope.portList[0].portfolioId);
                        }
                        else {
                            $scope.getPort($scope.portList[i + 1].portfolioId);
                        }
                    }
                    else {
                        if (i - 1 < 0) {
                            $scope.getPort($scope.portList[$scope.portList.length - 1].portfolioId);
                        }
                        else {
                            $scope.getPort($scope.portList[i - 1].portfolioId);
                        }
                    }
                }
            }
        };
    }]);
}());