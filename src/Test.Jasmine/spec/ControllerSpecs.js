describe("When creating a controller", function () {

    var app = new Test.Scenarios.Controllers.App();
    
    beforeEach(function () {
        module('Test.Scenarios.Controllers.App', 'ngRoute');
    });
    
    describe("with a simple string property", function() {
        var controller;
        var scope;
        var $httpBackend;

        beforeEach(inject(function ($rootScope, $controller, $injector) {
            scope = $rootScope.$new();
            $httpBackend = $injector.get('$httpBackend');
            controller = $controller('TestScenariosControllersController', { $scope: scope });
            $httpBackend.when('GET', '/foo/bar').respond(200, {});
        }));
        
        it("the property should be added to the scope", function () {
            $httpBackend.flush();
            expect(scope.simpleString()).toEqual('Yabba dabba doo!');
        });

        it("GET should be called on HTTP service", function () {
            $httpBackend.expectGET('/foo/bar');
            $httpBackend.flush();
        });
    });
});