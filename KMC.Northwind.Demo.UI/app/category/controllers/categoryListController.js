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
             name: '     ',
             cellTemplate: '<div><a class="btn btn-primary btn-xs" ui-sref="categoryManager.edit()">Edit</a></div>',
             enableSorting: false,
             enableFiltering: false,
             enableHiding: false,
             enableColumnMenus: false
         }
        ];

        //TODO: use service to get northwind data
        $scope.gridOptions.data = [{
            "firstName": "Cox",
            "lastName": "Carney",
            "company": "Enormo",
            "employed": true
        },
        {
            "firstName": "Lorraine",
            "lastName": "Wise",
            "company": "Comveyer",
            "employed": false
        },
        {
            "firstName": "Nancy",
            "lastName": "Waters",
            "company": "Fuelton",
            "employed": false
        }];

    }]);
})();