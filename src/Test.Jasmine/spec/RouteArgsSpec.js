describe("RouteArgs service", function () {

    beforeEach(function () {
        module('Test.Scenarios.TestApp', 'ngRoute');
    });

    describe("When route arguments are supplied", function () {

        var routeArgs;
        var scope;

        beforeEach(inject(function ($rootScope, $controller) {
            routeArgs = new Acute.Services.RouteArgs( { Id: 1, Name: "Papa Smurf" });
            scope = $rootScope.$new();
            new Test.Scenarios.RouteArgs.RouteArgsTestController(routeArgs, new Acute.Scope(scope));
        }));

        it("Arguments should be accessable via dynamic Bag property", function () {
            expect(scope.ArgsBag.Id).toBe(1);
            expect(scope.ArgsBag.Name).toBe("Papa Smurf");
        });

        it("Arguments should be accessable via strongly-typed As function", function () {
            expect(scope.TypedArgs.Id).toBe(1);
            expect(scope.TypedArgs.Name).toBe("Papa Smurf");
        });


    });
});