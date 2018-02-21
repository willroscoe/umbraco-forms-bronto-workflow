angular.module("umbraco")
    .controller("UmbFormsBrontoWorkflow.Lists.Controller",
    function ($scope, $http, $routeParams, pickerResource, UmbFormsBrontoWorkflowResource) {
        "use strict";

        // the rest are added as custom fields, which are used across all bronto lists for an a/c
        UmbFormsBrontoWorkflowResource.getBrontoFields().then(function (response) { // all lists share the same custom fields in Bronto
            $scope.listFields = response;
        });

        // get all the bronto lists
        UmbFormsBrontoWorkflowResource.getBrontoLists().then(function (response) {
            $scope.lists = response;
        });

        function save() {
            $scope.setting.value = JSON.stringify({
                mappings: $scope.mappings,
                listId: $scope.listId
            });
        }

        function init() {

            if (!$scope.setting.value) {
                $scope.mappings = [];
                $scope.setting.value = {
                    mappings: $scope.mappings,
                    listId: null
                }
            } else {
                var value = JSON.parse($scope.setting.value);
                $scope.listId = value.listId;
                $scope.mappings = value.mappings;
            }

            // get the umbraco form id
            var formId = $routeParams.id;
            if (formId === -1 && $scope.model && $scope.model.fields) {

            } else {
                // get the umbraco form fields setup for the form linked to this instance of the workflow
                pickerResource.getAllFields($routeParams.id).then(function (response) {
                    $scope.fields = response.data;
                });
            }
        }

        // check if the required fields have been set. The requirement for bronto contacts is that either 'email' or 'mobileNumber' is set.
        $scope.isValidForBronto = function () {
            for (var i = 0; i < $scope.mappings.length; i++) {
                var obj = $scope.mappings[i];
                if (obj.brontoFieldId == "email" || obj.brontoFieldId == "mobileNumber") {
                    return true;
                }
            }
            return false;
        };

        $scope.changeList = function () {
            save();
        };

        $scope.addMapping = function () {
            $scope.mappings.push({
                brontoFieldId: "",
                brontoFieldLabel: "",
                formField: "",
                staticValue: ""
            });
        };

        $scope.deleteMapping = function (index) {
            $scope.mappings.splice(index, 1);
            save();
        };

        $scope.stringifyValue = function () {
            save();
        };

        init();
    });