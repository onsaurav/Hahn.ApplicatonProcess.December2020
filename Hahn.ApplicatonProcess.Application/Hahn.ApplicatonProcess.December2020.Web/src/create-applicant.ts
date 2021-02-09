import { HttpClient } from "aurelia-http-client";
import { Router } from 'aurelia-router';
import { Applicant } from "./models/Applicant";


export class CreateApplicant {
  applicant: Applicant;
  router: Router;

  static inject() { return [Router]; }
    
  constructor(router) {
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

  save() {
    debugger;
    let client = new HttpClient();
    client.post('https://localhost:44379/api/applicant', this.applicant).then(data => {
      alert(data);
      this.router.navigate("/app");
    }).catch(error => {
      console.log(error);
      alert('Error saving comment!' + error);
    }); 
    
  }

  reset() {
    alert("Reset");
  }
}
