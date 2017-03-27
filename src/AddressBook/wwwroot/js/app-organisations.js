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

        $routeProvider.when("/manager/:organisationId", {
            controller: "organisationEditorController",
            controllerAs: "vm",
            templateUrl: "/views/organisationManagerView.html"
        });

        $routeProvider.when("/editor/new", {
            controller: "organisationsController",
            controllerAs: "vm",
            templateUrl: "/views/organisationAddView.html"
        });

        $routeProvider.when("/editor/:organisationId", {
            controller: "organisationEditorController",
            controllerAs: "vm",
            templateUrl: "/views/organisationEditorView.html"
        });

        $routeProvider.when("/manager/:organisationId/:personId", {
            controller: "personEditorController",
            controllerAs: "vm",
            templateUrl: "/views/personManagerView.html"
        });

        $routeProvider.when("/editor/:organisationId/new", {
            controller: "organisationEditorController",
            controllerAs: "vm",
            templateUrl: "/views/personAddView.html"
        });

        $routeProvider.when("/editor/:organisationId/:personId", {
            controller: "personEditorController",
            controllerAs: "vm",
            templateUrl: "/views/personEditorView.html"
        });

        $routeProvider.otherwise({ redirectTo: "/" });
    });
})();