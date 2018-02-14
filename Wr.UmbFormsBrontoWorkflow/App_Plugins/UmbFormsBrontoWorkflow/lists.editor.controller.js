angular.module("umbraco")
    .controller("UmbFormsBrontoWorkflow.Lists.Controller",
    function ($scope, $http, UmbFormsBrontoWorkflowResource) {
        "use strict";

        var defaultMappings = [
            {
                listField: "Email Address",
                field: "",
                staticValue: "",
                toolTip: "This field is required to add a user to Bronto"
            },
            {
                listField: "Mobile Tel",
                field: "",
                staticValue: "",
                toolTip: ""
            }];

        function save() {
            $scope.setting.value = JSON.stringify({
                mappings: $scope.mappings,
                listId: $scope.listId
            });
        }

        function init() {

            $scope.lists = [];
            $scope.fields = [];
            $scope.listId = null;

            if ($scope.setting.value) {
                $scope.listId = $scope.setting.value;
            }

            UmbFormsBrontoWorkflowResource.getLists().then(function (response) {
                $scope.lists = response;
            });

            UmbFormsBrontoWorkflowResource.getFields().then(function (response) {
                $scope.fields = response;
            });
        }

        init();
    });