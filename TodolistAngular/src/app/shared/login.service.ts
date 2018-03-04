import { Injectable } from '@angular/core';
import { User } from './User';

import { Http, RequestOptions, Headers } from '@angular/http';
import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable()
export class LoginService {
  userToken:any;
  isLoginError:boolean;
  options:any = new RequestOptions({headers: new Headers({"content-type": "application/json;charset=utf-8"})});

  constructor(private http:Http, private router:Router) { }

 

   AddAccount(user: User){
    const body = {Login: user.login, Password: user.password, Role: "admin"};
   return  this.http.post("http://localhost:55070/api/adduser", body, this.options)
   .subscribe(res => {
     if(res.ok){
      this.userToken = res.json();     
      localStorage.setItem('accessToken', this.userToken);    
      this.router.navigate(['todo'])
    }   
   },(err : HttpErrorResponse)=>{
    this.isLoginError = true;}
  )};


  GetToken(user:User){  
  const body = {Login: user.login, Password: user.password, Role: "admin"};
  this.http.post("http://localhost:55070/api/gettoken", body)
  .subscribe(res => {console.log(res);
    if (res.ok) {
      this.userToken = res.json();
      localStorage.setItem('accessToken', this.userToken);    
      this.router.navigate(['todo']);  
    };  
  },
  (err : HttpErrorResponse)=>{
   this.isLoginError = true;
  });}  
 

  LogOut(){
    localStorage.clear();
    this.router.navigate(['login']);
  }
}
