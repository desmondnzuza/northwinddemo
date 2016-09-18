(function () {
    'use strict';

    app.controller('supplierEditCtrl', ['$state', 'supplierToInspect', 'supplierService', 'listManagementService', '$uibModal', function ($state, supplierToInspect, supplierService, listManagementService, $uibModal) {
        var vm = this;

        vm.assignedProducts = supplierToInspect.products;
        vm.availableProducts = [];
        vm.selectedAssignedProducts = [];
        vm.selectedAvailableProducts = [];

        vm.selectedItem = supplierToInspect;

        vm.save = function (isValid) {
            if (isValid) {
                vm.selectedItem.products = vm.assignedProducts;

                supplierService.editSupplier(vm.selectedItem)
                    .then(function (results) {
                        toastr.success("Edit Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to edit supplier");
                    })
                    .finally(function () {
                        $state.go('categoryManager.list');
                    });
            }
        };

        vm.cancel = function () {
            $state.go('supplierManager.list');
        };

        vm.showCreateProduct = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '../app/product/views/new.html',
                controller: 'modalProductNewCtrl as vm',
                size: 'lg',
                resolve: {
                    categoryId: function () {
                        return vm.selectedItem.id;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                var itemToAdd = selectedItem;

                if (!listManagementService.itemExists(vm.assignedProducts, itemToAdd)) {
                    vm.assignedProducts.push(itemToAdd);
                }
            });
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