recruitsAppModule.controller('demoController', ['$scope', '$http', function ($scope, $http) {
     
    var vm = $scope;
    vm.skillList = [];
    vm.candidateList = [];
    vm.candidateDetailList = [];
    //properties for Candidate
    vm.firstName = "";
    vm.lastName = "";
    vm.fullName = function () {
        return vm.firstName + (vm.firstName == "" || vm.lastName == "" ? "" : ",") + vm.lastName;
    }
    
    /*functions*/
    var querySkillList = function ($http) {
        $http.get("/Demo/GetAllSkill").then(function (response) {
            vm.skillList = response.data;
        });
    }

    var queryCandidateList = function ($http) {
        $http.get("/Demo/QueryCandidates").then(function (response) {
            vm.candidateList = response.data;
        });
    }

    var queryCandidateDetailList = function ($http) {
        $http.get("/Demo/QueryCandidatesAndSkill").then(function (response) {
            vm.candidateDetailList = response.data;
        });
    }
   

    vm.registCandidate = function () {
        var data = {
            firstName: vm.firstName,
            lastName: vm.lastName
        };
        $http.post('/Demo/RegistCandidate', data).then(
            function (successResponse) {
                // alert("Success");
                queryCandidateList($http);
            },
            function (errorResponse) {
                alert("Error");
            });
    };//end registCandidate()

    //run the method to load the data at the end of this process
    querySkillList($http);
    queryCandidateList($http);
    queryCandidateDetailList($http);

}]);
