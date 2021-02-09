import * as environment from '../config/environment.json';
import { PLATFORM } from 'aurelia-pal';
export function configure(aurelia) {
    aurelia.use
        .standardConfiguration()
        .feature(PLATFORM.moduleName('resources/index'));
    aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');
    if (environment.testing) {
        aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
    }
    aurelia.start().then(function () { return aurelia.setRoot(PLATFORM.moduleName('create-applicant')); });
}
//# sourceMappingURL=main.js.map