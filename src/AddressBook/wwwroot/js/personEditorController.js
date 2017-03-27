(function () {

    "use strict";

    angular.module("app-organisations")
        .controller("personEditorController", personEditorController);

    function personEditorController($routeParams, $http) {
        var vm = this;
        vm.personId = $routeParams.personId;
        vm.organisationId = $routeParams.organisationId;

        vm.person = {};
        vm.ErrorMessage = "";
        vm.isBusy = true;

        var url = "/api/organisations/" + vm.organisationId + "/persons/" + vm.personId;

        $http.get(url)
            .then(function (response) {
                angular.copy(response.data, vm.person);
            },
                function (err) {
                    vm.errorMessage = "Failed to load persons";
                })
            .finally(function () {
                vm.isBusy = false;
            });
    };

})();