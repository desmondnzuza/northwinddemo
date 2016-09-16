(function () {
    'use strict';

    app.controller('categoryEditCtrl', ['$state', 'categoryToInspect', 'categoryService', 'listManagementService', function ($state, categoryToInspect, categoryService, listManagementService) {
        var vm = this;
        vm.assignedProducts = categoryToInspect.products;
        vm.availableProducts = [];
        vm.selectedAssignedProducts = [];
        vm.selectedAvailableProducts = [];

        vm.selectedItem = categoryToInspect;

        vm.save = function (isValid) {
            if (isValid) {
                vm.selectedItem.products = vm.assignedProducts;

                categoryService.editCategory(vm.selectedItem)
                    .then(function (results) {
                        toastr.success("Edit Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to edit category");
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

                if (!listManagementService.itemExists(vm.assignedProducts, itemToAdd)) {
                    vm.assignedProducts.push(itemToAdd);
                }
            }
        };

        vm.removeAssignedProducts = function () {
            var selectedItems = vm.selectedAssignedProducts;

            for (var i = selectedItems.length - 1; i > -1; i--) {
                var itemToRemove = selectedItems[i];

                listManagementService.removeFromItems(vm.assignedProducts, itemToRemove);
            }
        };
       
    }]);
})();