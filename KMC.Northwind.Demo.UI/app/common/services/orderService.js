(function () {
    'use strict';

    app.factory('orderService', ['$http', 'appServiceSettings', function ($http, appServiceSettings) {
        var orderService = {};
        var serviceBaseUrl = appServiceSettings.apiServiceBaseUri + "Order/";

        orderService.findOrdersBeingShipped = function () {
            return $http.get(serviceBaseUrl + "FindOrdersBeingShipped").then(function (results) {
                return results.data;
            });
        };

        return orderService;
    }]);
})();