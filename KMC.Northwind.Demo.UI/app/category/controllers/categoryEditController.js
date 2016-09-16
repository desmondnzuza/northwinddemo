(function () {
    'use strict';

    app.controller('categoryEditCtrl', ['$state', 'categoryToInspect', 'categoryService', function ($state, categoryToInspect, categoryService) {
        var vm = this;
        vm.assignedProducts = categoryToInspect.products;
        vm.availableProducts = [];
        vm.selectedItem = categoryToInspect;

        vm.cancel = function () {
            $state.go('categoryManager.list');
        };

        categoryService.findAvailableProducts()
        .then(function (results) {
            vm.availableProducts = results;
        });

    }]);
})();