(function () {
    'use strict';

    app.controller('supplierListCtrl', ['$scope', 'supplierService', function ($scope, supplierService) {
        var vm = this;
        $scope.gridOptions = {};

        $scope.gridOptions.columnDefs = [
         { name: 'id', displayName: 'ID' },
         { name: 'companyName', displayName: 'Company' },
         { name: 'contactName', displayName: 'Contact Name' },
         { name: 'region', displayName: 'Region' },
         { name: 'Country', displayName: 'Country' },
         {
             name: 'Edit',
             cellTemplate: '<div class="ui-grid-cell-contents"><a type="button" class="btn btn-primary btn-xs" href="#/supplier/edit/{{row.entity.id}}">Edit</a></div>',
             enableSorting: false,
             enableFiltering: false,
             enableHiding: false,
             enableColumnMenus: false
         },
         {
             name: 'Delete',
             cellTemplate: '<div class="ui-grid-cell-contents"><a class="btn btn-danger btn-xs" ng-click="grid.appScope.deleteRow(row)">Delete</a></div>',
             enableSorting: false,
             enableFiltering: false,
             enableHiding: false,
             enableColumnMenus: false
         }
        ];

        $scope.deleteRow = function (row) {
            var index = $scope.gridOptions.data.indexOf(row.entity);
            var itemToDelete = $scope.gridOptions.data[index];

            if (itemToDelete) {
                supplierService.removeSupplier(itemToDelete)
                    .then(function (results) {
                        $scope.gridOptions.data.splice(index, 1);
                        toastr.success("Delete Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to remove supplier");
                    });
            }
        };

        $scope.gridOptions.data = [];

        supplierService.findSuppliers('')
        .then(function (results) {
            $scope.gridOptions.data = results;
        });

    }]);
})();