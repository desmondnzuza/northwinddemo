(function () {
    'use strict';

    app.controller('categoryEditCtrl', ['$state', 'categoryToInspect', function ($state, categoryToInspect) {
        var vm = this;
        vm.assignedProducts = categoryToInspect.products;
        vm.availableProducts = [];
        vm.selectedItem = categoryToInspect;

        vm.cancel = function () {
            $state.go('categoryManager.list');
        };
    }]);
})();