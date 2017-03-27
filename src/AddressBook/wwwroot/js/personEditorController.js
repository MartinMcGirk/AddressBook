(function () {

    "use strict";

    angular.module("app-organisations")
        .controller("personEditorController", personEditorController);

    function personEditorController($routeParams, $http, $location) {
        var vm = this;
        vm.personId = $routeParams.personId;
        vm.organisationId = $routeParams.organisationId;

        vm.person = {};
        vm.ErrorMessage = "";
        vm.isBusy = true;

        var url = "/api/organisations/" + vm.organisationId + "/persons";
        if (vm.personId) {
            url = url + "/" + vm.personId;
        }


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

        vm.updatePerson = function() {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.put("/api/organisations/" + vm.organisationId + "/persons", vm.person)
                .then(function(response) {
                        $location.path("/manager/" + vm.organisationId);
                    },
                    function() {
                        vm.errorMessage = "Failed to update person";
                    })
                .finally(function() {
                    vm.isBusy = false;
                });
        };

        vm.deletePerson = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.delete("/api/organisations/" + vm.organisationId + "/persons/" + vm.personId)
                .then(function (response) {
                    $location.path("/manager/" + vm.organisationId);
                },
                    function () {
                        vm.errorMessage = "Failed to delete person";
                    })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

    };

})();