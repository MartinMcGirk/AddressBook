!function(){"use strict";function n(n,o,s){var e=this;e.personId=n.personId,e.organisationId=n.organisationId,e.person={},e.ErrorMessage="",e.isBusy=!0;var r="/api/organisations/"+e.organisationId+"/persons";e.personId&&(r=r+"/"+e.personId),o.get(r).then(function(n){angular.copy(n.data,e.person)},function(n){e.errorMessage="Failed to load persons"}).finally(function(){e.isBusy=!1}),e.updatePerson=function(){e.isBusy=!0,e.errorMessage="",o.put("/api/organisations/"+e.organisationId+"/persons",e.person).then(function(n){s.path("/manager/"+e.organisationId)},function(){e.errorMessage="Failed to update person"}).finally(function(){e.isBusy=!1})},e.deletePerson=function(){e.isBusy=!0,e.errorMessage="",o.delete("/api/organisations/"+e.organisationId+"/persons/"+e.personId).then(function(n){s.path("/manager/"+e.organisationId)},function(){e.errorMessage="Failed to delete person"}).finally(function(){e.isBusy=!1})}}n.$inject=["$routeParams","$http","$location"],angular.module("app-organisations").controller("personEditorController",n)}();