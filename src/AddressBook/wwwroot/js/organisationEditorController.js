(function () {

    "use strict";

    angular.module("app-organisations")
        .controller("organisationEditorController", organisationEditorController);

    function organisationEditorController($routeParams, $http, $location) {
        var vm = this;
        vm.organisationId = $routeParams.organisationId;

        vm.organisation = {};
        vm.ErrorMessage = "";
        vm.isBusy = true;
        vm.newPerson = {};

        var url = "/api/organisations/" + vm.organisationId;

        $http.get(url)
            .then(function (response) {
                angular.copy(response.data, vm.organisation);
            },
                function (err) {
                    vm.errorMessage = "Failed to load persons";
                })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addPerson = function () {
            vm.isBusy = true;

            $http.post(url + '/persons', vm.newPerson)
                .then(function (response) {
                        vm.organisation.persons.push(response.data);
                        vm.newPerson = {};
                        $location.path('/manager/' + vm.organisationId);
                    },
                    function (err) {
                        vm.errorMessage = "Failed to add new person";
                    })
                .finally(function () {
                    vm.isBusy = false;
                });

        }

    };

})();