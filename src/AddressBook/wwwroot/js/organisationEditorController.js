(function () {

    "use strict";

    angular.module("app-organisations")
        .controller("organisationEditorController", organisationEditorController);

    function organisationEditorController($routeParams, $http) {
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

        //vm.addStop = function () {
        //    vm.isBusy = true;

        //    $http.post(url, vm.newPerson)
        //        .then(function (response) {
        //            vm.persons.push(response.data);
        //            vm.newPerson = {};
        //        },
        //            function (err) {
        //                vm.errorMessage = "Failed to add new stop";
        //            })
        //        .finally(function () {
        //            vm.isBusy = false;
        //        });

        //}

    };

})();