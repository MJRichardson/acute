describe("When configuring a route", function () {

    describe("with an empty path", function() {

        describe("with a template-url", function() {

            var templateUrl = "/this/is/a/template.html";

            var app;
            var angularRouteProvider;

            beforeEach(function () {
                angularRouteProvider = jasmine.createSpyObj('$routeProvider', ['when']);
                app = new Test.Scenarios.RouteConfiguration.App(angularRouteProvider);
            });

            it("configures the angular routeProvider", function() {
                expect(angularRouteProvider.when).toHaveBeenCalledWith("", { templateUrl: templateUrl });
            });

        });
    });
});