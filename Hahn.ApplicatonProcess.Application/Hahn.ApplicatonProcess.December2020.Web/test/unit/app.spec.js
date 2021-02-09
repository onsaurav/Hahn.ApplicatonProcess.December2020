import { bootstrap } from 'aurelia-bootstrapper';
import { StageComponent } from 'aurelia-testing';
import { PLATFORM } from 'aurelia-pal';
describe('Stage App Component', function () {
    var component;
    beforeEach(function () {
        component = StageComponent
            .withResources(PLATFORM.moduleName('app'))
            .inView('<app></app>');
    });
    afterEach(function () { return component.dispose(); });
    it('should render message', function (done) {
        component.create(bootstrap).then(function () {
            var view = component.element;
            expect(view.textContent.trim()).toBe('Hello World!');
            done();
        }).catch(function (e) {
            fail(e);
            done();
        });
    });
});
//# sourceMappingURL=app.spec.js.map