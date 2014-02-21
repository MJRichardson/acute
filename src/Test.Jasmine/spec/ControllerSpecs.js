describe("When creating a controller", function () {

    var app;
    beforeEach(function() {
        app = new Test.Scenarios.Controllers.App();
        module('Test.Scenarios.Controllers.App', 'ngRoute');
    });
    
    describe("with a simple string property", function() {
        var controller;
        var scope;
        var http;

        beforeEach(inject(function($rootScope, $controller, $http) {
            scope = $rootScope.$new();
            http = $http;
            spyOn(http, 'get');
            controller = $controller('TestScenariosControllersController', { $scope: scope, $http: http });
        }));
        
        
        
        it("GET should be called on HTTP service", function () {
            expect(http.get).toHaveBeenCalled();
        });
        
        it("the property should be added to the scope", function () {
            expect(scope.simpleString()).toEqual('Yabba dabba doo!');
        });
    });
});