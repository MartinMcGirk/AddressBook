(function () {
    "use strict";

    //Getting the existing module
    angular.module("app-organisations")
        .controller("organisationsController", organisationsController);

    function organisationsController($http, $location) {
        var vm = this;

        vm.organisations = [];
        vm.newOrganisation = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/organisations")
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.organisations);
            },
                function (error) {
                    //Failure
                    vm.errorMessage = "Failed to load data" + error;
                })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addOrganisation = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/organisations", vm.newOrganisation)
                .then(function (response) {
                        vm.organisations.push(response.data);
                        vm.newOrganisation = {};
                        $location.path("/");
                    },
                    function () {
                        vm.errorMessage = "Failed to save new organisation";
                    })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    }

})();