(function () {
    'use strict';
    describe("Category Service", function () {
        var $httpBackend, service;
        var url = apiUrl + 'api/';

        beforeEach(module(appName));

        beforeEach(inject(function (_$httpBackend_, categoryService) {
            $httpBackend = _$httpBackend_;
            service = categoryService;
        }));

        describe('When Finding Category By Id', function () {
            var categoryId = 'someRandomId';

            it('Should make a call to the API', function () {
                $httpBackend.expectGET(url + 'Category/FindCategoryById?categoryId=' + categoryId)
                    .respond(200);

                service.findCategoryById(categoryId);

                $httpBackend.verifyNoOutstandingExpectation();
                passTheTest();//if we reach this point, it means the api call is being made.
            });

            it('should return no results on error', function () {
                var dummyErrorMessage = "Error connecting to API";

                $httpBackend.whenGET(url + 'Category/FindCategoryById?categoryId=' + categoryId)
                    .respond(500, dummyErrorMessage);

                var result;

                service.findCategoryById(categoryId).then(function (response) {
                    result = response;
                });

                $httpBackend.flush();

                expect(result).toBeUndefined();
            });

            it('should return error on error', function () {
                var dummyErrorMessage = "Error connecting to API";

                $httpBackend.whenGET(url + 'Category/FindCategoryById?categoryId=' + categoryId)
                    .respond(500, dummyErrorMessage);

                var result;

                service.findCategoryById(categoryId).then(function (response) { }, function (error) {
                    result = error;
                });

                $httpBackend.flush();

                expect(result).toBeDefined();
            });

            it('should return results on success', function () {
                var dummyData = [{ id: '1', name: 'category1' }];

                $httpBackend.whenGET(url + 'Category/FindCategoryById?categoryId=' + categoryId)
                    .respond(200, dummyData);

                var result;

                service.findCategoryById(categoryId).then(function (response) {
                    result = response;
                });

                $httpBackend.flush();

                expect(result).toEqual(dummyData);
            });
        });

        describe('When Finding Categories By Criteria', function () {
            var criteria = {                
                from: 0,
                searchTerm: "some search term",
                to: 10
            };

            it('Should make a call to the right API', function () {
                $httpBackend.expectPOST(url + 'Category/FindCategories/', JSON.parse(criteria))
                    .respond(200);

                service.findCategories("some search term");

                $httpBackend.verifyNoOutstandingExpectation();
                passTheTest();//if we reach this point, it means the api call is being made.
            });
        });
    });
})();