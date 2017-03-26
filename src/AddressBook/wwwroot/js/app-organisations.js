(function () {

    "use strict";
    //Creating the module
    angular.module("app-organisations", ["ngRoute"])
    .config(function ($routeProvider) {

        $routeProvider.when("/", {
            controller: "organisationsController",
            controllerAs: "vm",
            templateUrl: "/views/organisationsView.html"
        });

        $routeProvider.when("/editor/:organisationId", {
            controller: "organisationEditorController",
            controllerAs: "vm",
            templateUrl: "/views/organisationEditorView.html"
        });

        $routeProvider.when("/personEditor/:personId", {
            controller: "personEditorController",
            controllerAs: "vm",
            templateUrl: "/views/personEditorView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/" });
    });
})();