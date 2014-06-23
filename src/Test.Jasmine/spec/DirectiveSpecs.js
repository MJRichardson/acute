describe("When creating a directive", function () {

    beforeEach(function() {
            module('Test.Scenarios.TestApp');
    });

    describe("With a template", function () {

        var element;

        beforeEach(function() {

            var html = "<div test-directive-with-template></div>";

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

    describe("With a bound property", function () {

        var element;

        beforeEach(function() {

            var html = "<div test-directive-with-bound-property mice-count=\"miceCount\"></div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                scope.miceCount = 9;
                element = angular.element(html);
                var compiled = $compile(element);
                compiled(scope);
                scope.$digest();
            });
        });

        it("Should set the element content to the template", function() {
            expect(element.text()).toBe("9 blind mice");
        });
    });
});