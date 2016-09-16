(function () {
    'use strict';

    app.factory('listManagementService', [function () {
        var listManagementService = {};

        listManagementService.itemExists = function (itemsList, itemToFind) {
            for (var i = itemsList.length - 1; i > -1; i--) {
                var currentItem = itemsList[i];

                if (angular.equals(currentItem, itemToFind)) {
                    return true;
                }
            }

            return false;
        };

        listManagementService.removeFromItems = function (itemsList, itemToRemove) {
            for (var i = itemsList.length - 1; i > -1; i--) {
                var currentItem = itemsList[i];

                if (angular.equals(currentItem, itemToRemove)) {
                    itemsList.splice(i, 1);
                }
            }
        };

        return listManagementService;

    }]);
})();