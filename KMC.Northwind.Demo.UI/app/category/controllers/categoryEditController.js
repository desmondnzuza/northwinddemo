(function () {
    'use strict';

    app.controller('categoryEditCtrl', ['$state', 'categoryToInspect', 'categoryService', function ($state, categoryToInspect, categoryService) {
        var vm = this;
        vm.assignedProducts = categoryToInspect.products;
        vm.availableProducts = [];
        vm.selectedAssignedProducts = [];
        vm.selectedAvailableProducts = [];

        vm.selectedItem = categoryToInspect;

        vm.save = function (isValid) {
            if (isValid) {
                //debugger;
                vm.selectedItem.products = vm.assignedProducts;

                console.log('about to save');
                console.log(vm.selectedItem);

                categoryService.editCategory(vm.selectedItem)
                    .then(function (results) {
                        toastr.success("Save Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to update set");
                    })
                    .finally(function () {
                        $state.go('categoryManager.list');
                    });
            }
        };

        vm.cancel = function () {
            $state.go('categoryManager.list');
        };

        categoryService.findAvailableProducts()
        .then(function (results) {
            vm.availableProducts = results;
        });

        vm.assignSelectedProducts = function () {
            var selectedItems = vm.selectedAvailableProducts;

            for (var i = 0; i < selectedItems.length; i++) {
                var itemToAdd = selectedItems[i];

                if (!vm.itemExists(vm.assignedProducts, itemToAdd)) {
                    vm.assignedProducts.push(itemToAdd);
                }
            }
        };

        vm.removeAssignedProducts = function () {
            var selectedItems = vm.selectedAssignedProducts;

            for (var i = selectedItems.length - 1; i > -1; i--) {
                var itemToRemove = selectedItems[i];

                vm.removeFromItems(vm.assignedProducts, itemToRemove);
            }
        };

        vm.itemExists = function (itemsList, itemToFind) {
            for (var i = itemsList.length - 1; i > -1; i--) {
                var currentItem = itemsList[i];

                if (angular.equals(currentItem, itemToFind)) {
                    return true;
                }
            }

            return false;
        };

        vm.removeFromItems = function (itemsList, itemToRemove) {
            for (var i = itemsList.length - 1; i > -1; i--) {
                var currentItem = itemsList[i];

                if (angular.equals(currentItem, itemToRemove)) {
                    itemsList.splice(i, 1);
                }
            }
        };
       
    }]);
})();