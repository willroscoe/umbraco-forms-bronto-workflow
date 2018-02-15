angular.module("umbraco")
    .controller("UmbFormsBrontoWorkflow.Lists.Controller",
    function ($scope, $http, pickerResource, UmbFormsBrontoWorkflowResource) {
        "use strict";

        var defaultMappings = [];
        UmbFormsBrontoWorkflowResource.getDefaultFields().then(function (response) {
            defaultMappings = response;
        });

        var allFields = [];
        UmbFormsBrontoWorkflowResource.getFields().then(function (response) { // all lists share the same custom fields in Bronto
            allFields = response;
        });

        function save() {
            $scope.setting.value = JSON.stringify({
                mappings: $scope.mappings,
                listId: $scope.listId
            });
        }

        function init() {

            if (!$scope.setting.value) {
                $scope.mappings = defaultMappings;
                $scope.lists = [];
                $scope.setting.value = {
                    mappings: $scope.mappings,
                    listId: null
                }
            } else {
                var value = JSON.parse($scope.setting.value);
                value.mappings.forEach(function (mapping) {
                    if (!$scope.isReservedFieldName(mapping.brontoFieldId) || mapping.toolTip) {
                        return;
                    }

                    var defaultMap = defaultMappings.filter(function (d) {
                        return d.brontoFieldId === mapping.brontoFieldId;
                    });

                    if (defaultMap.length > 0 && defaultMap[0].toolTip) {
                        mapping.toolTip = defaultMap[0].toolTip;
                    }
                });

                $scope.listId = value.listId;
                $scope.mappings = value.mappings;

                if ($scope.listId != null) {
                    $scope.changeList();
                }
            }

            UmbFormsBrontoWorkflowResource.getLists().then(function (response) {
                $scope.lists = response;
                if ($scope.listId) {
                    $scope.changeList();
                }
            });

            pickerResource.getFields().then(function (response) {
                $scope.fields = response.data;
            });
        }

        $scope.mouseOver = function ($event, tip) {
            $scope.tooltip = {
                show: true,
                event: $event,
                content: tip
            };
        }

        $scope.mouseLeave = function () {
            $scope.tooltip = {
                show: false,
                event: null,
                content: null

            };
        }

        $scope.isReservedFieldName = function (fieldName) {
            for (var i = 0; i < defaultMappings.length; i++) {
                if (defaultMappings[i].brontoFieldId == fieldName) {
                    return true;
                }
            }
            return false;
        };

        $scope.changeList = function () {
            if ($scope.listId == null) {
                $scope.mappings = defaultMappings;
                save();
                return;
            }
            save();

            $scope.listFields = allFields; // all lists share the same custom fields in Bronto
        };

        $scope.addMapping = function () {
            $scope.mappings.push({
                brontoFieldId: "",
                brontoFieldFriendlyName: "",
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