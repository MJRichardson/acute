describe("HTTP service", function () {

    //var app = new Test.Scenarios.Http.HttpTestApp();

    beforeEach(function () {
        module('Test.Scenarios.Http.HttpTestApp', 'ngRoute');
    });
    
    describe("when calling GET", function() {
        var controller;
        var scope;
        var $httpBackend;
        
        beforeEach(inject(function ($rootScope, $controller, $injector) {
            scope = $rootScope.$new();
            $httpBackend = $injector.get('$httpBackend');
            controller = $controller('Test.Scenarios.Http.HttpTestController', { $scope: scope });
        }));

        describe("and string data is returned", function () {
            
            beforeEach(function() {
                $httpBackend.when('GET', '/foo/bar').respond(200, 'Hello World!');
                scope.getStringData();
            });
            
            it("GET should be called on angular HTTP service", function () {
                $httpBackend.expectGET('/foo/bar');
                $httpBackend.flush();
            });
            
            it("status should be returned", function () {
                $httpBackend.flush();
                expect(scope.status).toEqual(200);
            });
            
            it("data should be returned", function () {
                $httpBackend.flush();
                expect(scope.data).toEqual('Hello World!');
            });


        });
        
        describe("and object data is returned", function () {

            beforeEach(function () {
                $httpBackend.when('GET', '/foo/bar').respond(200, '{"id": 123, "name": "Foo Bar"}');
                scope.getObjectData();
            });

            it("data should be returned strongly typed", function () {
                $httpBackend.flush();
                expect(scope.dataObjectId).toEqual(123);
            });


        });
        

    });
});