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
             cellTemplate: '<div><a class="btn btn-primary btn-xs" ui-sref="categoryManager.edit({ categoryId: {{row.entity.id}} })">Edit</a></div>',
             enableSorting: false,
             enableFiltering: false,
             enableHiding: false,
             enableColumnMenus: false
         }
        ];

        $scope.gridOptions.data = [];

        categoryService.findCategories('')
        .then(function (results) {            
            $scope.gridOptions.data = results;
        });

    }]);
})();