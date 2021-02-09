import { HttpClient } from "aurelia-http-client";
var App = (function () {
    function App() {
        var _this = this;
        this.message = 'Applicant Details';
        this.applicants = [];
        this.applicants = [];
        var client = new HttpClient();
        client.get('https://localhost:44379/api/applicant').then(function (data) {
            _this.applicants = (data.content);
            return _this.applicants;
        });
    }
    return App;
}());
export { App };
//# sourceMappingURL=app.js.map