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
      let response = await this.axiosapi.get( environment.backendurl + '/Authentication/GetUser')
      let userdata : User = response.data
      this.authstatus = 'Welcome ' + userdata.username
      return userdata
  }




}
