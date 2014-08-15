﻿describe("RouteArgs service", function () {

    beforeEach(function () {
        module('Test.Scenarios.TestApp', 'ngRoute');
    });

    describe("When route arguments are supplied", function () {

        var routeArgs;
        var scope;

        beforeEach(inject(function ($rootScope, $controller) {
            routeArgs = new Acute.Services.RouteArgs(new { Id: 1, Name: "Papa Smurf" });
            scope = $rootScope.$new();
            new Test.Scenarios.RouteArgs.RouteArgsTestController(routeArgs, scope);
        }));

        it("Arguments should be accessable via dynamic Bag property", function () {
            expect(routeArgs.Bag().Id).toBe(1);
            expect(routeArgs.Bag().Name).toBe("Papa Smurf");
        });

        it("Arguments should be accessable via strongly-typed As function", function () {
            expect(scope.Id).toBe(1);
            expect(scope.Name).toBe("Papa Smurf");
        });


    });
});