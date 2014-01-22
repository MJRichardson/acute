describe("When creating a controller", function () {
    describe("with a simple string property", function() {
        var controller;
        var scope;
        
        beforeEach(function () {
            scope = jasmine.createSpyObj('$scope', ['SimpleString']);
            controller = angular.injector(['ng']).get('$controller')('Test.Scenarios.Controllers.Controller', { $scope: scope });
        });
        
        it("the property should be added to the scope", function () {
            expect(scope.SimpleString).toHaveBeenCalled();
        });
    });
});