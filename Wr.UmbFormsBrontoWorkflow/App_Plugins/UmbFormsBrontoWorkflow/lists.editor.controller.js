angular.module("umbraco")
    .controller("UmbFormsBrontoWorkflow.Lists.Controller",
    function ($scope, $http, UmbFormsBrontoWorkflowResource) {
        "use strict";

        function init() {

            $scope.lists = [];
            $scope.listId = null;

            if ($scope.setting.value) {
                $scope.listId = $scope.setting.value;
            }

            UmbFormsBrontoWorkflowResource.getLists().then(function (response) {
                $scope.lists = response;
            });
        }

        inti();
    });