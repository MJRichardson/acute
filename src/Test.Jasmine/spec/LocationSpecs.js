describe("Location service", function () {

    //var app = new Test.Scenarios.TestApp();

    beforeEach(function () {
        module('Test.Scenarios.TestApp');
    });

    describe('When getting Path', function () {

        var $location;
        var path;

        beforeEach(inject(function ($rootScope, _$location_ ) {

            $location = _$location_;
            var acuteLocationService = new Acute.Services.Location($location);
            $location.path('/foo/bar');
            $rootScope.$apply();
            spyOn($location, 'path').and.callThrough();

            path = acuteLocationService.get_path();
        }));
        
        it("should call Angular Location service", function () {
            expect($location.path).toHaveBeenCalled();
        });
        
        it("should return path", function () {
            expect(path).toEqual('/foo/bar');
        });

    });
});