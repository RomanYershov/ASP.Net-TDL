import { Component, OnInit } from '@angular/core';
import { LoginService } from '../shared/login.service';
import { Router } from '@angular/router';
import { User } from '../shared/User';
import { RequestOptions, Http, Headers } from '@angular/http';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  user: User = new User();
  constructor(private loginService: LoginService,private http: Http, private router: Router) { }

  ngOnInit() {
  }

  addAccount(){
    this.loginService.AddAccount(this.user) 
  }



}
