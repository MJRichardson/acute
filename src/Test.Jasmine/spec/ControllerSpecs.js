﻿describe("When creating a controller", function () {

    var app;
    beforeEach(function() {
        app = new Test.Scenarios.Controllers.App();
        module('Test.Scenarios.Controllers.App', 'ngRoute');
    });
    
    describe("with a simple string property", function() {
        var controller;
        var scope;

        beforeEach(inject(function($rootScope, $controller) {
            scope = $rootScope.$new();
            controller = $controller('TestScenariosControllersController', { $scope: scope });
        }));

        
        it("the property should be added to the scope", function () {
            expect(scope.simpleString()).toEqual('Yabba dabba doo!');
        });
    });
});