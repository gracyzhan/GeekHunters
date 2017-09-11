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
   
    //VALIDATION
    function validateInput()
    {
        var checkedSkillCheckbox = $("input:checked[name^='registCandidate']");
        if (checkedSkillCheckbox.length < 1) {
            alert("Please at least choose one skill!");
            return false;
        }

        if (vm.firstName == "" && vm.lastName == "")
        {
            alert("You mush input your first name or your last name!");
            return false;
        }

        return true;
    }
    vm.registCandidate = function () {
        var checkedSkillCheckbox = $("input:checked[name^='registCandidate']");
        //validation
        if (!validateInput())
        {
            return;
        }
        var skillSet = [];
        for (var j = 0; j < checkedSkillCheckbox.length ; j++)
        {
            skillSet.push ( $(checkedSkillCheckbox[j]).val() );
        }
        var data = {
            candidate: {
            firstName: vm.firstName,
            lastName: vm.lastName} ,
            SkillIds: skillSet
        };
        $http.post('/Demo/RegistCandidate', data).then(
            function (successResponse) {
                queryCandidateList($http);
                queryCandidateDetailList($http);
                alert("Success");
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
