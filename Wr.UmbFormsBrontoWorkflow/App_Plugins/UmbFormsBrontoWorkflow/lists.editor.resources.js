angular.module('umbraco.resources').factory('UmbFormsBrontoWorkflowResource', function ($http, umbRequestHelper) {

    var apiPath = '/Umbraco/backoffice/Api/BrontoApiView/';

    return {
        getBrontoLists: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetBrontoLists'), 'No Bronto lists returned');
        },
        getBrontoFields: function () {
            return umbRequestHelper.resourcePromise($http.get(apiPath + 'GetBrontoFields'), 'No Bronto fields returned');
        }
    };
});