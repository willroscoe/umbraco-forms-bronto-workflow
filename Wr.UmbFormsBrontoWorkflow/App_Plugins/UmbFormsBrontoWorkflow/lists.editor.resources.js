angular.module('umbraco.resources').factory('UmbFormsBrontoWorkflowResource', function ($http, umbRequestHelper) {

    var apiPath = '/Umbraco/backoffice/Api/BrontoApiView/';

    return {
        getLists: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetLists'), 'No Bronto lists found');
        },
        getFields: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetFields'), 'No Bronto fields found');
        }
    };
});