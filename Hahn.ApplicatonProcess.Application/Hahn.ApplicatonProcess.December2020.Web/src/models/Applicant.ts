export class Applicant {
  id: number;
  name: string;
  familyName: string;
  address: string;
  countryOfOrigin: string;
  eMailAdress: string;
  age: number;
  hired: boolean;

  public constructor(init?: Partial<Applicant>) {
    Object.assign(this, init);
  }
}
