recruitsAppModule.controller('skillController', ['$scope', '$http', function ($scope, $http) {
     
    var vm = $scope;
    vm.skillList = [];
    //var querySkillList = function () {
    //    $http.get("/Demo/GetAllSkill").
    //       success(function (response) {
    //           alert("SUCCESS");
    //       }).
    //       error(function (response) {
    //           alert("FALSE");
    //       });

    //};

    var querySkillList = function ($http) {
        $http.get("/Demo/GetAllSkill").then(function (response) {
            vm.skillList = response.data;
        });
    }
    querySkillList($http);

}]);
