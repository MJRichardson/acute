describe("When creating a controller", function () {

    //var app = new Test.Scenarios.Controllers.App();
    
    beforeEach(function () {
        module('Test.Scenarios.Controllers.App', 'ngRoute');
    });
    
    describe("with a simple string property", function() {
        var controller;
        var scope;

        beforeEach(inject(function ($rootScope, $controller) {
            scope = $rootScope.$new();
            controller = $controller('Test.Scenarios.Controllers.Controller', { $scope: scope });
        }));
        
        it("the property should be added to the scope", function () {
            expect(scope.simpleString()).toEqual('Yabba dabba doo!');
        });
    });
});