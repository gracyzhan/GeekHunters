recruitsAppModule.controller('candidateController', ['$scope','$http', function ($scope, $http) {
    var vm = $scope;
    vm.firstName = "rrrr";
    vm.lastName = "";
    vm.fullName = function () {
        return vm.firstName + (vm.firstName == "" || vm.lastName ==""? "" : ",") + vm.lastName;
    }
    vm.skillSet = [];
    vm.registCandidate = function () {
        var data = {
            firstName: vm.firstName,
            lastName: vm.lastName
        };
        $http.post('/Demo/RegistCandidate', data).then(
            function (successResponse) {
                alert("Success");
            },
            function (errorResponse) {
                alert("Error");
            });
    };//end registCandidate()
}]);