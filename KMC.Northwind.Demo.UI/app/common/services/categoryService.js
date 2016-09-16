(function () {
    'use strict';

    app.factory('categoryService', ['$http', 'appServiceSettings', function ($http, appServiceSettings) {
        var categoryService = {};
        var serviceBaseUrl = appServiceSettings.apiServiceBaseUri + "Category/";

        categoryService.findCategoryById = function (categoryIdToUse) {
            var params = { params: { categoryId: categoryIdToUse } };

            return $http.get(serviceBaseUrl + "FindCategoryById", params).then(function (results) {
                return results.data;
            });
        };

        categoryService.findCategories = function (searchTerm) {
            //TODO: make use of this when the time allows
            var criteria = {
                searchTerm: "",
                from: 0,
                to : 10
            };

            return $http.post(serviceBaseUrl + "FindCategories/", criteria).then(function (results) {
                return results.data;
            });
        };

        categoryService.findAvailableProducts = function () {

            return $http.get(serviceBaseUrl + "FindAvailableCategories/").then(function (results) {
                return results.data;
            });
        };

        categoryService.editCategory = function (categoryToUpdate) {
            var params = categoryToUpdate;

            return $http.post(serviceBaseUrl + "UpdateCategory", params).then(function (results) {
                return results;
            });
        };

        categoryService.createCategory = function (categoryToAdd) {
            var params = categoryToAdd;

            return $http.post(serviceBaseUrl + "CreateCategory", params).then(function (results) {
                return results;
            });
        };

        categoryService.removeCategory = function (categoryToDelete) {
            var params = categoryToDelete;

            return $http.post(serviceBaseUrl + "RemoveCategory", params).then(function (results) {
                return results;
            });
        };

        return categoryService;
    }]);
})();