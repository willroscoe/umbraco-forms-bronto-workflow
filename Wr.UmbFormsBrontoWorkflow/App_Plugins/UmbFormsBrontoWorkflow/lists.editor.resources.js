angular.module('umbraco.resources').factory('UmbFormsBrontoWorkflowResource', function ($http, umbRequestHelper) {

    var apiPath = '/Umbraco/backoffice/Api/BrontoApiView/';

    return {
        getLists: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetLists'), 'No Bronto lists returned');
        },
        getFields: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetFields'), 'No Bronto custom fields returned');
        },
        getStandardFields: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetStandardFields'), 'No Bronto standard fields returned');
        }
    };
});