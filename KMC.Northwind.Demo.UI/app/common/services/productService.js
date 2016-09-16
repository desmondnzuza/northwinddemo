(function () {
    'use strict';

    app.factory('productService', ['$http', 'appServiceSettings', function ($http, appServiceSettings) {
        var productService = {};
        var serviceBaseUrl = appServiceSettings.apiServiceBaseUri + "Product/";

        productService.findProductById = function (categoryIdToUse) {
            var params = { params: { categoryId: categoryIdToUse } };

            return $http.get(serviceBaseUrl + "FindProductById", params).then(function (results) {
                return results.data;
            });
        };

        productService.findProducts = function (searchTerm) {
            //TODO: make use of this when the time allows
            var criteria = {
                searchTerm: "",
                from: 0,
                to: 10
            };

            return $http.post(serviceBaseUrl + "FindProducts/", criteria).then(function (results) {
                return results.data;
            });
        };

        productService.findAvailableCategories = function () {

            return $http.get(serviceBaseUrl + "FindAvailableCategories/").then(function (results) {
                return results.data;
            });
        };

        productService.findAvailableSuppliers = function () {

            return $http.get(serviceBaseUrl + "FindAvailableSuppliers/").then(function (results) {
                return results.data;
            });
        };

        productService.editProduct = function (categoryToUpdate) {
            var params = categoryToUpdate;

            return $http.post(serviceBaseUrl + "UpdateProduct", params).then(function (results) {
                return results;
            });
        };

        productService.createProduct = function (categoryToAdd) {
            var params = categoryToAdd;

            return $http.post(serviceBaseUrl + "CreateProduct", params).then(function (results) {
                return results;
            });
        };

        productService.removeProduct = function (categoryToDelete) {
            var params = categoryToDelete;

            return $http.post(serviceBaseUrl + "RemoveProduct", params).then(function (results) {
                return results;
            });
        };

        return productService;
    }]);
})();