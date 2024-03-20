import { Injectable } from '@angular/core';
import {User} from "../../Data/Models/User";
import axios from "axios";
import {AuthRequest} from "./DTO/AuthRequest";
import {LoginResponse} from "./DTO/LoginResponse";
import environment from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {firstValueFrom, map, Observable} from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  isloggedin : boolean = false
  authstatus : string = "Login/Register"

  constructor(private http : HttpClient) {}

  async Login(loginrequest: { password: string, username: string}){
    let logincheck : boolean
    this.http.post<string>(environment.backendurl + '/Authentication/Login', loginrequest).pipe(
      map( (token) => {
        if (token != null && undefined && "") {
          localStorage.setItem('usertoken', token)
          logincheck = true
        }
        else {logincheck = false}
      })

    )
    return logincheck
  }

  Logout() {
    this.isloggedin = false
    localStorage.removeItem("usertoken")
    this.authstatus = "Login/Register"
    return true
  }

  async Register(registerrequest : AuthRequest) {
    let registercheck : boolean
    this.http.post<string>(environment.backendurl + '/Authentication/Register', registerrequest).pipe(
      map( (token) => {
        if (token != null && undefined && "") {
          localStorage.setItem('usertoken', token)
          registercheck = true
        }
        else {registercheck = false}
      })
    )
    return registercheck
  }

  async GetActiveUser() {
    let userdata : User = {} as User
      this.http.get( environment.backendurl + '/Authentication/GetUser').pipe(
        map( (userdatares : User) => {
          this.authstatus = 'Welcome ' + userdatares.username
          userdata = userdatares
          })
      )
    return userdata
  }

}
