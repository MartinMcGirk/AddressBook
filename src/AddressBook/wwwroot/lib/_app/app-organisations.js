!function(){"use strict";angular.module("app-organisations",["ngRoute"]).config(["$routeProvider",function(o){o.when("/",{controller:"organisationsController",controllerAs:"vm",templateUrl:"/views/organisationsView.html"}),o.when("/manager/:organisationId",{controller:"organisationEditorController",controllerAs:"vm",templateUrl:"/views/organisationManagerView.html"}),o.when("/editor/new",{controller:"organisationsController",controllerAs:"vm",templateUrl:"/views/organisationAddView.html"}),o.when("/editor/:organisationId",{controller:"organisationEditorController",controllerAs:"vm",templateUrl:"/views/organisationEditorView.html"}),o.when("/manager/:organisationId/:personId",{controller:"personEditorController",controllerAs:"vm",templateUrl:"/views/personManagerView.html"}),o.when("/editor/:organisationId/new",{controller:"organisationEditorController",controllerAs:"vm",templateUrl:"/views/personAddView.html"}),o.when("/editor/:organisationId/:personId",{controller:"personEditorController",controllerAs:"vm",templateUrl:"/views/personEditorView.html"}),o.otherwise({redirectTo:"/"})}])}();