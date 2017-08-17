(function(){
    angular.module('BaranofHoldingsApp.controllers').controller('teamController', ['$scope', '$http', function ($scope, $http) {
        $http.get('api/team/team')
             .success(function (data, status, header, config) {
                 $scope.teamList = data;
             })
             .error(function (data, status, header, config) {
                 alert('error!');
             });

        //$http.get('api/team/advisor')
        //     .success(function (data, status, header, config) {
        //         $scope.boardList = data;
        //     })
        //     .error(function (data, status, header, config) {
        //         alert('error!');
        //     });

        $scope.getMember = function (tmId) {
            $http.get('api/team/' + tmId)
                .success(function (data, status, headers, config) {
                    $scope.memberDetails = data;

                    $scope.fullName = '';
                    if (data.prefix !== null) {
                        $scope.fullName += data.prefix + ' ';
                    }
                    $scope.fullName += data.firstName + " ";
                    if (data.middleName != null) {
                        $scope.fullName += data.middleName + " ";
                    }
                    $scope.fullName += data.lastName;
                    if (data.suffix != null) {
                        $scope.fullName += ", " + data.suffix;
                    }
                })
                .error(function (data, status, headers, config) {
                    alert('error!');
                });
        };

        $scope.getMemberList = function (tmId, tmType, isNext) {
            var list = $scope.teamList;
            if (tmType === 'Advisor') {
                list = $scope.boardList;
            }
            for (var i = 0; i < list.length; i++) {
                if (list[i].teamMemberId === tmId) {
                    if (isNext) {
                        if (i + 1 >= list.length) {
                            $scope.getMember(list[0].teamMemberId);
                        }
                        else {
                            $scope.getMember(list[i + 1].teamMemberId);
                        }
                    }
                    else {
                        if (i - 1 < 0) {
                            $scope.getMember(list[list.length - 1].teamMemberId);
                        }
                        else {
                            $scope.getMember(list[i - 1].teamMemberId);
                        }
                    }
                }
            }
        };

        $scope.hoverIn = function () {
            this.hover = true;
        };

        $scope.hoverOut = function () {
            this.hover = false;
        };
    }]);
}());