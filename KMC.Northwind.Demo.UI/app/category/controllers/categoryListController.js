(function () {
    'use strict';

    app.controller('categoryListCtrl', ['$scope', 'categoryService', function ($scope, categoryService) {
        var vm = this;

        vm.dummyData = 

        $scope.gridOptions = {};

        $scope.gridOptions.columnDefs = [
         { name: 'name', displayName: 'Name' },
         { name: 'description', displayName: 'Description' },
         {
             name: ' ',
             cellTemplate: '<div><a class="btn btn-primary btn-xs" ui-sref="categoryManager.edit({ categoryId: {{row.entity.id}} })">Edit</a><a class="btn btn-danger btn-xs" ng-click="grid.appScope.deleteRow(row)"">Delete</a></div>',
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
                categoryService.removeCategory(itemToDelete)
                    .then(function (results) {
                        $scope.gridOptions.data.splice(index, 1);
                        toastr.success("Delete Successful");
                    }, function (err) {
                        toastr.error("An error occured when trying to remove category");
                    });
            }
        };

        $scope.gridOptions.data = [];

        categoryService.findCategories('')
        .then(function (results) {            
            $scope.gridOptions.data = results;
        });

    }]);
})();