(function () {
    'use strict';

    app.controller('productListCtrl', ['$scope', 'productService', function ($scope, productService) {
        var vm = this;
        vm.isDoneLoading = false;

        $scope.gridOptions = {};

        $scope.gridOptions.columnDefs = [
         { name: 'id', displayName: 'ID' },
         { name: 'name', displayName: 'Product Name' },
         { name: 'quantityPerUnit', displayName: 'Quantity per Unit' },         
         { name: 'isDiscontinued', displayName: 'Discontinued' },
         {
             name: 'Edit',
             cellTemplate: '<div class="ui-grid-cell-contents"><a type="button" class="btn btn-primary btn-xs" href="#/product/edit/{{row.entity.id}}">Edit</a></div>',
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
                productService.removeProduct(itemToDelete)
                    .then(function (results) {
                        $scope.gridOptions.data.splice(index, 1);
                        toastr.success("Delete Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to remove product");
                    });
            }
        };

        $scope.gridOptions.data = [];

        productService.findProducts('')
        .then(function (results) {
            vm.isDoneLoading = true;
            $scope.gridOptions.data = results;
        }, function (err) {
            toastr.error("An error occured when trying to load products");
        });

    }]);
})();