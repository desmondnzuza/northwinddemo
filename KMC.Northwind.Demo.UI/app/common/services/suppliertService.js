(function () {
    'use strict';

    app.factory('supplierService', ['$http', 'appServiceSettings', function ($http, appServiceSettings) {
        var supplierService = {};
        var serviceBaseUrl = appServiceSettings.apiServiceBaseUri + "Supplier/";

        supplierService.findSupplierById = function (supplierIdToUse) {
            var params = { params: { supplierId: supplierIdToUse } };

            return $http.get(serviceBaseUrl + "FindSupplierById", params).then(function (results) {
                return results.data;
            });
        };

        supplierService.findSuppliers = function (searchTerm) {
            //TODO: make use of this when the time allows
            var criteria = {
                searchTerm: "",
                from: 0,
                to: 10
            };

            return $http.post(serviceBaseUrl + "FindSuppliers/", criteria).then(function (results) {
                return results.data;
            });
        };

        supplierService.findAvailableProducts = function () {

            return $http.get(serviceBaseUrl + "FindAvailableProducts/").then(function (results) {
                return results.data;
            });
        };

        supplierService.editSupplier = function (supplierToUpdate) {
            var params = supplierToUpdate;

            return $http.post(serviceBaseUrl + "UpdateSupplier", params).then(function (results) {
                return results;
            });
        };

        supplierService.createSupplier = function (supplierToAdd) {
            var params = supplierToAdd;

            return $http.post(serviceBaseUrl + "CreateSupplier", params).then(function (results) {
                return results;
            });
        };

        supplierService.removeSupplier = function (supplierToDelete) {
            var params = supplierToDelete;

            return $http.post(serviceBaseUrl + "RemoveSupplier", params).then(function (results) {
                return results;
            });
        };

        return supplierService;
    }]);
})();