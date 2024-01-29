import { Injectable } from '@angular/core';
import {User} from "../../Data/Models/User";
import axios from "axios";
import {AuthRequest} from "./DTO/AuthRequest";
import {LoginResponse} from "./DTO/LoginResponse";
import environment from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {firstValueFrom, Observable} from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  axiosapi = axios.create({});
  isloggedin : boolean = false
  authstatus : string = "Login/Register"
  test : Observable<string> = new Observable<string>()

  constructor(private http : HttpClient) {
    this.axiosapi.interceptors.request.use(
      (config : any) =>  {
        const token = localStorage.getItem("usertoken")
        const clonedReq = {
          ...config,
          headers: {
            ...config.headers,
            Authorization: `Bearer ${token}`,
          },
        };
        return clonedReq;
      },
      (error) => {
        // Handle request error
        return Promise.reject(error);
      }
    )
  }

  async Login(loginrequest: { password: string, username: string}){
    let token : string = ""
    let check : boolean = false
    this.http.post<string>(environment.backendurl + '/Authentication/Login', loginrequest).subscribe( res => {
      token = res
      if (token != null && undefined && "") {
        localStorage.setItem('usertoken', token)
        check = true }
      this.GetActiveUser()
    })
    return check
  }

  Logout() {
    this.isloggedin = false
    localStorage.removeItem("usertoken")
    this.authstatus = "Login/Register"
    return true
  }

  async Register(registerrequest : AuthRequest) {
    this.http.post<string>(environment.backendurl + '/Authentication/Register', registerrequest).subscribe(res => {
      localStorage.setItem('usertoken', res)
    })
    if (localStorage.getItem('usertoken') != null || "" || undefined) {
      return true
    }
    else {
      return false
    }
  }

  async GetActiveUser() {
      let response = await this.axiosapi.get( environment.backendurl + '/Authentication/GetUser')
      let userdata : User = response.data
      this.authstatus = 'Welcome ' + userdata.username
      return userdata
  }




}
