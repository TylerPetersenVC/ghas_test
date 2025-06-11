import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-insecure',
  template: `<div [innerHTML]="userInput"></div>`,
})
export class InsecureComponent {
  userInput = "<script>alert('XSS')</script>";

  GITHUB_TOKEN = 'ghp_1234567890EXAMPLEfakeKEY';

  constructor(private http: HttpClient) {
    const param = 'test';
    // Insecure HTTP (hardcoded URL + no sanitization)
    this.http
      .get('http://example.com/data?input=' + param)
      .subscribe((data) => console.log(data));
  }
}
