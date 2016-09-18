(function () {
    'use strict';

    app.controller('modalProductNewCtrl', ['$uibModalInstance', function ($uibModalInstance) {
        var vm = this;
        vm.selectedItem = {};

        vm.save = function (isValid) {
            if (isValid) {
                $uibModalInstance.close(vm.selectedItem);
            }
        };

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }]);
})();