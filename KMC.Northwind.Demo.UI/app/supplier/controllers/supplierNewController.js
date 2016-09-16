(function () {
    'use strict';

    app.controller('supplierNewCtrl', ['$state', 'supplierService', 'listManagementService', function ($state, supplierService, listManagementService) {
        var vm = this;
        vm.assignedProducts = [];
        vm.availableProducts = [];
        vm.selectedAssignedProducts = [];
        vm.selectedAvailableProducts = [];

        vm.selectedItem = {};

        vm.save = function (isValid) {
            if (isValid) {
                vm.selectedItem.products = vm.assignedProducts;

                supplierService.createSupplier(vm.selectedItem)
                    .then(function (results) {
                        toastr.success("Save Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to add supplier");
                    })
                    .finally(function () {
                        $state.go('supplierManager.list');
                    });
            }
        };

        vm.cancel = function () {
            $state.go('supplierManager.list');
        };

        supplierService.findAvailableProducts()
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