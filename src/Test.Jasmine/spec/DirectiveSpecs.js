describe("When creating a directive", function () {

    describe("With a template", function () {

        var element;

        beforeEach(function() {
            module('Test.Scenarios.TestApp');

            var html = "<div testScenariosDirectivesDirective></div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                element = angular.element(html);
                var compiled = $compile(element);
                compiled(scope);
                scope.$digest();
            });
        });

        it("Should set the element content to the template", function() {
            expect(element.text()).toBe("three blind mice");
        });
    });
});