(function () {
    'use strict';

    app.controller('productNewCtrl', ['$state', 'productService', function ($state, productService) {
        var vm = this;
        vm.selectedItem = {};

        vm.save = function (isValid) {
            if (isValid) {

                productService.createProduct(vm.selectedItem)
                    .then(function (results) {
                        toastr.success("Edit Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to add product");
                    })
                    .finally(function () {
                        $state.go('productManager.list');
                    });
            }
        };

        vm.cancel = function () {
            $state.go('productManager.list');
        };
    }]);
})();