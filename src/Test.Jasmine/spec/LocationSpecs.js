describe("Location service", function () {
    
    var app = new Test.Scenarios.TestApp();
    
    beforeEach(function () {
        module('Test.Scenarios.TestApp');
    });

    describe('When getting Path', function () {

        var $location;

        beforeEach(inject(function (_$location_, AcuteServicesILocation) {
            
            $location = _$location_;
            //$location.path('/foo/bar');
            spyOn($location, 'path');

            AcuteServicesILocation.get_path();
        }));
        
        it("should call Angular Location service", function () {
            expect($location.path).toHaveBeenCalled();
        });

    });
});