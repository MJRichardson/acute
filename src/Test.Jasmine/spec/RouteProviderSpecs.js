describe("When configuring a route", function () {

    describe("with a template-url", function () {

        var path = "/this/is/a/path";
        var templateUrl = "/this/is/a/template.html";

        var app;
        var angularRouteProvider;

        beforeEach(function () {
            angularRouteProvider = jasmine.createSpyObj('$routeProvider', ['when']);
            app = new Test.Scenarios.RouteConfiguration.When.WithTemplateUrl.App(angularRouteProvider);
        });

        it("configures the angular routeProvider", function() {
            expect(angularRouteProvider.when).toHaveBeenCalledWith(path, { templateUrl: templateUrl });
        });

    });
    
    describe("with a generic controller", function () {

        var pathConfiguredWithRouteConfigWithNoInitializers = "/path/for/route/config/with/no/initializers";
        var pathConfiguredWithRouteConfigWithInitializer = "/path/for/route/config/with/initializer";
        var templateUrl = "/a/template.html";
        var app;
        var angularRouteProvider;
        
        beforeEach(function () {
            angularRouteProvider = jasmine.createSpyObj('$routeProvider', ['when']);
            app = new Test.Scenarios.RouteConfiguration.When.WithGenericController.App(angularRouteProvider);
        });

        it("configures the angular routeProvider with the controller", function () {
            expect(angularRouteProvider.when).toHaveBeenCalledWith(pathConfiguredWithRouteConfigWithNoInitializers, { controller: Test.Scenarios.RouteConfiguration.When.WithGenericController.DefaultController });
        });
        
        it("configures the angular routeProvider with the controller and the template-url", function () {
            expect(angularRouteProvider.when).toHaveBeenCalledWith(pathConfiguredWithRouteConfigWithInitializer,
                {
                    controller: Test.Scenarios.RouteConfiguration.When.WithGenericController.DefaultController,
                    templateUrl: templateUrl
                });
        });

    });
});