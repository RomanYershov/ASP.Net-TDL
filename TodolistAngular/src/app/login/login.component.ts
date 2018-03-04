import { Component, OnInit } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { User } from '../shared/User';
import 'rxjs/Rx';
import { Router } from '@angular/router';
import { LoginService } from '../shared/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: User = new User();
  userToken: any;
  isLoginError: boolean = false;
  constructor(private loginService: LoginService) { }
  
  ngOnInit() {
  }


logIn(){
  this.loginService.GetToken(this.user);
}



}
