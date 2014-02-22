describe("When creating a controller", function () {

    var app = new Test.Scenarios.Controllers.App();
    
    beforeEach(function () {
        module('Test.Scenarios.Controllers.App', 'ngRoute');
    });
    
    describe("with a simple string property", function() {
        var controller;
        var scope;
        var angularHttp;

        beforeEach(inject(function($rootScope, $controller, $http ) {
            scope = $rootScope.$new();
            angularHttp = $http;
            spyOn(angularHttp, 'get').and.callThrough();
            http = new Acute.Http.HttpDefault(angularHttp);
            controller = $controller('TestScenariosControllersController', { AcuteHttpIHttp: http, $scope: scope });
        }));
        
        it("the property should be added to the scope", function () {
            expect(scope.simpleString()).toEqual('Yabba dabba doo!');
        });

        it("GET should be called on HTTP service", function () {
            expect(angularHttp.get).toHaveBeenCalledWith("http://foo.com/bar");
        });
    });
});