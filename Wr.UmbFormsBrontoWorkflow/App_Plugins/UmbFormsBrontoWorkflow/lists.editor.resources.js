angular.module('umbraco.resources').factory('UmbFormsBrontoWorkflowResource', function ($http, umbRequestHelper) {

    var apiPath = '/Umbraco/backoffice/Api/BrontoApiView/';

    return {
        getLists: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetLists'), 'No Bronto lists returned');
        },
        getFields: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetFields'), 'No Bronto custom fields returned');
        },
        getDefaultFields: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetDefaultFields'), 'No Bronto default fields returned');
        }
    };
});