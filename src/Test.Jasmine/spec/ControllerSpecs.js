describe("When creating a controller", function () {

    //var app = new Test.Scenarios.Controllers.App();
        var controller;
        var scope;
    
        beforeEach(function() {
            module('Test.Scenarios.Controllers.App', 'ngRoute');

            inject(function($rootScope, $controller) {

                scope = $rootScope.$new();
                controller = $controller('Test.Scenarios.Controllers.Controller', { $scope: scope });

            });
        });
    
    describe("with a simple string property", function() {
        
        it("the property should be added to the scope", function () {
            expect(scope.SimpleString()).toEqual('Yabba dabba doo!');
        });
    });

    describe("assigning a property directly from an object-initializer", function() {

        it("should assign the property", function () {
            expect(scope.FromObjectInitializer).toEqual(['Eenie', 'Meenie']);
        });
    });

});