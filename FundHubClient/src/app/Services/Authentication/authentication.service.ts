import { Injectable } from '@angular/core';
import {User} from "../../Data/Models/User";
import axios from "axios";
import {AuthRequest} from "./DTO/AuthRequest";
import {LoginResponse} from "./DTO/LoginResponse";
import environment from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

   axiosapi = axios.create({});

  isloggedin : boolean = false
  activeuser : User = {description: "", id: "", password: "", username: ""}
  authstatus : string = 'Login/Register'

  constructor() {
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

  async Login(loginrequest: { password: string | null | undefined, username: string | null | undefined }): Promise<any> {
    try {
      let response = await axios.post(environment.backendurl + '/Authentication/Login', loginrequest)
      let token = response.data
      this.SetActiveUser(token)
      return true
    }
    catch (err) {
      console.log(err)
    }
  }

  Logout() {
    this.activeuser = {description: "", id: "", password: "", username: ""}
    this.isloggedin = false
    localStorage.removeItem("usertoken")
    this.authstatus = "Login/Register"
    return true
  }

  async LoginTest(): Promise<any> {
    try {
      let response = await axios.get(environment.backendurl + '/Authentication/LoginTest')
      let token : string = response.data
      localStorage.setItem("usertoken", token)
      this.SetActiveUser(token)
      return true
    }
    catch (err) {
      console.log(err)
    }
  }

  async Register(registerrequest : AuthRequest) : Promise<any> {
    try {
      let response = await axios.post(environment.backendurl + 'http://localhost:5116/Authentication/Register', registerrequest)
      let check = response.data
      return check
    }
    catch (err) {
      console.log(err)
    }
  }

  async ChecKToken() {

  }

  async SetActiveUser(token : string) {
    try {
      let response = await this.axiosapi.get( environment.backendurl + '/Authentication/GetUser')
      this.activeuser = response.data
      this.authstatus = `Welcome ${this.activeuser.username}`
    }
    catch (err) {
      console.log(err)
    }
  }

  async GetActiveUser() {
    return this.activeuser
  }



}
