recruitsAppModule.controller('candidateController', ['$scope', function ($scope) {
    var vm = $scope;
    vm.firstName = "rrrr";
    vm.lastName = "";
    vm.fullName = function () {
        return vm.firstName + (vm.firstName == "" || vm.lastName ==""? "" : ",") + vm.lastName;
    }
    vm.skillSet = [];
}]);