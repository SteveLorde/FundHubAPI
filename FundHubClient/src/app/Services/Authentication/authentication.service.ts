import { Injectable } from '@angular/core';
import {User} from "../../Data/Models/User";
import axios from "axios";
import {AuthRequest} from "./DTO/AuthRequest";
import {LoginResponse} from "./DTO/LoginResponse";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  isloggedin : boolean = false
  activetoken: string = ''
  activeuser : User = {description: "", id: "", password: "", username: ""}

  authstatus : string = 'Login/Register'



  constructor() { }

  async Login(loginrequest: { password: string | null | undefined, username: string | null | undefined }): Promise<any> {
    try {
      let response = await axios.post('http://localhost:5116/Authentication/Login', loginrequest)
      let loginresponse : LoginResponse = response.data
      this.activetoken = loginresponse.token
      this.SetActiveUser(loginresponse.userid)
      return true
    }
    catch (err) {
      console.log(err)
    }
  }

  Logout() {
    this.activeuser = {description: "", id: "", password: "", username: ""}
    this.isloggedin = false
    this.activetoken = " "
    this.authstatus = "Login/Register"
    return true
  }

  async LoginTest(): Promise<any> {
    try {
      let response = await axios.get('http://localhost:5116/Authentication/LoginTest')
      let loginresponse : LoginResponse = response.data
      this.activetoken = loginresponse.token
      this.SetActiveUser(loginresponse.userid)
      this.authstatus = `${this.activeuser.username}`
      return true
    }
    catch (err) {
      console.log(err)
    }
  }

  async Register(registerrequest : AuthRequest) : Promise<any> {
    try {
      let check : boolean = await axios.post('http://localhost:5116/Authentication/Register', registerrequest)
      return check
    }
    catch (err) {
      console.log(err)
    }

  }

  async ChecKToken() {

  }

  async SetActiveUser(userid : string) {
    let user : User = await axios.post('http://localhost:5116/Authentication/GetUser', userid)
    this.activeuser = user
  }

  async GetActiveUser() {
    return this.activeuser
  }



}
