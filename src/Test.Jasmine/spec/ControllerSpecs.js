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

    describe("assigning a property from a class", function () {

        describe("with an auto-property", function() {
            it("should be able to access the property via the scope as a method", function () {
                expect(scope.FromClass.GreenBottleCount()).toEqual(99);
            });
        });

    });

});