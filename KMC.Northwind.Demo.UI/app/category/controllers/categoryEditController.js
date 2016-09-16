(function () {
    'use strict';

    app.controller('categoryEditCtrl', ['$state', function ($state) {
        var vm = this;

        vm.cancel = function () {
            $state.go('categoryManager.list');
        };
    }]);
})();