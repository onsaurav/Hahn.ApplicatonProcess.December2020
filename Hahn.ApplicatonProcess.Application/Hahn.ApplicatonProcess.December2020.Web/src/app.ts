import { HttpClient } from "aurelia-http-client";
import { Applicant } from "./models/Applicant";
export class App {
  public message = 'Applicant Details';
  public applicants: Applicant[] = [];

  constructor() {   
    this.applicants = [];
    let client = new HttpClient();
    client.get('https://localhost:44379/api/applicant').then(data => {
      this.applicants = (data.content);
      return this.applicants;
    }); 
  }  

}
