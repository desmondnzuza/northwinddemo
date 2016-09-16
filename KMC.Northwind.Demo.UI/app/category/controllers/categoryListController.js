(function () {
    'use strict';

    app.controller('categoryListCtrl', ['$scope', function ($scope) {
        var vm = this;

        vm.dummyData = 

        $scope.gridOptions = {};

        $scope.gridOptions.columnDefs = [
         { name: 'firstName' },
         { name: 'lastName' },
         {
             name: ' ',
             cellTemplate: '<div><a class="btn btn-primary btn-xs" ui-sref="categoryManager.edit({ categoryId: {{row.entity.id}} })">Edit</a></div>',
             enableSorting: false,
             enableFiltering: false,
             enableHiding: false,
             enableColumnMenus: false
         }
        ];

        //TODO: use service to get northwind data
        $scope.gridOptions.data = [{
            "id": 1,
            "firstName": "Cox",
            "lastName": "Carney",
            "company": "Enormo",
            "employed": true
        },
        {
            "id": 2,
            "firstName": "Lorraine",
            "lastName": "Wise",
            "company": "Comveyer",
            "employed": false
        },
        {
            "id": 3,
            "firstName": "Nancy",
            "lastName": "Waters",
            "company": "Fuelton",
            "employed": false
        }];

    }]);
})();