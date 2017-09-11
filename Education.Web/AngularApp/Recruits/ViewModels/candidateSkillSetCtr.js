recruitsAppModule.controller('candidateSkillSetController', ['$scope', '$http', function ($scope, $http) {
    var vm = $scope;
    vm.candidateList = [];
    var queryCandidateList = function ($http) {
        $http.get("/Demo/QueryCandidatesAndSkill").then(function (response) {
            vm.candidateList = response.data;
        });
    }
    queryCandidateList($http);
}]);