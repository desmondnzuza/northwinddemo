(function () {
    'use strict';

    app.controller('productEditCtrl', ['$state', 'productToInspect', 'productService', function ($state, productToInspect, productService) {
        var vm = this;

        vm.selectedItem = productToInspect;

        vm.save = function (isValid) {
            if (isValid) {

                productService.editProduct(vm.selectedItem)
                    .then(function (results) {
                        toastr.success("Edit Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to edit product");
                    })
                    .finally(function () {
                        $state.go('productManager.list');
                    });
            }
        };

        vm.cancel = function () {
            $state.go('productManager.list');
        };

        /*categoryService.findAvailableProducts()
        .then(function (results) {
            vm.availableProducts = results;
        });*/
    }]);
})();