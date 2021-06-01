"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var films_service_1 = require("./films.service");
describe('FilmsService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(films_service_1.FilmsService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=films.service.spec.js.map