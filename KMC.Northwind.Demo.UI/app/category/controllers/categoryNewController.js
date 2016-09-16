(function () {
    'use strict';

    app.controller('categoryNewCtrl', ['$state', function ($state) {
        var vm = this;

        vm.cancel = function () {
            $state.go('categoryManager.list');
        };
    }]);
})();