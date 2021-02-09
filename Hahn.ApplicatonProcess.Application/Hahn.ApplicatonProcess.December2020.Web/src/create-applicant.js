import { HttpClient } from "aurelia-http-client";
import { Router } from 'aurelia-router';
import { Applicant } from "./models/Applicant";
var CreateApplicant = (function () {
    function CreateApplicant(router) {
        this.router = router;
        this.applicant = new Applicant();
        this.applicant = {
            "id": 1,
            "name": "Saurav Biswas",
            "familyName": "Biswas",
            "address": "Bakal, Agailjhara",
            "countryOfOrigin": "Bangladesh",
            "eMailAdress": "ons@yahoo.com",
            "age": 35,
            "hired": true
        };
    }
    CreateApplicant.inject = function () { return [Router]; };
    CreateApplicant.prototype.save = function () {
        var _this = this;
        debugger;
        var client = new HttpClient();
        client.post('https://localhost:44379/api/applicant', this.applicant).then(function (data) {
            alert(data);
            _this.router.navigate("app");
        }).catch(function (error) {
            console.log(error);
            alert('Error saving comment!' + error);
        });
    };
    CreateApplicant.prototype.reset = function () {
        alert("Reset");
    };
    return CreateApplicant;
}());
export { CreateApplicant };
//# sourceMappingURL=create-applicant.js.map