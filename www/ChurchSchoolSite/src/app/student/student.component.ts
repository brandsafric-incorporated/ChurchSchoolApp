import { Component, OnInit } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  response: string;

  constructor(private http: Http, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    let requestHeader = new Headers({ 'Authorization': this.authenticationService.getAuthorizationHeaderValue() });
    let options = new RequestOptions({ headers: requestHeader });
    this.http.get(`http://localhost:6000/api/course`, options)
      .subscribe(response => {
        this.response = response.text();
      });
  }

}
