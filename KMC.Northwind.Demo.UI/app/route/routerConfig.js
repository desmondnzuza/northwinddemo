﻿app.config(['$stateProvider', function ($stateProvider) {
    $stateProvider
        // report
        .state('root', {
            url: '/',
            redirectTo: 'report'
        })        
        .state('report', {
            url: '/report/orders',
            views: {
                '': {
                    templateUrl: '../app/report/views/ordersReport.html',
                    controller: 'ordersReportCtrl as vm'
                }
            }
        })

        // category
        .state('categoryManager', {
            url: '/category',
            views: {
                '': {
                    templateUrl: '../app/category/views/categoryMain.html',
                    controller: 'categoryCtrl as vm'
                }
            }
        })
        .state('categoryManager.list', {
            url: '/list',
            views: {
                '': {
                    templateUrl: '../app/category/views/list.html',
                    controller: 'categoryListCtrl as vm'
                }
            }
        })
        .state('categoryManager.list.byProduct', {
            url: '/list/product/:productId',
            views: {
                '': {
                    templateUrl: '../app/category/views/list.html',
                    controller: 'categoryListCtrl as vm'
                }
            }
        })
        .state('categoryManager.new', {
            url: '/new',
            views: {
                '': {
                    templateUrl: '../app/category/views/new.html',
                    controller: 'categoryNewCtrl as vm'
                }
            }
        })
        .state('categoryManager.edit', {
            url: '/edit/:categoryId',
            views: {
                '': {
                    templateUrl: '../app/category/views/edit.html',
                    controller: 'categoryEditCtrl as vm'
                }
            },
            resolve: {
                categoryToInspect: [
                    'categoryService',
                    '$stateParams',
                    function (categoryService, $stateParams) {
                        var categoryId = $stateParams.categoryId;
                        return categoryService.findCategoryById(categoryId);
                    }
                ],
            }
        })

        // product
        .state('productManager', {
            url: '/product',
            views: {
                '': {
                    templateUrl: '../app/product/views/productsMain.html',
                    controller: 'productCtrl as vm'
                }
            }
        })
        .state('productManager.list', {
            url: '/list',
            views: {
                '': {
                    templateUrl: '../app/product/views/list.html',
                    controller: 'productListCtrl as vm'
                }
            }
        })
        .state('productManager.list.byCategory', {
            url: '/list/category/:categoryId',
            views: {
                '': {
                    templateUrl: '../app/product/views/list.html',
                    controller: 'productListCtrl as vm'
                }
            }
        })
        .state('productManager.new', {
            url: '/new',
            views: {
                '': {
                    templateUrl: '../app/product/views/new.html',
                    controller: 'productNewCtrl as vm'
                }
            }
        })
        .state('productManager.edit', {
            url: '/edit/:productId',
            views: {
                '': {
                    templateUrl: '../app/product/views/edit.html',
                    controller: 'productEditCtrl as vm'
                }
            },
            resolve: {
                productToInspect: [
                    'productService',
                    '$stateParams',
                    function (productService, $stateParams) {
                        var productId = $stateParams.productId;
                        return productService.findProductById(productId);
                    }
                ],
            }
        })

        // supplier
        .state('supplierManager', {
            url: '/supplier',
            views: {
                '': {
                    templateUrl: '../app/supplier/views/supplierMain.html',
                    controller: 'supplierCtrl as vm'
                }
            }
        })
        .state('supplierManager.list', {
            url: '/list',
            views: {
                '': {
                    templateUrl: '../app/supplier/views/list.html',
                    controller: 'supplierListCtrl as vm'
                }
            }
        })
        .state('supplierManager.new', {
            url: '/new',
            views: {
                '': {
                    templateUrl: '../app/supplier/views/new.html',
                    controller: 'supplierNewCtrl as vm'
                }
            }
        })
        .state('supplierManager.edit', {
            url: '/edit/:supplierId',
            views: {
                '': {
                    templateUrl: '../app/supplier/views/edit.html',
                    controller: 'supplierEditCtrl as vm'
                }
            },
            resolve: {
                supplierToInspect: [
                    'supplierService',
                    '$stateParams',
                    function (supplierService, $stateParams) {
                        var supplierId = $stateParams.supplierId;
                        return supplierService.findSupplierById(supplierId);
                    }
                ],
            }
        })
}]);
app.run(['$rootScope', '$state', function ($rootScope, $state) {
    $rootScope.$on('$stateChangeStart', function (evt, to, params) {
        if (to.redirectTo) {
            evt.preventDefault();
            $state.go(to.redirectTo, params)
        }
    });
}]);