(function () {
    'use strict';

    app.controller('categoryEditCtrl', ['$state', 'categoryToInspect', function ($state, categoryToInspect) {
        var vm = this;

        console.log(categoryToInspect);

        vm.cancel = function () {
            $state.go('categoryManager.list');
        };
    }]);
})();