describe("When configuring a route", function () {
    
    var angularRouteProvider;
    var acuteRouteProvider;

    beforeEach(function () {
        angularRouteProvider = jasmine.createSpyObj('$routeProvider', ['when']);
        acuteRouteProvider = new Acute.RouteProvider(angularRouteProvider);
    });

    describe("with a template-url", function () {

        var path = "/this/is/a/path";
        var templateUrl = "/this/is/a/template.html";

        var app;

        beforeEach(function () {
            app = new Test.Scenarios.RouteConfiguration.When.WithTemplateUrl.App();
            app.configureRoutes(acuteRouteProvider);
        });

        it("configures the angular routeProvider", function () {
            expect(angularRouteProvider.when).toHaveBeenCalledWith(path, { templateUrl: templateUrl });
        });

    });
    
    describe("with a generic controller", function () {

        var pathConfiguredWithRouteConfigWithNoInitializers = "/path/for/route/config/with/no/initializers";
        var pathConfiguredWithRouteConfigWithInitializer = "/path/for/route/config/with/initializer";
        var templateUrl = "/a/template.html";
        var app;
        
        beforeEach(function () {
            app = new Test.Scenarios.RouteConfiguration.When.WithGenericController.App();
            app.configureRoutes(acuteRouteProvider);
        });

        it("configures the angular routeProvider with the controller", function () {
            expect(angularRouteProvider.when).toHaveBeenCalledWith(pathConfiguredWithRouteConfigWithNoInitializers, { controller: "Test.Scenarios.RouteConfiguration.When.WithGenericController.DefaultController" });
        });
        
        it("configures the angular routeProvider with the controller and the template-url", function () {
            expect(angularRouteProvider.when).toHaveBeenCalledWith(pathConfiguredWithRouteConfigWithInitializer,
                {
                    controller: "Test.Scenarios.RouteConfiguration.When.WithGenericController.DefaultController",
                    templateUrl: templateUrl
                });
        });

    });

});